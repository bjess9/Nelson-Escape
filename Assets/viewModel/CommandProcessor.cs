using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;

public delegate void aDisplayer(String value);

public class CommandProcessor
{
    public CommandProcessor()
    {
    }

    public void Parse(String pCmdStr, aDisplayer display)
    {
        // default display
        String strResult = "Do not understand";

        //seperating input by spaces and putting into an array for processing
        char[] charSeparators = new char[] { ' ' };
        pCmdStr = pCmdStr.ToLower();
        String[] parts = pCmdStr.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries); // tokenise the command

        if (parts.Length > 0)
        {
            switch (parts[0])
            {//first condition logic
                case "pick":
                    if (parts[1] == "up")
                    {
                        Debug.Log("Got Pick up");
                        if (GameModel.CurrentPlayer.CurrentArea.AreaObject != null)
                        {
                            strResult = GameModel.CurrentPlayer.CurrentArea.DcStory["postPickup"];

                            //removes pickup action from scene if an object is picked up
                            foreach (Action action in GameModel.CurrentPlayer.CurrentArea.LstDecisions)
                                if (Action.DisplayName == "pick up")
                                {
                                    GameModel.CurrentPlayer.CurrentArea.LstDecisions.Remove(action);
                                    break;
                                }

                            //adds displaydecisions result to current output 
                            strResult = strResult + DisplayDecisions();

                            //picks up item
                            Pickup.pickupItem();
                        }
                        else
                        {
                            strResult = "There is nothing to pick up";
                            strResult = strResult + logicForDisplay();
                        }

                        if (parts.Length == 3)
                        {
                            String param = parts[2];
                        }
                    }
                    display(strResult);
                    break;
                case "go":
                    switch (parts[1])
                    {
                        case "north":
                            Debug.Log("Got go North");
                            setVisitedToTrueIfFirstTime();
                            //only attempts to go north if there is an area connected to the north direction
                            if (GameModel.CurrentPlayer.CurrentArea.North != null)
                            {
                                GameModel.go(GameModel.DIRECTION.North);
                                strResult = logicForDisplay();
                            }
                            else
                            {
                                strResult = "You can't go in that direction";
                            }

                            break;
                        case "south":
                            Debug.Log("Got go South");
                            setVisitedToTrueIfFirstTime();
                            if (GameModel.CurrentPlayer.CurrentArea.South != null)
                            {
                                GameModel.go(GameModel.DIRECTION.South);
                                strResult = logicForDisplay();
                            }
                            else
                            {
                                strResult = "You can't go in that direction";
                            }

                            break;
                        case "east":
                            Debug.Log("Got go East");
                            setVisitedToTrueIfFirstTime();
                            if (GameModel.CurrentPlayer.CurrentArea.East != null)
                            {
                                GameModel.go(GameModel.DIRECTION.East);
                                strResult = logicForDisplay();
                            }
                            else
                            {
                                strResult = "You can't go in that direction";
                            }

                            break;
                        case "west":
                            Debug.Log("Got go West");
                            setVisitedToTrueIfFirstTime();
                            if (GameModel.CurrentPlayer.CurrentArea.West != null)
                            {
                                GameModel.go(GameModel.DIRECTION.West);
                                strResult = logicForDisplay();
                            }
                            else
                            {
                                strResult = "You can't go in that direction";
                            }
                            break;
                        default:
                            Debug.Log(" do not know how to go there");
                            strResult = "Do not know how to go there";
                            break;

                    }
                    display(strResult);
                    break;
                case "show"://shows canvas using text input
                    switch (parts[1])
                    {
                    
                        case "story":
                            GameManager.GameManagerInstance.setActiveCanvas("cnvStory");
                            strResult = logicForDisplay();
                            break;
                        case "inventory":
                            GameManager.GameManagerInstance.setActiveCanvas("cnvInventory");
                            break;
                        case "map":
                            GameManager.GameManagerInstance.setActiveCanvas("cnvMap");
                            break;
                    }

                    //call function from scene inherited scene object, two types of scenes
                    // yes/no scene
                    // pickup item scene

                    // yes/no displays different text upon yes or no
                    // pick up simply places item in your inventory array

                    //if (GameManager.instance.activeCanvas == cnvStory)

                    display(strResult);
                    break;
                default:
                    Debug.Log("Do not understand");
                    strResult = "Do not understand";
                    break;

            }// end switch
        }
        // return strResult;

    }// Parse

    //changes visited flag
    private static void setVisitedToTrueIfFirstTime()
    {
        if (GameModel.CurrentPlayer.CurrentArea.Visited != true)
        {
            GameModel.CurrentPlayer.CurrentArea.Visited = true;
        }
    }

    //logic for the story text output
    private static string logicForDisplay()
    {
        string strResult;
        if (GameModel.CurrentPlayer.CurrentArea.Visited != true & GameModel.CurrentPlayer.CurrentArea.AreaObject == null)
        {
            
            strResult = GameModel.CurrentPlayer.CurrentArea.DcStory["defaultFirstVisit"];
            strResult = strResult + DisplayDecisions();
        }
        else if (GameModel.CurrentPlayer.CurrentArea.AreaObject == null & GameModel.CurrentPlayer.CurrentArea.Visited == true)
        {
            strResult = GameModel.CurrentPlayer.CurrentArea.DcStory["default"];
            strResult = strResult + DisplayDecisions();
        }
        else if (GameModel.CurrentPlayer.CurrentArea.AreaObject != null)
        {
            strResult = GameModel.CurrentPlayer.CurrentArea.DcStory["prePickup"];
            strResult = strResult + DisplayDecisions();
        }
        else
        {
            strResult = "Something is broken with the logicForDisplay() method.";
            strResult = strResult + DisplayDecisions();
        }
        return strResult;
    }

    //logic for the text pertaining to what actions you can make and directions you can go in
    public static string DisplayDecisions()
    {

        string decisionOutput = "\n" + "\n" + "You can make these decisions:" + "\n";
        foreach (Action action in GameModel.CurrentPlayer.CurrentArea.LstDecisions)
        {
            decisionOutput = decisionOutput + "\n" + action.returnDisplayName();
        }

        decisionOutput = decisionOutput + "\n" + "\n" + "Possible Direction:";

        if (GameModel.CurrentPlayer.CurrentArea.North != null)
        {
            decisionOutput = decisionOutput + "\n" + "go north";
        }

        if (GameModel.CurrentPlayer.CurrentArea.South != null)
        {
            decisionOutput = decisionOutput + "\n" + "go south";
        }

        if (GameModel.CurrentPlayer.CurrentArea.East != null)
        {
            decisionOutput = decisionOutput + "\n" + "go east";
        }

        if (GameModel.CurrentPlayer.CurrentArea.West != null)
        {
            decisionOutput = decisionOutput + "\n" + "go west";
        }

        return decisionOutput;
    }
}


