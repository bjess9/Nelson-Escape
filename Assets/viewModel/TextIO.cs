using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextIO : MonoBehaviour {
	public InputField _input;
	public InputField.SubmitEvent _submit;
	public Text _output;

    void Start () {

		_input = this.GetComponent<InputField>();
		_submit = new InputField.SubmitEvent();
		_submit.AddListener(SubmitInput);

		_input.onEndEdit = _submit;

        if (GameManager.GameManagerInstance.ActiveCanvas.name != "cnvInventory" & GameManager.GameManagerInstance.ActiveCanvas.name != "cnvMap")
        {
            _output.text = CommandProcessor.LogicForDisplay(GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer);
        }

        _input.ActivateInputField();
    }

	private void SubmitInput(string prCmdInput)
	{
		CommandProcessor lcCmdProcessor = new CommandProcessor();

        string lcOutputText = "";
        string lcDebugText = "";

        string[] lcOutput = lcCmdProcessor.Parse(prCmdInput, GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer);
        lcOutputText = lcOutput[0];
        lcDebugText = lcOutput[1];
        //lcCmdProcessor.Parse(prCmdInput, lcOutputText, lcDebugText);

        _output.text = lcOutputText;

        _input.text = "";
		_input.ActivateInputField();

        Debug.Log(lcDebugText);
	}
}
