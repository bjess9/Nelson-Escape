using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public static class Pickup  {


    public static void PickupItem(Player prCurrentPlayer, Item prItem)
    {
        //picking up an item then removing it from the scene
        AddToInven(prCurrentPlayer, prItem);
        RemoveItemFromArea(prCurrentPlayer, prItem);
        //DisplayName = "pick up";
      
    }

    private static void AddToInven(Player prCurrentPlayer, Item prItem)
    {
        prCurrentPlayer._lstInventory.Add(prItem);
    }

    public static void RemoveItemFromArea(Player prCurrentPlayer, Item prItem)
    {
        //fix
        prCurrentPlayer._currentArea.areaElements.Remove(prItem);
    }
}
