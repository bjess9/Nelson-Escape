using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onClickSceneChange : MonoBehaviour {

    public void LoadScene(string pSceneName)
    {
        //code for changing scene on click
        if(pSceneName == "menu")
        {
            GameModel.CurrentPlayer.LstInventory.Clear();
        }
        SceneManager.LoadScene(pSceneName);


    }

    public void quitGame()
    {
        Application.Quit();
    }
}
