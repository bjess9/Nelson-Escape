using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class focusInput : MonoBehaviour {

	// Use this for initialization

    // focuses input field for the user
	void Start () {
		InputField lcFocusMe = gameObject.GetComponent<InputField> ();
		lcFocusMe.ActivateInputField ();
	}
	

}
