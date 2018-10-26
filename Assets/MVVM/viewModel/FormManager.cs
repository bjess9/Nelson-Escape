using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FormManager : MonoBehaviour
{

    // UI objects linked from the inspector
    public InputField inpEmail;
    public InputField inpPassword;

    public Button btnSignup;
    public Button btnLogin;

    public Text txtStatus;

    //public AuthManager authManager;

    void Awake()
    {
        ToggleButtonStates(false);

        // Auth delegate subscriptions
        //authManager.authCallback += HandleAuthCallback;
    }

    #region Login/Signup
    /// <summary>
    /// Processes logic for signing a player up, uses the input box values to determine if the signup is successful or not, returns appropriete message to the user dependant on result
    /// </summary>
    public void OnSignUp()
    {
        //authManager.SignUpNewUser (inpEmail.text, inpPassword.text);
        Debug.Log("Sign Up");
        bool lcResult = SignUp(inpEmail.text.ToString(), inpPassword.text.ToString());

        if (lcResult == true)
        {
            //sign up successful text, wait and then load next screen
            Debug.LogFormat("Welcome to Nelson Escape {0}!", inpEmail.text);

            UpdateStatus("Success, Loading the game scene");

            System.Threading.Thread.Sleep(3000);
            SceneManager.LoadScene("menu");
        }
        else
        {
            //sign up not successful msg ?? clear fields?

            UpdateStatus("Sign up not successful, try another Email.");
            inpEmail.text = null;
            inpPassword.text = null;
        }
    }

    /// <summary>
    /// Similar to the signup button except for logging in, same basic functionality
    /// </summary>
    public void OnLogin()
    {
        //authManager.LoginExistingUser (inpEmail.text, inpPassword.text);

        Debug.Log("Login");

        bool lcResult = Login(inpEmail.text.ToString(), inpPassword.text.ToString());

        if (lcResult == true)
        {
            //login successful text, wait and then load next screen
            Debug.LogFormat("Welcome to Nelson Escape {0}!", inpEmail.text);

            UpdateStatus("Success, Loading the game scene");

            System.Threading.Thread.Sleep(3000);
            SceneManager.LoadScene("menu");
        }
        else
        {
            //login not successful msg 
            UpdateStatus("Login not successful.");
        }
    }
   
    /// <summary>
    /// processes the input parameters to determine whether the signup succeeds or not
    /// also creates the database at this stage if it does not exist yet, this could be the first initialization of the program
    /// if the signup succeeds the new player is recorded in the db
    /// </summary>
    /// <param name="prEmail">email input</param>
    /// <param name="prPassword">password input</param>
    /// <returns>returns true or false dependant on whether the signup operation completed successfully</returns>
    public bool SignUp(string prEmail, string prPassword)
    {
        DataService ds = new DataService("NelsonEscapeDatabasev3.db");

        string lcPasswordHash = sha256(prPassword);
        TablePlayer lcPlayer;
        try
        {
            lcPlayer = ds.Connection.Table<TablePlayer>().Where(x => x.Email == prEmail).FirstOrDefault();
        }
        catch
        {
            ds.CreateDB(inpEmail.text);
            lcPlayer = ds.Connection.Table<TablePlayer>().Where(x => x.Email == prEmail).FirstOrDefault();
        }
        if (lcPlayer == null)
        {
            try
            {
                TablePlayer lcNewPlayer = new TablePlayer
                {
                    Email = prEmail,
                    Password = lcPasswordHash,
                };

                ds.Connection.Insert(lcNewPlayer);

                //using firebase class singleton to store email until gamemodel is instantiated later.
                //it is named after firebase but I am not using any firebase code or services.
                dataBetweenScenesManager.dataBetweenScenesInstance.Email = prEmail;
                ds = null;
                return true;
            }
            catch
            {
                ds = null;
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Similar to the previous signup function except for logging in, compared input data to the database data to determine if there is a match
    /// </summary>
    /// <param name="prEmail">email input</param>
    /// <param name="prPassword">password input</param>
    /// <returns>returns true or false dependant on whether the log in was successful</returns>
    public bool Login(string prEmail, string prPassword)
    {
        DataService ds = new DataService("NelsonEscapeDatabasev3.db");

        string lcPasswordHash = sha256(prPassword);
        try
        {
            TablePlayer lcPlayer = ds.Connection.Table<TablePlayer>().Where(x => x.Email == prEmail).FirstOrDefault();

            if (lcPlayer.Email == prEmail && lcPasswordHash == lcPlayer.Password)
            {
                //login succeed
                dataBetweenScenesManager.dataBetweenScenesInstance.Email = prEmail;
                ds = null;
                return true;
            }
            else
            {
                //login failed
                ds = null;
                return false;
            }
        }
        catch
        {
            return false;
        }

    }
#endregion

    #region Utilities
    /// <summary>
    /// used to toggle the signup and login button states
    /// </summary>
    /// <param name="toState"> state the specifies which state the buttons will be changed to upon calling this funciton</param>
    private void ToggleButtonStates(bool toState)
    {
        btnSignup.interactable = toState;
        btnLogin.interactable = toState;
    }

    /// <summary>
    /// updates the onscreen status text, used to inform the player when required
    /// </summary>
    /// <param name="message">message parameter used for display</param>
    private void UpdateStatus(string message)
    {
        txtStatus.text = message;
    }

    /// <summary>
    /// encryptes the password with basic sha256 cryptography, not ideal but better than storing plain text passwords
    /// </summary>
    /// <param name="prRandomString">string being passed in to be turned into a sha256 hash</param>
    /// <returns>hashed string being passed back</returns>
    static string sha256(string prRandomString)
    {
        var crypt = new System.Security.Cryptography.SHA256Managed();
        var hash = new System.Text.StringBuilder();
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(prRandomString));
        
        foreach (byte lcByte in crypto)
        {
            hash.Append(lcByte.ToString("x2"));
        }
        return hash.ToString();
    }
    /// <summary>
    /// Validates the email input
    /// </summary>
    public void ValidateEmail()
    {
        string email = inpEmail.text;
        var regexPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

        if (email != "" && Regex.IsMatch(email, regexPattern))
        {
            ToggleButtonStates(true);
        }
        else
        {
            ToggleButtonStates(false);
        }
    }
#endregion

    #region Commented out Code
    ////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////// NOT IN USE ////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////
    //IEnumerator HandleAuthCallback(Task<Firebase.Auth.FirebaseUser> task, string operation)
    //{
    //    if (task.IsFaulted || task.IsCanceled)
    //    {
    //        UpdateStatus("Sorry , there was an error creating your new account. ERROR: " + task.Exception);
    //    }
    //    else if (task.IsCompleted)
    //    {

    //        if (operation == "sign_up")
    //        {
    //            Firebase.Auth.FirebaseUser newPlayer = task.Result;
    //            Debug.LogFormat("Welcome to Nelson Escape {0}!", newPlayer.Email);

    //            //Player lcPlayer = new Player(newPlayer.Email, null, null, null);
    //            //lcPlayer.Email = newPlayer.Email;
    //            //firebaseManager.FirebaseManagerInstance.CreateNewPlayerJSON(newPlayer.UserId, lcPlayer);
    //            firebaseManager.FirebaseManagerInstance.CreateNewPlayerJSON(newPlayer.UserId, newPlayer.Email, null);
    //            firebaseManager.FirebaseManagerInstance.Email = newPlayer.Email;
    //            firebaseManager.FirebaseManagerInstance.UID = newPlayer.UserId;
    //        }
    //        else if (operation == "login")
    //        {
    //            Firebase.Auth.FirebaseUser lcPlayer = task.Result;
    //            firebaseManager.FirebaseManagerInstance.Email = lcPlayer.Email;
    //            firebaseManager.FirebaseManagerInstance.UID = lcPlayer.UserId;
    //        }

    //        UpdateStatus("Loading the game scene");

    //        yield return new WaitForSeconds(2.5f);
    //        SceneManager.LoadScene("menu");
    //    }
    //}

    //void OnDestroy()
    //{
    //    //authManager.authCallback -= HandleAuthCallback;
    //}
    #endregion
}
