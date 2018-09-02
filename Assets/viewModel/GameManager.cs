using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UManager = UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private bool gameRunning;

	public GameModel gameModel;

	public Canvas activeCanvas;
	public Dictionary<string,Canvas> canvases;

	public void setActiveCanvas (string pName){

		if (canvases.ContainsKey (pName)) {

			// set all to not active;
			foreach( Canvas acanvas in canvases.Values){
				acanvas.gameObject.SetActive (false);
			}
			activeCanvas = canvases [pName];
			Debug.Log("I am the active one " + pName);
            activeCanvas.gameObject.SetActive(true);
		} else {
			Debug.Log("I can not find " + pName + " to make active.");
		}
	}
	public string currentUScene()
	{
		return UManager.SceneManager.GetActiveScene ().name;
	}

	public void changeUScene(string pSceneName){
		UManager.SceneManager.LoadScene (pSceneName);
	}	

	void Awake() {
		if (instance == null) {
			instance = this;
			gameRunning = true;
			Debug.Log("I am the one");
			gameModel = new GameModel ();
			canvases = new Dictionary<string,Canvas> ();
		} else {
			Destroy (gameObject);
		}
	}
		
	public bool IsGameRunning(){
		return gameRunning;
	}
}
