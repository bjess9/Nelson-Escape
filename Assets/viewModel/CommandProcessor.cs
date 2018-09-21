using System;
using UnityEngine;

public delegate void aDisplayer(String prValue);

public class CommandProcessor
{
    public CommandProcessor()
    {
    }

    public string[] Parse(String prCmdStr, Player prCurrentPlayer)
    {
        // default display
        string lcStrResult = "Do not understand";
        string lcDebugText = "";

        //seperating input by spaces and putting into an array for processing
        char[] lcCharSeparators = new char[] { ' ' };
        prCmdStr = prCmdStr.ToLower();
        String[] lcParts = prCmdStr.Split(lcCharSeparators, StringSplitOptions.RemoveEmptyEntries); // tokenise the command

        if (lcParts.Length > 0)
        {
            switch (lcParts[0])
            {//first condition logic
                case "pick":
                    if (lcParts[1] == "up")
                    {
                        Debug.Log("Got Pick up");
                        if (prCurrentPlayer.CurrentArea.AreaObject != null)
                        {
                            lcStrResult = prCurrentPlayer.CurrentArea.DcStory["postPickup"];

                            //removes pickup action from scene if an object is picked up
                            foreach (PlayerAction lcAction in prCurrentPlayer.CurrentArea.LstDecisions)
                                if (PlayerAction.DisplayName == "pick up")
                                {
                                    prCurrentPlayer.CurrentArea.LstDecisions.Remove(lcAction);
                                    break;
                                }

                            //adds displaydecisions result to current output 
                            lcStrResult = lcStrResult + DisplayDecisions(prCurrentPlayer);

                            //picks up item
                            Pickup.PickupItem(GameManager.GameManagerInstance.GameModelInstance, prCurrentPlayer.CurrentArea);
                        }
                        else
                        {
                            lcStrResult = "There is nothing to pick up";
                            lcStrResult = lcStrResult + LogicForDisplay(prCurrentPlayer);
                        }

                        if (lcParts.Length == 3)
                        {
                            String lcParam = lcParts[2];
                        }
                    }
                    
                    break;
                case "go":
                    switch (lcParts[1])
                    {
                        case "north":
                            lcDebugText = "Got go North";
                            SetVisitedToTrueIfFirstTime(prCurrentPlayer);
                            //only attempts to go north if there is an area connected to the north direction
                            if (prCurrentPlayer.CurrentArea.North != null)
                            {
                                GameManager.GameManagerInstance.GameModelInstance.Go(GameModel.DIRECTION.North);
                                lcStrResult = LogicForDisplay(prCurrentPlayer);
                            }
                            else
                            {
                                lcStrResult = "You can't go in that direction";
                            }

                            break;
                        case "south":
                            lcDebugText = "Got go South";
                            SetVisitedToTrueIfFirstTime(prCurrentPlayer);
                            if (prCurrentPlayer.CurrentArea.South != null)
                            {
                                GameManager.GameManagerInstance.GameModelInstance.Go(GameModel.DIRECTION.South);
                                lcStrResult = LogicForDisplay(prCurrentPlayer);
                            }
                            else
                            {
                                lcStrResult = "You can't go in that direction";
                            }

                            break;
                        case "east":
                            lcDebugText = "Got go East";
                            SetVisitedToTrueIfFirstTime(prCurrentPlayer);
                            if (prCurrentPlayer.CurrentArea.East != null)
                            {
                                GameManager.GameManagerInstance.GameModelInstance.Go(GameModel.DIRECTION.East);
                                lcStrResult = LogicForDisplay(prCurrentPlayer);
                            }
                            else
                            {
                                lcStrResult = "You can't go in that direction";
                            }

                            break;
                        case "west":
                            lcDebugText = "Got go West";
                            SetVisitedToTrueIfFirstTime(prCurrentPlayer);
                            if (prCurrentPlayer.CurrentArea.West != null)
                            {
                                GameManager.GameManagerInstance.GameModelInstance.Go(GameModel.DIRECTION.West);
                                lcStrResult = LogicForDisplay(prCurrentPlayer);
                            }
                            else
                            {
                                lcStrResult = "You can't go in that direction";
                            }
                            break;
                        default:
                            lcDebugText = " do not know how to go there";
                            lcStrResult = "Do not know how to go there";
                            break;

                    }
                    
                    break;
                case "show"://shows canvas using text input
                    switch (lcParts[1])
                    {
                    
                        case "story":
                            GameManager.GameManagerInstance.SetActiveCanvas("cnvStory");
                            lcStrResult = LogicForDisplay(prCurrentPlayer);
                            break;
                        case "inventory":
                            GameManager.GameManagerInstance.SetActiveCanvas("cnvInventory");
                            break;
                        case "map":
                            GameManager.GameManagerInstance.SetActiveCanvas("cnvMap");
                            break;
                    }
                    
                    break;

                case "save"://saving game state
                    saveLoad lcSaveInstance = new saveLoad();
                    lcSaveInstance.Save();
                    lcStrResult = LogicForDisplay(prCurrentPlayer);
                    lcSaveInstance = null;
                    break;

                case "load"://loading previously saved game state
                    saveLoad lcLoadInstance = new saveLoad();
                    lcLoadInstance.Load();
                    lcStrResult = LogicForDisplay(prCurrentPlayer);
                    lcLoadInstance = null;
                    break;
                default:
                    lcDebugText = "Do not understand";
                    lcStrResult = "Do not understand";
                    break;

            }// end switch
        }
        string[] lcOutput = { lcStrResult, lcDebugText };
        return lcOutput;

    }// Parse

