﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveCanvas : MonoBehaviour {

	// setting the active canvas
	void Start(){
		Canvas[] lcCanvases = gameObject.GetComponents<Canvas>();
		Canvas lcCanvas = lcCanvases [0];
		string lcName = lcCanvas.name;
        if (GameManager.GameManagerInstance != null)
            GameManager.GameManagerInstance.SetActiveCanvas(lcName);
	}
}
