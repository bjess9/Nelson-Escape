using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaNewWorld : Area
{
    public areaNewWorld()
    {
        Item AreaObject = new Item();
        AreaObject.Description = "Flute";

        Pickup ActionPickup = new Pickup();

        LstDecisions.Add(ActionPickup);
    }
}
