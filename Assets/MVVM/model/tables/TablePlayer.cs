using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePlayer {

    [PrimaryKey]
    public string Email { get; set; }
    public string Password { get; set; }

    public string CurrentArea { get; set; }
    public int Health { get; set; }


    public override string ToString()
    {
        return string.Format("[Person: email={0}, currentArea={1},  health={2}", Email, CurrentArea, Health);
    }

}
