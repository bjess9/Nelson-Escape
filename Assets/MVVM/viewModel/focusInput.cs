using UnityEngine;
using UnityEngine.UI;

public class focusInput : MonoBehaviour {

    /// <summary>
    /// focuses input field for the user
    /// </summary>
	void Start () {
		InputField lcFocusMe = gameObject.GetComponent<InputField> ();
		lcFocusMe.ActivateInputField ();
	}
}
