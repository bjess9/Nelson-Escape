using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAreaItem  {

    [NotNull]
    public int ItemID { get; set; }
    [NotNull]
    public string AreaName { get; set; }
    [NotNull]
    public string Email { get; set; }
}
