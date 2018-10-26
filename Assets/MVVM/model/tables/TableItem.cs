using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableItem  {

    [PrimaryKey, AutoIncrement]
    public int ItemID { get; set; }

    //Directional map, this is used to link scenes to other scenes for movement
    public string Description { get; set; }

    public override string ToString()
    {
        return string.Format("[Person: itemID={0}, description={1}", ItemID, Description);
    }
}
