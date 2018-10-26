using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class mapOutput : MonoBehaviour {

    public GameObject mapPanelChristChurchSteps;
    public GameObject mapPanelStarbucks;
    public GameObject mapPanelNewWorld;
    public GameObject mapPanelNMIT;
    public GameObject mapPanelStateCinemas;

    /// <summary>
    /// Proccesses logic that discerns which map nodes are which colour in order to display visited areas & the current area
    /// </summary>
    public void UpdateMap()
    {
        

        var visitedList = GameManager.GameManagerInstance.GameModelInstance.DataServiceInstance.Connection.Query<TableVisited>(
        "select * from TableVisited"
        + " inner join TablePlayer"
        + " on TableVisited.Email = TablePlayer.Email "
        + " where TableVisited.Email = ?",
        GameManager.GameManagerInstance.GameModelInstance._currentPlayer._email).ToList();

        foreach (TableVisited lcVisited in visitedList)
        {
            if (lcVisited.AreaName == "christChurchSteps")
            {
                mapPanelChristChurchSteps.GetComponent<Image>().color = new Color32(50, 205, 50, 100);
            }
            else if (lcVisited.AreaName == "starbucks")
            {
                mapPanelStarbucks.GetComponent<Image>().color = new Color32(50, 205, 50, 100);
            }
            else if (lcVisited.AreaName == "NMIT")
            {
                mapPanelNMIT.GetComponent<Image>().color = new Color32(50, 205, 50, 100);
            }
            else if (lcVisited.AreaName == "newWorld")
            {
                mapPanelNewWorld.GetComponent<Image>().color = new Color32(50, 205, 50, 100);
            }
            else if (lcVisited.AreaName == "stateCinemas")
            {
                mapPanelStateCinemas.GetComponent<Image>().color = new Color32(50, 205, 50, 100);
            }
        }

        TablePlayer lcPlayer = GameManager.GameManagerInstance.GameModelInstance.DataServiceInstance.Connection.Table<TablePlayer>().
            Where(x => x.Email == GameManager.GameManagerInstance.GameModelInstance._currentPlayer._email).FirstOrDefault();

        foreach (TableVisited lcVisited in visitedList)
        {
            if (lcPlayer.CurrentArea == "christChurchSteps")
            {
                mapPanelChristChurchSteps.GetComponent<Image>().color = new Color32(220, 20, 60, 100);
            }
            else if (lcPlayer.CurrentArea == "starbucks")
            {
                mapPanelStarbucks.GetComponent<Image>().color = new Color32(220, 20, 60, 100);
            }
            else if (lcPlayer.CurrentArea == "NMIT")
            {
                mapPanelNMIT.GetComponent<Image>().color = new Color32(220, 20, 60, 100);
            }
            else if (lcPlayer.CurrentArea == "newWorld")
            {
                mapPanelNewWorld.GetComponent<Image>().color = new Color32(220, 20, 60, 100);
            }
            else if (lcPlayer.CurrentArea == "stateCinemas")
            {
                mapPanelStateCinemas.GetComponent<Image>().color = new Color32(220, 20, 60, 100);
            }
        }
    }
}
