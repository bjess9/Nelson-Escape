using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableArea {

    [PrimaryKey]
    public string AreaName { get; set; }

    //Directional map, this is used to link scenes to other scenes for movement
    public string North { get; set; }
    public string South { get; set; }
    public string East { get; set; }
    public string West { get; set; }

    public override string ToString()
    {
        return string.Format("[Person: areaName={0}, north={1},  south={2}, east={3}, west={4}", AreaName, North, South, East, West);
    }

}
