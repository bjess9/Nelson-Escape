using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Button btnLoad;

    /// <summary>
    /// Toggles load to disabled & checks if it should be enabled by seeing if their is loaded game data
    /// </summary>
    void Awake()
    {
        ToggleButtonStates(false);
        CheckForLoad();
    }

    /// <summary>
    /// Toggles load button to specified state by parameter
    /// </summary>
    /// <param name="toState"></param>
    private void ToggleButtonStates(bool toState)
    {
        btnLoad.interactable = toState;
    }

    /// <summary>
    /// Checks if the load button should be enabled by querying the databate for existing data for that player
    /// </summary>
    public void CheckForLoad()
    {
        DataService ds = new DataService("NelsonEscapeDatabasev3.db");
        TablePlayer lcPlayer = ds.Connection.Table<TablePlayer>().Where(x => x.Email == dataBetweenScenesManager.dataBetweenScenesInstance.Email).FirstOrDefault();

        if (lcPlayer.CurrentArea != null)
        {
            ToggleButtonStates(true);
        }
        ds = null;
    }


}
