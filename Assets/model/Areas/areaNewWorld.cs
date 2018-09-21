using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AreaNewWorld : Area
{
    public AreaNewWorld()
    {
        //Item AreaObject = new Item();
        //AreaObject.Description = "Flute";

        //instantiates pickup action & adds it to the action list
        Pickup ActionPickup = new Pickup();
        LstDecisions.Add(ActionPickup);
    }
}
