using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClickCanvas : MonoBehaviour {

    public void ChangeCanvas(Canvas prCanvas)
    {
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
