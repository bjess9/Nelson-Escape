using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClickCanvas : MonoBehaviour {
    public void ChangeCanvas(Canvas pCanvas)
    {
        pCanvas.gameObject.SetActive(true);

        //if (pCanvas.name == "cnvInventory")
        //{
        //    inventoryOutput.UpdateInventory();
        //}

       
        Canvas[] canvases = gameObject.GetComponentsInChildren<Canvas>();

        foreach(Canvas aCvn in canvases){
            if(aCvn.name != pCanvas.name)
            {
                aCvn.gameObject.SetActive(false);
            }
        }
    }
	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
