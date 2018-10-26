using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableVisited {

    //entries in this table model that the area defined has been visited for the player in the entry

    [NotNull]
    public string AreaName { get; set; }
    [NotNull]
    public string Email { get; set; }

}
