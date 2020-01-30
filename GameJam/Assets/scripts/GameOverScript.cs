using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void gameRestart(){
        Debug.Log("test");
        SceneManager.LoadScene(1);
    }

    public void quit(){
        Application.Quit();
    }
}
