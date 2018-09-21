using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UManager = UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    //game manager instance
    private static GameManager _gameManagerInstance;

    //flag to indicate that the game is running
    private bool _gameRunning;

    //game model instance
    private GameModel _gameModelInstance;

    //canvas variables
    public Canvas ActiveCanvas;
    public Canvas CnvStory;
    public Canvas CnvInventory;
    public Canvas CnvMap;
    public Dictionary<string, Canvas> Canvases;

    public void SetActiveCanvas(string prCnvName)
    {

        if (Canvases.ContainsKey(prCnvName))
        {

            // set all to not active;
            foreach (Canvas lcCanvas in Canvases.Values)
            {
                lcCanvas.gameObject.SetActive(false);
            }
            ActiveCanvas = Canvases[prCnvName];
            Debug.Log("I am the active one " + prCnvName);
            //sets active canvas
            ActiveCanvas.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("I can not find " + prCnvName + " to make active.");
        }

        Canvas[] lcTempCanvases = gameObject.GetComponentsInChildren<Canvas>();

        foreach (Canvas lcCanvas in lcTempCanvases)
        {
            if (lcCanvas.name != prCnvName)
            {
                lcCanvas.gameObject.SetActive(false);
            }
        }
    }
    public string CurrentUScene()
    {
        return UManager.SceneManager.GetActiveScene().name;
    }

    public void ChangeUScene(string prSceneName)
    {
        UManager.SceneManager.LoadScene(prSceneName);
    }

    //print to debug log method

    void Awake()
    {

        if (GameManagerInstance == null)
        {
            GameManagerInstance = this;
            _gameRunning = true;
            Debug.Log("I am the one");
            //instantiates the game model
            GameModelInstance = new GameModel();
            //canvases = new Dictionary<string,Canvas> ();
        }
        else
        {
            //destroys if game already running
            Destroy(gameObject);
        }

        if (Canvases == null)
        {
            Canvases = new Dictionary<string, Canvas>();
            Canvases["cnvStory"] = CnvStory;
            Canvases["cnvInventory"] = CnvInventory;
            Canvases["cnvMap"] = CnvMap;
        }
    }



    public static GameManager GameManagerInstance
    {
        get
        {
            return _gameManagerInstance;
        }

        set
        {
            _gameManagerInstance = value;
        }
    }

    public GameModel GameModelInstance
    {
        get
        {
            return _gameModelInstance;
        }

        set
        {
            _gameModelInstance = value;
        }
    }





    public bool IsGameRunning()
    {
        return _gameRunning;
    }
}
