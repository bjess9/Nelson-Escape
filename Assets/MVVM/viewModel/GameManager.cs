using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UManager = UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public enum DIRECTION { North, South, East, West };

public class GameManager : MonoBehaviour
{
    //game manager instance
    private static GameManager _gameManagerInstance = null;

    //flag to indicate that the game is running
    private bool _gameRunning;

    //game model instance
    private GameModel _gameModelInstance = null;

    //canvas variables
    public Canvas ActiveCanvas;
    public Canvas CnvStory;
    public Canvas CnvInventory;
    public Canvas CnvMap;
    public Dictionary<string, Canvas> Canvases;

    //public Text MapButtonText;
    //public Text InventoryButtonText;

    //public static DatabaseReference mDatabaseRef;

    //public static void writeNewUser(string prUserName, Player prPlayer)
    //{
    //    FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://nelson-escape.firebaseio.com/");
    //    DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

    //    DatabaseReference usersref = reference.Child("Users");
    //    Player lcPlayer = new Player();
    //    lcPlayer = prPlayer;
    //    string json = JsonUtility.ToJson(lcPlayer);

    //    reference.Child("Users").Child(prUserName).SetRawJsonValueAsync(json);
    //}

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

    /// <summary>
    /// sets the gamemanager instance to exist as a singleton, no copies permitted of this object
    /// </summary>
    void Awake()
    {
        
        if (GameManagerInstance == null)
        {
            GameManagerInstance = this;
            GameModelInstance = new GameModel();
            _gameRunning = true;
            Debug.Log("I am the one");
            //instantiates the game model
            
            //canvases = new Dictionary<string,Canvas> ();
        }
        else
        {
            //destroys if game already running
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

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
