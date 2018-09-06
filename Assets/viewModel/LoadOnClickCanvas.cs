using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClickCanvas : MonoBehaviour {

    public void ChangeCanvas(Canvas pCanvas)
    {
        //code for changing canvas on click of button
        pCanvas.gameObject.SetActive(true);

        Canvas[] canvases = gameObject.GetComponentsInChildren<Canvas>();

        foreach(Canvas aCvn in canvases){
            if(aCvn.name != pCanvas.name)
            {
                aCvn.gameObject.SetActive(false);
            }
        }
    }
}
