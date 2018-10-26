using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class inventoryOutput : MonoBehaviour
{
    public Text _output;
    private string _lcOutput;

    /// <summary>
    /// Executes logic that shows the players currently obtained items in the inventory display.
    /// </summary>
    public void LoadInventory()
    {
        _lcOutput = "Items:\n\n\n";

        //pulls the inventory out of the db in list format
        var lcInventory =
        GameManager.GameManagerInstance.GameModelInstance.DataServiceInstance.Connection.Table<TableInventory>().Where(x => x.Email == GameManager.GameManagerInstance.GameModelInstance._currentPlayer._email)
        .ToList();

        //loops through each inventory item & adds its desc text to the output text
        foreach (TableInventory lcInventoryItem in lcInventory)
        {
            TableItem lcItem =
            GameManager.GameManagerInstance.GameModelInstance.DataServiceInstance.Connection.
            Table<TableItem>().
            Where(x => x.ItemID == lcInventoryItem.ItemID)
            .FirstOrDefault();

            _lcOutput = _lcOutput + lcItem.Description + "\n";
        }
        _output.text = _lcOutput;
    }

    #region Commented out Code
    //void Update()
    //{
    //    if (GameManager.GameManagerInstance.GameModelInstance._currentPlayer._lstInventory != null)
    //    {
    //        _lcOutput = null;
    //        foreach (Item prItem in GameManager.GameManagerInstance.GameModelInstance._currentPlayer._lstInventory)
    //        {
    //            //displays an items description on each line
    //            _lcOutput = _lcOutput + "\n" + prItem.description;
    //        }
    //    }
    //    else
    //    {
    //        //display if inven is empty, not working yet
    //        _lcOutput = "Your inventory is empty!";
    //    }
    //    _output.text = _lcOutput;
    //}
    #endregion
}
