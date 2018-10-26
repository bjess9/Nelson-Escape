using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClickCanvas : MonoBehaviour {

    /// <summary>
    /// changes the canvas
    /// </summary>
    /// <param name="prCanvas">target canvas that will be enabled, all others are disables</param>
    public void ChangeCanvas(Canvas prCanvas)
    {
        //if (prCanvas.name == "cnvStory")
        //{
        //    GameManager.GameManagerInstance.InventoryButtonText.text = "Inventory";
        //    GameManager.GameManagerInstance.MapButtonText.text = "Map";
        //}
        //code for changing canvas on click of button
        prCanvas.gameObject.SetActive(true);

        Canvas[] lcCanvases = gameObject.GetComponentsInChildren<Canvas>();

        foreach(Canvas lcCanvas in lcCanvases){
            if(lcCanvas.name != prCanvas.name)
            {
                lcCanvas.gameObject.SetActive(false);
            }
        }
    }
}
