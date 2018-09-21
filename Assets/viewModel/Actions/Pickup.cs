using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pickup : PlayerAction  {

    public Pickup()
    {
        DisplayName = "pick up";
    }

    public static void PickupItem(GameModel prGameModel, Area prCurrentArea)
    {
        //picking up an item then removing it from the scene
        prGameModel.Pickup(prCurrentArea.AreaObject);
        prGameModel.RemoveItemFromArea(prCurrentArea.AreaObject);
        //DisplayName = "pick up";
    }
}
