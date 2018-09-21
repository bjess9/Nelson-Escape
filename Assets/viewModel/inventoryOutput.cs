using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryOutput : MonoBehaviour
{
    // code for output to inventory screen

    public Text _output;

    void Update()
    {
        if (GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.LstInventory != null)
        {
            _output.text = null;
            foreach (Item prItem in GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer.LstInventory)
            {
                //displays an items description on each line
                _output.text = _output.text + "\n" + prItem.Description;
            }
        }
        else
        {
            //display if inven is empty, not working yet
            _output.text = "Your inventory is empty!";
        }
    }
}
