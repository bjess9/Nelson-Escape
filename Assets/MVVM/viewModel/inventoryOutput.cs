using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryOutput : MonoBehaviour
{
    // code for output to inventory screen

    public Text _output;
    private string _lcOutput;

    void Update()
    {
        if (GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer._lstInventory != null)
        {
            
            _lcOutput = null;
            foreach (Item prItem in GameManager.GameManagerInstance.GameModelInstance.CurrentPlayer._lstInventory)
            {
                //displays an items description on each line
                _lcOutput = _lcOutput + "\n" + prItem.description;
            }
        }
        else
        {
            //display if inven is empty, not working yet
            _lcOutput = "Your inventory is empty!";
        }
        _output.text = _lcOutput;
    }
}
