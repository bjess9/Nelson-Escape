using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using System;

public class FormManager : MonoBehaviour {

	// UI objects linked from the inspector
	public InputField inpEmail;
	public InputField inpPassword;

	public Button btnSignup;
	public Button btnLogin;

    public Text txtStatus;

    public AuthManager authManager;

	void Awake() {
		ToggleButtonStates (false);

		// Auth delegate subscriptions
		authManager.authCallback += HandleAuthCallback;
	}

	/// <summary>
	/// Validates the email input
	/// </summary>
	public void ValidateEmail() {
		string email = inpEmail.text;
		var regexPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

		if (email != "" && Regex.IsMatch(email, regexPattern)) {
			ToggleButtonStates (true);
		} else {
			ToggleButtonStates (false);
		}
	}

	// Firebase methods
	public void OnSignUp() {
		authManager.SignUpNewUser (inpEmail.text, inpPassword.text);

		Debug.Log ("Sign Up");
	}

	public void OnLogin() {
		authManager.LoginExistingUser (inpEmail.text, inpPassword.text);

		Debug.Log ("Login");
	}

	IEnumerator HandleAuthCallback(Task<Firebase.Auth.FirebaseUser> task, string operation) {
		if (task.IsFaulted || task.IsCanceled) {
			UpdateStatus ("Sorry , there was an error creating your new account. ERROR: " + task.Exception);
		} else if (task.IsCompleted) {

			if (operation == "sign_up") {
				Firebase.Auth.FirebaseUser newPlayer = task.Result;
				Debug.LogFormat ("Welcome to Nelson Escape {0}!", newPlayer.Email);

				Player lcPlayer = new Player(newPlayer.Email, null, null, null);
                //lcPlayer.Email = newPlayer.Email;
				//firebaseManager.FirebaseManagerInstance.CreateNewPlayerJSON(newPlayer.UserId, lcPlayer);
                firebaseManager.FirebaseManagerInstance.CreateNewPlayerJSON(newPlayer.UserId, newPlayer.Email, null);
                firebaseManager.FirebaseManagerInstance.Email = newPlayer.Email;
                firebaseManager.FirebaseManagerInstance.UID = newPlayer.UserId;
            }
            else if (operation == "login")
            {
                Firebase.Auth.FirebaseUser lcPlayer = task.Result;
                firebaseManager.FirebaseManagerInstance.Email = lcPlayer.Email;
                firebaseManager.FirebaseManagerInstance.UID = lcPlayer.UserId;
            }
				
			UpdateStatus ("Loading the game scene");

			yield return new WaitForSeconds (2.5f);
			SceneManager.LoadScene ("menu");
		}
	}

	void OnDestroy() {
		authManager.authCallback -= HandleAuthCallback;
	}

	// Utilities
	private void ToggleButtonStates(bool toState) {
		btnSignup.interactable = toState;
		btnLogin.interactable = toState;
	}

	private void UpdateStatus(string message) {
        txtStatus.text = message;
    }
}
