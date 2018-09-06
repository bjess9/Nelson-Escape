using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryOutput : MonoBehaviour
{
    // code for output to inventory screen

    public Text output;

    void Update()
    {
        if (GameModel.CurrentPlayer.LstInventory != null)
        {
            output.text = null;
            foreach (Item prItem in GameModel.CurrentPlayer.LstInventory)
            {
                //displays an items description on each line
                output.text = output.text + "\n" + prItem.Description;
            }
        }
        else
        {
            //display if inven is empty, not working yet
            output.text = "Your inventory is empty!";
        }
    }
}
