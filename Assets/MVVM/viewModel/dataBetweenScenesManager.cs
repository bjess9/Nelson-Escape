using Firebase;
using Firebase.Unity.Editor;
using UnityEngine;

public class dataBetweenScenesManager : MonoBehaviour
{
    //Used to carry state from the login Unity Scene to the gameplay interface scene such as player Email which is used to gameplay db queries.

    public static dataBetweenScenesManager dataBetweenScenesInstance = null;

    private string _email;
    public bool createNewGame;
    private string _UID;

    public string Email
    {
        get
        {
            return _email;
        }

        set
        {
            _email = value;
        }
    }

    public string UID
    {
        get
        {
            return _UID;
        }

        set
        {
            _UID = value;
        }
    }

    /// <summary>
    /// Used to make this class' object a singleton and exist throughout scene switches
    /// </summary>
    void Awake()
    {
        if (dataBetweenScenesInstance == null)
        {
            dataBetweenScenesInstance = this;
        }
        else if (dataBetweenScenesInstance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://nelson-escape.firebaseio.com/");

        //firebaseRouter.Players().SetValueAsync("Testing 1 2 3");
        //Debug.Log(firebaseRouter.Players());

    }

    #region Commented out Code

    //public void CreateNewPlayerJSON(string prUID, string prEmail, string prUsername)
    //{
    //    Player lcPlayer = new Player(prEmail, prUsername, null, null);
    //    string json = JsonUtility.ToJson(lcPlayer);

    //    firebaseRouter.BaseRef().Child("users").Child(prUID).SetRawJsonValueAsync(json);

    //}


    //pass in inven and elements
    //public void SavePlayerJSON
    //    (
    //    string prUID,
    //    string prEmail,
    //    string prUsername,
    //    List<Item> prInventory,
    //    Area prCurrentArea,
    // Area prchristChurchSteps,
    //Area prstarbucks,
    //Area prNMIT,
    //Area prNewWorld,
    //Area prstateCinemas
    //    )
    //{
    //    Player lcPlayer = new Player(prEmail, prUsername, prInventory, prCurrentArea);

    //    lcPlayer.christChurchSteps = prchristChurchSteps;
    //    lcPlayer.starbucks = prstarbucks;
    //    lcPlayer.NMIT = prNMIT;
    //    lcPlayer.newWorld = prNewWorld;
    //    lcPlayer.stateCinemas = prstateCinemas;

    //    //lcPlayer.christChurchSteps.areaElements = GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.christChurchSteps.areaElements;
    //    lcPlayer.christChurchSteps._story = GameManager.GameManagerInstance.GameModelInstance._currentPlayer.christChurchSteps._story;
    //    //lcPlayer.starbucks.areaElements = GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.starbucks.areaElements;
    //    //lcPlayer.starbucks.dcStory = GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.starbucks.dcStory;
    //    //lcPlayer.NMIT.areaElements = GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.NMIT.areaElements;
    //    //lcPlayer.NMIT.dcStory = GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.NMIT.dcStory;
    //    //lcPlayer.newWorld.areaElements = GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.newWorld.areaElements;
    //    //lcPlayer.newWorld.dcStory = GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.newWorld.dcStory;
    //    //lcPlayer.stateCinemas.areaElements = GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.stateCinemas.areaElements;
    //    //lcPlayer.stateCinemas.dcStory = GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.stateCinemas.dcStory;

    //    string jsonPlayer = JsonUtility.ToJson(lcPlayer);
    //    //string jsonChristChurchStepsAreaElements = JsonUtility.ToJson
    //    //    (
    //    //    GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.christChurchSteps.areaElements
    //    //    );
    //    string jsonChristChurchStepsStory = JsonUtility.ToJson
    //    (
    //    lcPlayer.christChurchSteps._story
    //    );

    //    firebaseRouter.BaseRef().Child("users").Child(prUID).SetRawJsonValueAsync(jsonPlayer);
    //    //firebaseRouter.BaseRef().Child("users").Child(prUID).Child("christChurchSteps").SetRawJsonValueAsync(jsonChristChurchStepsAreaElements);
    //    firebaseRouter.BaseRef().Child("users").Child(prUID).Child("christChurchSteps").Child("Story").SetRawJsonValueAsync(jsonChristChurchStepsStory);

    //}
    #endregion
}
