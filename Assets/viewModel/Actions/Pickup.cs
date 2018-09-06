using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Action  {

    public Pickup()
    {
        DisplayName = "pick up";
    }

    public static void pickupItem()
    {
        //picking up an item then removing it from the scene
        GameModel.Pickup(GameModel.CurrentPlayer.CurrentArea.AreaObject);
        GameModel.RemoveItemFromArea(GameModel.CurrentPlayer.CurrentArea.AreaObject);

        //DisplayName = "pick up";
    }
}
