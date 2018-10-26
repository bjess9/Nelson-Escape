using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableStory {


    [NotNull]
    public string Phase { get; set; }
    [NotNull]
    public string AreaName { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return string.Format("[Person: phase={0}, areaName={1},  description={2}", Phase, AreaName, Description);
    }
}
