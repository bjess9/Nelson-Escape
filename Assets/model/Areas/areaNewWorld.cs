using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaNewWorld : Area
{
    public areaNewWorld()
    {
        //Item AreaObject = new Item();
        //AreaObject.Description = "Flute";

        //instantiates pickup action & adds it to the action list
        Pickup ActionPickup = new Pickup();
        LstDecisions.Add(ActionPickup);
    }
}
