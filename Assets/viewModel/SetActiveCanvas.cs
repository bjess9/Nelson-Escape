using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveCanvas : MonoBehaviour {

	// Use this for initialization
	void Start(){
		Canvas[] lcCanvases = gameObject.GetComponents<Canvas>();
		Canvas lcCanvas = lcCanvases [0];
		string lcName = lcCanvas.name;
		if(GameManager.instance != null)
		  // Do we need to check if we already have this name?
		  GameManager.instance.setActiveCanvas (lcName);

	}
}
