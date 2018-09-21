using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AreaStarbucks : Area
{
    public AreaStarbucks()
    {
        //Item AreaObject = new Item();
        //AreaObject.Description = "$5";

        //instantiates pickup action & adds it to the action list
        Pickup ActionPickup = new Pickup();
        LstDecisions.Add(ActionPickup);

    }
}
