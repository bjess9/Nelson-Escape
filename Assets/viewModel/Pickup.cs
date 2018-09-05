using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Action  {

    public readonly string displayName = "pick up";

    public static void pickupItem()
    {
        GameModel.Pickup(GameModel.CurrentPlayer.CurrentArea.AreaObject);
        GameModel.RemoveItemFromArea(GameModel.CurrentPlayer.CurrentArea.AreaObject);
    }
}
