using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextIO : MonoBehaviour {
	public InputField _input;
	public InputField.SubmitEvent _submit;
	public Text _output;
    public Text _healthOutput;

    /// <summary>
    /// loads input field into program
    /// loads initial game interface values
    /// activates the loaded input field
    /// </summary>
    void Start () {

		_input = this.GetComponent<InputField>();
		_submit = new InputField.SubmitEvent();
		_submit.AddListener(SubmitInput);

		_input.onEndEdit = _submit;

        //Initialized state for game, loaded from db.

        int lcHealth = GameManager.GameManagerInstance.GameModelInstance.DataServiceInstance.GetHealth(GameManager.GameManagerInstance.GameModelInstance._currentPlayer._email);
        _healthOutput.text = lcHealth.ToString();


        string lcStory = GameManager.GameManagerInstance.GameModelInstance.DataServiceInstance.
            GetStory(
                     GameManager.GameManagerInstance.GameModelInstance._currentPlayer._email
                     );
        _output.text = lcStory.ToString() + CommandProcessor.AvailableActions(GameManager.GameManagerInstance.GameModelInstance._currentPlayer);
        //if (GameManager.GameManagerInstance.ActiveCanvas.name != "cnvInventory" & GameManager.GameManagerInstance.ActiveCanvas.name != "cnvMap")
        //{
        //_output.text = CommandProcessor.StoryDisplay(GameManager.GameManagerInstance.GameModelInstance._currentPlayer);
        //}

        _input.ActivateInputField();
    }

    /// <summary>
    /// used to process the input & display the output that is returned via the command processor
    /// </summary>
    /// <param name="prCmdInput">input from the input field</param>
	private void SubmitInput(string prCmdInput)
	{
		CommandProcessor lcCmdProcessor = new CommandProcessor();

        string lcOutputText = "";
        string lcDebugText = "";

        string[] lcOutput = lcCmdProcessor.Parse(prCmdInput, GameManager.GameManagerInstance.GameModelInstance._currentPlayer);
        lcOutputText = lcOutput[0];
        lcDebugText = lcOutput[1];
        //lcCmdProcessor.Parse(prCmdInput, lcOutputText, lcDebugText);

        _output.text = lcOutputText;

        _input.text = "";
		_input.ActivateInputField();

        Debug.Log(lcDebugText);
	}
}
