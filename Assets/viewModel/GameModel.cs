using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;



using System.Text;

public class GameModel
{

    private static String _name;
    private static Player _player = new Player();

    public enum DIRECTION { North, South, East, West };
    private static Scene _start_scene; // ??
    public static Players PlayersInGame = new Players();

    public GameModel()
    {
        MakeScenes();
    }
        

    public static Scene Start_scene
    {
        get
        {
            return _start_scene;
        }
        set
        {
            _start_scene = value;
        }

    }

    public static string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }

    }

    public static Player CurrentPlayer
    {
        get
        {
            return _player;
        }
        set
        {
            _player = value;
        }

    }
    public static void go(DIRECTION pDirection)
    {
        _player.Move(pDirection);
    }

    public static void Pickup(Item prItem)
    {
        CurrentPlayer.LstInventory.Add(prItem);
    }

    public static void RemoveItemFromScene(Item prItem)
    {
        CurrentPlayer.CurrentScene.SceneObject = null;
    }


    public static void MakeScenes()
    {
        //change canvas for swapping to inventory/map    
        Scene christChurchSteps = new Scene();
        Scene starbucks = new Scene();
        Scene NMIT = new Scene();
        Scene newWorld = new Scene();
        Scene stateCinemas = new Scene();

        //sets the current scene to the beginning scene upon scene creation.
        _player.CurrentScene = christChurchSteps;

        //Christ Church Steps (Start Scene)
        christChurchSteps.LstStory.Add("You wake up on some stone steps in Nelson, you appear to be on the main street. Enter 'go north' to continue.");
        christChurchSteps.North = starbucks;
        christChurchSteps.South = null;
        christChurchSteps.West = null;
        christChurchSteps.East = null;

        //starbucks
        //need to code what happens on decision that then also changes the text for this scene
        //for the rest of the game
        starbucks.SceneObject = new Item
        {
            Description = "$5"
        };
        starbucks.LstStory.Add("Yup that's starbucks.");
        starbucks.LstStory.Add("You pick up the moneys, another day another dolla. Where to go from here?");
        starbucks.LstStory.Add("You arrive at starbucks, you see $5 on the ground." + "/n" + "Type 'pick up' to pick it up.");
        starbucks.North = stateCinemas;
        starbucks.South = christChurchSteps;
        starbucks.East = newWorld;
        starbucks.West = NMIT;

        //NMIT
        NMIT.LstStory.Add("You walk onto the local polytech ground, searching for someone who might know now to escape this damn city." + "/n" + "Someone approaches you and asks" +
                            "you want to do their SYD survey, do you want to do it? yes/no");
        NMIT.LstStory.Add("The student is grateful and gives you a free coffee voucher in return!");
        NMIT.LstStory.Add("You politely decline and realize nobody helpful is here, where to next?");
        NMIT.North = null;
        NMIT.South = null;
        NMIT.East = starbucks;
        NMIT.West = null;

        //newWorld
        newWorld.SceneObject = new Item
        {
            Description = "Flute"
        };
        newWorld.LstStory.Add("Yup that's new world.");
        newWorld.LstStory.Add("you picked up the flute, you absolute madman, lets get out of here!!");
        newWorld.LstStory.Add("new world, wow look there's a flute on the ground, enter 'pick up' to pick it up hahahaha");
        newWorld.North = null;
        newWorld.South = null;
        newWorld.East = null;
        newWorld.West = starbucks;

        //stateCinemas
        stateCinemas.LstStory.Add("cinemas, they're selling popcorn, do you want to buy? Enter y/n.");
        stateCinemas.North = null;
        stateCinemas.South = starbucks;
        stateCinemas.East = null;
        stateCinemas.West = null;

        //      Scene tmp; 

        //Start_scene = new Scene();
        //      tmp = new Scene();

        //Start_scene.North = tmp;
        //Start_scene.Description = " You are lost in a forest" ;

        //tmp.Description = " You are in the Mall" ;
        //tmp.South = Start_scene;
        //tmp.North = new Scene ();

        //tmp.North.Description = "You fell off a clift";
        //tmp.North.South = tmp;// ??

        //currentPlayer.CurrentScene = Start_scene;

    }
}

