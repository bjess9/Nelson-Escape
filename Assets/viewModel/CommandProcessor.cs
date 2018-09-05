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
    // AREA ABSTRACT
    // EACH AREA HAS ITS OWN INHERITED CLASS
    // STORY IN INHERITED CLASS, ALLOWS FOR MORE FLEXIBILITY
    // AREA OBJECT HANDS STORY BACK TO COMMANDPROCESS

    public static string DisplayDecisions()
    {
        string decisionOutput = "\n" + "\n" + "You can make these decisions:" + "\n";
        foreach (Action action in GameModel.CurrentPlayer.CurrentArea.DcDecisions)
        {
            decisionOutput = decisionOutput + "\n" + Action.DisplayName;
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

    public void Parse(String pCmdStr, aDisplayer display)
    {

        String strResult = "Do not understand";

        char[] charSeparators = new char[] { ' ' };
        pCmdStr = pCmdStr.ToLower();
        String[] parts = pCmdStr.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries); // tokenise the command

        if (parts.Length > 0)
        {

            // process the tokens
            switch (parts[0])
            {
                case "pick":
                    if (parts[1] == "up")
                    {
                        Debug.Log("Got Pick up");
                        if (GameModel.CurrentPlayer.CurrentArea.AreaObject != null)
                        {
                            strResult = GameModel.CurrentPlayer.CurrentArea.DcStory["postPickup"];

                            foreach (Action action in GameModel.CurrentPlayer.CurrentArea.DcDecisions)
                                if (Action.DisplayName == "pick up")
                                {
                                    GameModel.CurrentPlayer.CurrentArea.DcDecisions.Remove(action);
                                }

                            strResult = strResult + DisplayDecisions();
                            Pickup.pickupItem();
                        }
                        else
                        {
                            strResult = "There is nothing to pick up";
                        }

                        if (parts.Length == 3)
                        {
                            String param = parts[2];
                        }// do pick up command
                    }
                    display(strResult);
                    break;
                case "go":
                    switch (parts[1])
                    {
                        case "north":
                            Debug.Log("Got go North");
                            GameModel.go(GameModel.DIRECTION.North);
                            strResult = logicForDisplay();
                            break;
                        case "south":
                            Debug.Log("Got go South");
                            GameModel.go(GameModel.DIRECTION.South);
                            strResult = logicForDisplay();
                            break;
                        case "east":
                            Debug.Log("Got go East");
                            GameModel.go(GameModel.DIRECTION.East);
                            strResult = logicForDisplay();
                            break;
                        case "west":
                            Debug.Log("Got go West");
                            GameModel.go(GameModel.DIRECTION.West);
                            strResult = logicForDisplay();
                            break;
                        default:
                            Debug.Log(" do not know how to go there");
                            strResult = "Do not know how to go there";
                            break;

                    }
                    display(strResult);
                    break;
                case "show":
                    switch (parts[1])
                    {
                        case "story":
                            GameManager.instance.setActiveCanvas("cnvStory");
                            break;
                        case "inventory":
                            GameManager.instance.setActiveCanvas("cnvInventory");
                            break;
                        case "map":
                            GameManager.instance.setActiveCanvas("cnvMap");
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

    private static string logicForDisplay()
    {
        string strResult;
        if (GameModel.CurrentPlayer.CurrentArea.AreaObject == null)
        {
            strResult = GameModel.CurrentPlayer.CurrentArea.DcStory["default"];
            strResult = strResult + DisplayDecisions();
        }
        else
        {
            strResult = GameModel.CurrentPlayer.CurrentArea.DcStory["prePickup"];
            strResult = strResult + DisplayDecisions();
        }

        return strResult;
    }
}


