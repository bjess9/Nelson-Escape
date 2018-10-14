using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onClickSceneChange : MonoBehaviour {

    public void LoadScene(string prSceneName)
    {
        //code for changing scene on click
        if(prSceneName == "menu")
        {
            
            GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer._lstInventory.Clear();
            GameManager.GameManagerInstance.GameModelInstance.MakeAreas();
        }
        SceneManager.LoadScene(prSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
