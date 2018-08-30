using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onClickSceneChange : MonoBehaviour {

    public void LoadScene(string pSceneName)
    {
        SceneManager.LoadScene(pSceneName);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
