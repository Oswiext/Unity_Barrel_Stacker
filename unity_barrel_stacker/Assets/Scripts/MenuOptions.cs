using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{

    public void SceneSelect()
    {
        switch (this.gameObject.name)
        {
            case "StartButton":
                SceneManager.LoadScene("Game");
                break;
        }
    }
}
