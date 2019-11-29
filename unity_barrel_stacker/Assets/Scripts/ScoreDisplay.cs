using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{

    public static int score = 0;
    public UnityEngine.UI.Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = ScoreDisplay.score;
        scoreText.text = "Score: " + score;
    }
}
