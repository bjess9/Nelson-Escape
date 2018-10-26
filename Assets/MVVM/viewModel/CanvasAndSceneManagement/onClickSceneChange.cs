using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onClickSceneChange : MonoBehaviour {

    /// <summary>
    /// logic for loading the correct scene, sets createNewGame function if it recieves the specified parameter
    /// </summary>
    /// <param name="prCondition">used to determine which scene is loaded</param>
    public void LoadScene(string prCondition)
    {
        //code for changing scene on click
        if(prCondition == "interfaceCreate")
        {
            DataService ds = new DataService("NelsonEscapeDatabasev3.db");
            ds.NewGame(dataBetweenScenesManager.dataBetweenScenesInstance.Email);
            ds = null;
            dataBetweenScenesManager.dataBetweenScenesInstance.createNewGame = true;
            SceneManager.LoadScene("interface");
        }
        else if (prCondition == "interfaceLoad")
        {
            dataBetweenScenesManager.dataBetweenScenesInstance.createNewGame = false;
            SceneManager.LoadScene("interface");
        }
        else
        {
            SceneManager.LoadScene(prCondition);
        }
        
    }

    /// <summary>
    /// quits the current application
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
