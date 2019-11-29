using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    public BoxSpawner box_Spawner;

    [HideInInspector]
    public BoxScript currentBox;

    public CameraFollow cameraScript;
    private int moveCount;

    //singletons
    void Awake()
    {
        if (instance == null)
            instance = this;
    }




    // Start is called before the first frame update
    void Start()
    {
        box_Spawner.SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }
    
    void DetectInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentBox.DropBox();

        }
    }

    //boxscript landed invoke spawnnewbox
    public void SpawnNewBox()
    {
        Invoke("NewBox", 2f);
    }
    //invoke in 2 secs/f
    void NewBox()
    {
        box_Spawner.SpawnBox();
    }

    public void MoveCamera()
    {
        moveCount++;

        //each 3 the camera go up in y position
        if(moveCount == 3)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 2f;
        }
    }

    public void RestartGame()
    {
        //load level with current name
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

}
