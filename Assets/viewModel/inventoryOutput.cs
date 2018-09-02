using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryOutput : MonoBehaviour
{
    public Text output;

    void Update()
    {
        if (GameModel.CurrentPlayer.LstInventory != null)
        {
            output.text = null;
            foreach (Item prItem in GameModel.CurrentPlayer.LstInventory)
            {
                output.text = output.text + "\n" + prItem.Description;
            }
        }
        else
        {
            output.text = "Your inventory is empty!";
        }
    }
}
