using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    //moving box left and right 2.2f
    private float min_X = -2.2f, max_X = 2.2f;

    private bool canMove;
    private float move_Speed = 2f;

    private Rigidbody2D myBody;

    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;

    private static int score;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        //so the box doesnt fall down
        myBody.gravityScale = 0f;
    }


    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

        //random movement
        if(Random.Range(0, 2) > 0)
        {
            move_Speed *= 1f;
        }

        //reference to current box
        GameplayController.instance.currentBox = this;

    }

    // Update is called once per frame
    void Update()
    {
        
        MoveBox();
    }

    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;

            temp.x += move_Speed * Time.deltaTime;

            //change direction
            if(temp.x > max_X)
            {
                move_Speed *= -1f;
            }
            else if (temp.x < min_X)
            {
                move_Speed *= -1f;
            }


            transform.position = temp;
        }
    }

    public void DropBox()
    {
        //freeze move
        canMove = false;
        //gravity pull down
        myBody.gravityScale = Random.Range(2, 4);
    }

    void Landed()
    {
        if (gameOver)
            return;

        ignoreCollision = true;
        ignoreTrigger = true;

        GameplayController.instance.SpawnNewBox();
        GameplayController.instance.MoveCamera();
    }

    void RestartGame()
    {
        ScoreDisplay.score = 0;
        GameplayController.instance.RestartGame();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision)
            return;

        //if collision happen on target with tag platform
        if(target.gameObject.tag == "Platform")
        {
            //call landed in 2 seconds
            Invoke("Landed", 2f);
            ignoreCollision = true;
        }

        else if (target.gameObject.tag == "Box")
        {
            ScoreDisplay.score++;
            //call landed in 2 seconds
            Invoke("Landed", 2f);
            ignoreCollision = true;
        }
    }

    //if box fall down
    void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger)
            return;

        if(target.tag == "GameOver")
        {
            CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;

            Invoke("RestartGame", 2f);
        }

    }

}