    //changes visited flag
    private static void SetVisitedToTrueIfFirstTime(Player prCurrentPlayer)
    {
        if (prCurrentPlayer.CurrentArea.Visited != true)
        {
            prCurrentPlayer.CurrentArea.Visited = true;
        }
    }

    //logic for the story text output
    public static string LogicForDisplay(Player prCurrentPlayer)
    {
        string lcStrResult;
        if (prCurrentPlayer.CurrentArea.Visited != true & prCurrentPlayer.CurrentArea.AreaObject == null)
        {
            
            lcStrResult = prCurrentPlayer.CurrentArea.DcStory["defaultFirstVisit"];
            lcStrResult = lcStrResult + DisplayDecisions(prCurrentPlayer);
        }
        else if (prCurrentPlayer.CurrentArea.AreaObject == null & prCurrentPlayer.CurrentArea.Visited == true)
        {
            lcStrResult = prCurrentPlayer.CurrentArea.DcStory["default"];
            lcStrResult = lcStrResult + DisplayDecisions(prCurrentPlayer);
        }
        else if (prCurrentPlayer.CurrentArea.AreaObject != null)
        {
            lcStrResult = prCurrentPlayer.CurrentArea.DcStory["prePickup"];
            lcStrResult = lcStrResult + DisplayDecisions(prCurrentPlayer);
        }
        else
        {
            lcStrResult = "Something is broken with the logicForDisplay() method.";
            lcStrResult = lcStrResult + DisplayDecisions(prCurrentPlayer);
        }
        return lcStrResult;
    }

    //logic for the text pertaining to what actions you can make and directions you can go in
    public static string DisplayDecisions(Player prCurrentPlayer)
    {

        string lcDecisionOutput = "\n" + "\n" + "You can make these decisions:" + "\n";
        foreach (PlayerAction lcAction in prCurrentPlayer.CurrentArea.LstDecisions)
        {
            lcDecisionOutput = lcDecisionOutput + "\n" + lcAction.ReturnDisplayName();
        }

        
        lcDecisionOutput = lcDecisionOutput + "\n" + "\n" + "Possible Direction:";


        //turn into loop
        if (prCurrentPlayer.CurrentArea.North != null)
        {
            lcDecisionOutput = lcDecisionOutput + "\n" + "go north";
        }

        if (prCurrentPlayer.CurrentArea.South != null)
        {
            lcDecisionOutput = lcDecisionOutput + "\n" + "go south";
        }

        if (prCurrentPlayer.CurrentArea.East != null)
        {
            lcDecisionOutput = lcDecisionOutput + "\n" + "go east";
        }

        if (prCurrentPlayer.CurrentArea.West != null)
        {
            lcDecisionOutput = lcDecisionOutput + "\n" + "go west";
        }

        return lcDecisionOutput;
    }
}


