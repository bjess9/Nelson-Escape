using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

[Serializable]
public class GameModel
{
    private DataService dataServiceInstance = new DataService("NelsonEscapeDatabasev3.db");

    //holds current player object
    public Player _currentPlayer;

    public DataService DataServiceInstance
    {
        get
        {
            return dataServiceInstance;
        }

        set
        {
            dataServiceInstance = value;
        }
    }

    //private Players _playersInGame = new Players();

    /// <summary>
    /// if the createNewGame condition is set then the constructor calls the new game function to overwrite existing player with new game defaults
    /// </summary>
    public GameModel()
    {
        try
        {
            _currentPlayer = new Player(dataBetweenScenesManager.dataBetweenScenesInstance.Email, "tempusername");
            if (dataBetweenScenesManager.dataBetweenScenesInstance.createNewGame == true)
            {
                DataServiceInstance.NewGame(_currentPlayer._email);
            }
        }
        catch
        {
            Debug.Log("Error finding DataBetweenScenesManager Object.");
        }

    }
    #region Commented out Code
    ////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////// NOT IN USE ////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////
    //public void MakeAreas()
    //{
    //    //instantiates area objects
    //    _currentPlayer.christChurchSteps = new Area();
    //    _currentPlayer.starbucks = new Area();
    //    _currentPlayer.NMIT = new Area();
    //    _currentPlayer.newWorld = new Area();
    //    _currentPlayer.stateCinemas = new Area();


    ////Area lcChristChurchSteps = new Area();
    ////    Area lcStarbucks = new Area();
    ////    Area lcNMIT = new Area();
    ////    Area lcNewWorld = new Area();
    ////    Area lcStateCinemas = new Area();

    //    //sets the current scene, note this also stores all related scenes as they are connected through the 'memory pointers' within the object

    //    _currentPlayer._currentArea = _currentPlayer.christChurchSteps;

    //    //Christ Church Steps (Start Scene)
    //    //_currentPlayer.christChurchSteps.dcStory.Add("defaultFirstVisit", "You wake up on some stone steps in Nelson, you appear to be on the main street.\n\nEnter 'go north' to Begin.");
    //    //_currentPlayer.christChurchSteps.dcStory.Add("default", "You return to the steps again, nothing to see here");
    //    _currentPlayer.christChurchSteps._story._default = "You wake up on some stone steps in Nelson, you appear to be on the main street.\n\nEnter 'go north' to Begin.";
    //    _currentPlayer.christChurchSteps._story._defaultFirstVisit = "You return to the steps again, nothing to see here";
    //    _currentPlayer.christChurchSteps.North = "starbucks";


    //    //PICK UP starbucks

    //    Item FiveDollars = new Item
    //    {
    //        description = "$5"
    //    };

    //    _currentPlayer.starbucks.areaElements.Add(FiveDollars);

    //    _currentPlayer.starbucks.dcStory.Add("defaultFirstVisit", "You arrive at starbucks, no money on the ground this time.");
    //    _currentPlayer.starbucks.dcStory.Add("default", "You return to starbucks.");
    //    _currentPlayer.starbucks.dcStory.Add("postPickup", "You pick up the moneys, another day another dolla. Where to go from here?");
    //    _currentPlayer.starbucks.dcStory.Add("prePickup", "You arrive at starbucks, you see $5 on the ground.");
    //    //starbucks.ActionPickup = new Pickup();
    //    //starbucks.LstDecisions.Add(starbucks.ActionPickup);
    //    _currentPlayer.starbucks.North = "stateCinemas";
    //    _currentPlayer.starbucks.South = "christChurchSteps";
    //    _currentPlayer.starbucks.East = "newWorld";
    //    _currentPlayer.starbucks.West = "NMIT";

    //    //DECISION NMIT
    //    _currentPlayer.NMIT.dcStory.Add("defaultFirstVisit", "you're at nmit decision not implemented yet");
    //    _currentPlayer.NMIT.dcStory.Add("default", "you return to nmit, decision not implemented yet");
    //    _currentPlayer.NMIT.dcStory.Add("preDecision", "You walk onto the local polytech ground, searching for someone who might know now to escape this damn city." + "\n" + "Someone approaches you and asks" +
    //                        "you want to do their SYD survey, do you want to do it? yes/no");
    //    _currentPlayer.NMIT.dcStory.Add("postDecisionYes", "The student is grateful and gives you a free coffee voucher in return!");
    //    _currentPlayer.NMIT.dcStory.Add("postDecisionNo", "You politely decline and realize nobody helpful is here, where to next?");
    //    _currentPlayer.NMIT.East = "starbucks";


    //    //PICK UP newWorld
    //    //newWorld.AreaObject = new Item
    //    //{
    //    //    Description = "Flute"
    //    //};

    //    _currentPlayer.newWorld.dcStory.Add("defaultFirstVisit", "new world, no flute on the ground anymore.");
    //    _currentPlayer.newWorld.dcStory.Add("default", "you return to new world.");
    //    _currentPlayer.newWorld.dcStory.Add("postPickup", "you picked up the flute, you absolute madman, lets get out of here!!");
    //    _currentPlayer.newWorld.dcStory.Add("prePickup", "new world, wow look there's a flute on the ground, enter 'pick up' to pick it up hahahaha");
    //    _currentPlayer.newWorld.West = "starbucks";

    //    //DECISION stateCinemas
    //    _currentPlayer.stateCinemas.dcStory.Add("defaultFirstVisit", "you arrive at state cinemas, decision not implemented yet");
    //    _currentPlayer.stateCinemas.dcStory.Add("default", "you return to state cinemas, decision not implemented yet");
    //    _currentPlayer.stateCinemas.dcStory.Add("preDecision", "cinemas, they're selling popcorn, do you want to buy? Enter y/n.");
    //    _currentPlayer.stateCinemas.dcStory.Add("postDecisionYes", "The student is grateful and gives you a free coffee voucher in return!");
    //    _currentPlayer.stateCinemas.dcStory.Add("postDecisionNo", "You politely decline and realize nobody helpful is here, where to next?");

    //    _currentPlayer.stateCinemas.South = "starbucks";

    //    //_currentPlayer.christChurchSteps = lcChristChurchSteps;
    //    //_currentPlayer.starbucks = lcStarbucks;
    //    //_currentPlayer.NMIT = lcNMIT;
    //    //_currentPlayer.newWorld = lcNewWorld;
    //    //_currentPlayer.stateCinemas = lcStateCinemas;
    //}
    #endregion
}

