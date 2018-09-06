using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class GameModel
{

    //private static String _name = "Bro";

    //holds current player object
    private static Player _currentPlayer = new Player();
    public enum DIRECTION { North, South, East, West };
    //private static Area _startArea; // ??
    //public static Players PlayersInGame = new Players();

    public GameModel()
    {
        MakeAreas();
    }

    //public static Area StartArea
    //{
    //    get
    //    {
    //        return _startArea;
    //    }
    //    set
    //    {
    //        _startArea = value;
    //    }

    //}

    //public static string Name
    //{
    //    get
    //    {
    //        return _name;
    //    }
    //    set
    //    {
    //        _name = value;
    //    }

    //}

    public static Player CurrentPlayer
    {
        get
        {
            return _currentPlayer;
        }
        set
        {
            _currentPlayer = value;
        }

    }
    public static void go(DIRECTION pDirection)
    {
        _currentPlayer.Move(pDirection);
    }

    public static void Pickup(Item prItem)
    {
        CurrentPlayer.LstInventory.Add(prItem);
    }

    public static void RemoveItemFromArea(Item prItem)
    {
        CurrentPlayer.CurrentArea.AreaObject = null;
    }




    public static void MakeAreas()
    {
        //instantiates area objects
        areaChristChurchSteps christChurchSteps = new areaChristChurchSteps();
        areaStarbucks starbucks = new areaStarbucks();
        areaNMIT NMIT = new areaNMIT();
        areaNewWorld newWorld = new areaNewWorld();
        areaStateCinemas stateCinemas = new areaStateCinemas();

        //sets the current scene, note this also stores all related scenes as they are connected through the 'memory pointers' within the object
        _currentPlayer.CurrentArea = christChurchSteps;

        //Christ Church Steps (Start Scene)
        christChurchSteps.DcStory.Add("defaultFirstVisit", "You wake up on some stone steps in Nelson, you appear to be on the main street.\n\nEnter 'go north' to Begin.");
        christChurchSteps.DcStory.Add("default", "You return to the steps again, nothing to see here");
        christChurchSteps.North = starbucks;
        christChurchSteps.South = null;
        christChurchSteps.West = null;
        christChurchSteps.East = null;

        //PICK UP starbucks
        starbucks.AreaObject = new Item
        {
            Description = "$5"
        };
        starbucks.DcStory.Add("defaultFirstVisit", "You arrive at starbucks, no money on the ground this time.");
        starbucks.DcStory.Add("default", "You return to starbucks.");
        starbucks.DcStory.Add("postPickup", "You pick up the moneys, another day another dolla. Where to go from here?");
        starbucks.DcStory.Add("prePickup", "You arrive at starbucks, you see $5 on the ground.");
        //starbucks.ActionPickup = new Pickup();
        //starbucks.LstDecisions.Add(starbucks.ActionPickup);
        starbucks.North = stateCinemas;
        starbucks.South = christChurchSteps;
        starbucks.East = newWorld;
        starbucks.West = NMIT;

        //DECISION NMIT
        NMIT.DcStory.Add("defaultFirstVisit", "you're at nmit decision not implemented yet");
        NMIT.DcStory.Add("default", "you return to nmit, decision not implemented yet");
        NMIT.DcStory.Add("preDecision", "You walk onto the local polytech ground, searching for someone who might know now to escape this damn city." + "\n" + "Someone approaches you and asks" +
                            "you want to do their SYD survey, do you want to do it? yes/no");
        NMIT.DcStory.Add("postDecisionYes", "The student is grateful and gives you a free coffee voucher in return!");
        NMIT.DcStory.Add("postDecisionNo", "You politely decline and realize nobody helpful is here, where to next?");
        NMIT.North = null;
        NMIT.South = null;
        NMIT.East = starbucks;
        NMIT.West = null;

        //PICK UP newWorld
        newWorld.AreaObject = new Item
        {
            Description = "Flute"
        };

        newWorld.DcStory.Add("defaultFirstVisit", "new world, no flute on the ground anymore.");
        newWorld.DcStory.Add("default", "you return to new world.");
        newWorld.DcStory.Add("postPickup", "you picked up the flute, you absolute madman, lets get out of here!!");
        newWorld.DcStory.Add("prePickup", "new world, wow look there's a flute on the ground, enter 'pick up' to pick it up hahahaha");
        newWorld.North = null;
        newWorld.South = null;
        newWorld.East = null;
        newWorld.West = starbucks;

        //DECISION stateCinemas
        stateCinemas.DcStory.Add("defaultFirstVisit", "you arrive at state cinemas, decision not implemented yet");
        stateCinemas.DcStory.Add("default", "you return to state cinemas, decision not implemented yet");
        stateCinemas.DcStory.Add("preDecision", "cinemas, they're selling popcorn, do you want to buy? Enter y/n.");
        stateCinemas.DcStory.Add("postDecisionYes", "The student is grateful and gives you a free coffee voucher in return!");
        stateCinemas.DcStory.Add("postDecisionNo", "You politely decline and realize nobody helpful is here, where to next?");
        stateCinemas.North = null;
        stateCinemas.South = starbucks;
        stateCinemas.East = null;
        stateCinemas.West = null;

    }
}

