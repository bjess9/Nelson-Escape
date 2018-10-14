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
                        lcStrResult = "Nothing to pick up.";
                        Debug.Log("Got Pick up");

                        foreach (Item lcItem in prCurrentPlayer._currentArea.areaElements)
                        {
                            Pickup.PickupItem(prCurrentPlayer, lcItem);
                            if (prCurrentPlayer._currentArea.areaElements.Count == 0)
                            {
                                break;
                            }
                        }

                        //adds displaydecisions result to current output 
                        lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
                    }
                    
                    break;
                case "go":
                    switch (lcParts[1])
                    {
                        case "north":
                            lcDebugText = "Got go North";
                            SetVisitedToTrueIfFirstTime(prCurrentPlayer);
                            ////only attempts to go north if there is an area connected to the north direction
                            //if (prCurrentPlayer._currentArea._connectedAreas[(int)DIRECTION.North] != null)
                            //{
                            //    GameManager.GameManagerInstance.GameModelInstance.Go(DIRECTION.North);
                            //    lcStrResult = StoryDisplay(prCurrentPlayer);
                            //}
                            if (prCurrentPlayer._currentArea.North != null)
                            {
                                GameManager.GameManagerInstance.GameModelInstance.Go(DIRECTION.North);
                                lcStrResult = StoryDisplay(prCurrentPlayer);
                            }
                            else
                            {
                                lcStrResult = "You can't go in that direction";
                            }

                            break;
                        case "south":
                            lcDebugText = "Got go South";
                            SetVisitedToTrueIfFirstTime(prCurrentPlayer);
                            if (prCurrentPlayer._currentArea.South != null)
                            {
                                GameManager.GameManagerInstance.GameModelInstance.Go(DIRECTION.South);
                                lcStrResult = StoryDisplay(prCurrentPlayer);
                            }
                            else
                            {
                                lcStrResult = "You can't go in that direction";
                            }

                            break;
                        case "east":
                            lcDebugText = "Got go East";
                            SetVisitedToTrueIfFirstTime(prCurrentPlayer);
                            if (prCurrentPlayer._currentArea.East != null)
                            {
                                GameManager.GameManagerInstance.GameModelInstance.Go(DIRECTION.East);
                                lcStrResult = StoryDisplay(prCurrentPlayer);
                            }
                            else
                            {
                                lcStrResult = "You can't go in that direction";
                            }

                            break;
                        case "west":
                            lcDebugText = "Got go West";
                            SetVisitedToTrueIfFirstTime(prCurrentPlayer);
                            if (prCurrentPlayer._currentArea.West != null)
                            {
                                GameManager.GameManagerInstance.GameModelInstance.Go(DIRECTION.West);
                                lcStrResult = StoryDisplay(prCurrentPlayer);
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
                            lcStrResult = StoryDisplay(prCurrentPlayer);
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
                    firebaseManager.FirebaseManagerInstance.SavePlayerJSON(
                        firebaseManager.FirebaseManagerInstance.UID,
                        prCurrentPlayer._email,
                        prCurrentPlayer._username,
                        prCurrentPlayer._lstInventory,
                        prCurrentPlayer._currentArea,
                        prCurrentPlayer.christChurchSteps,
                        prCurrentPlayer.starbucks,
                        prCurrentPlayer.NMIT,
                        prCurrentPlayer.newWorld,
                        prCurrentPlayer.stateCinemas
                        
                        );
                    lcDebugText = "Game saved.";
                    break;

                //case "load"://loading previously saved game state
                //    saveLoad lcLoadInstance = new saveLoad();
                //    lcLoadInstance.Load();
                //    lcStrResult = StoryDisplay(prCurrentPlayer);
                //    lcLoadInstance = null;
                //    break;
                default:
                    lcDebugText = "Do not understand";
                    lcStrResult = "Do not understand";
                    break;

            }// end switch
        }
        
        if (lcStrResult == "Do not understand")
        {
            lcStrResult = lcStrResult + "\n" + "\n" + StoryDisplay(prCurrentPlayer);
        }
        string[] lcOutput = { lcStrResult, lcDebugText };
        return lcOutput;

    }// Parse

    //changes visited flag
    private static void SetVisitedToTrueIfFirstTime(Player prCurrentPlayer)
    {
        if (prCurrentPlayer._currentArea.visited != true)
        {
            prCurrentPlayer._currentArea.visited = true;
        }
    }

    //logic for the story text output
    public static string StoryDisplay(Player prCurrentPlayer)
    {
        string lcStrResult = "Couldn't find story, check StoryDisplay Method";

        //no item or npc in area
        if (prCurrentPlayer._currentArea.visited != true & prCurrentPlayer._currentArea.areaElements.Count == 0)
        {
            lcStrResult = prCurrentPlayer._currentArea._story._defaultFirstVisit;
            lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
        }
        else if (prCurrentPlayer._currentArea.areaElements.Count == 0 & prCurrentPlayer._currentArea.visited == true)
        {
            lcStrResult = prCurrentPlayer._currentArea._story._default;
            lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
        }
        else if (prCurrentPlayer._currentArea.areaElements != null)
        {
            //bool lcFoundElementFlag = false;
            foreach(Element lcElement in prCurrentPlayer._currentArea.areaElements)
            {
                if (lcElement is Item)
                {
                    lcStrResult = prCurrentPlayer._currentArea.dcStory["prePickup"];
                    lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
                    //lcFoundElementFlag = true;
                    break;
                }
                else if (lcElement is NPC)
                {
                    //link to story text for monster encounter here
                    lcStrResult = prCurrentPlayer._currentArea.dcStory["prePickup"];
                    lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
                    break;
                }
                else
                {
                    lcStrResult = "Cant find story text for element(s) in AreaElements";
                    lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
                    break;
                }
            }
        }
        else
        {
            lcStrResult = "Something is broken with the logicForDisplay() method.";
            lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
        }
        return lcStrResult;
    }

    //logic for the text pertaining to what actions you can make and directions you can go in
    public static string AvailableActions(Player prCurrentPlayer)
    {

        string lcDecisionOutput = "\n" + "\n" + "You can make these decisions:" + "\n" + "\n";
        foreach (Element lcElement in prCurrentPlayer._currentArea.areaElements)
        {
            if (lcElement is Item)
            {
                lcDecisionOutput = lcDecisionOutput + "Pick up" + "\n" + "-------------------" + "\n";
               foreach (Element lcElement2 in prCurrentPlayer._currentArea.areaElements)
                {
                    if (lcElement is NPC)
                    {
                        lcDecisionOutput = lcDecisionOutput + "Attack" + "\n" + "-------------------" + "\n" + "Flee" + "\n" + "-------------------" + "\n";
                    }
                }
            }
            if (lcElement is NPC)
            {
                lcDecisionOutput = lcDecisionOutput + "Attack" + "\n" + "-------------------" + "\n" + "Flee" + "\n" + "-------------------" + "\n";
                foreach (Element lcElement2 in prCurrentPlayer._currentArea.areaElements)
                {
                    if (lcElement is Item)
                    {
                        lcDecisionOutput = lcDecisionOutput + "Pick up" + "\n" + "-------------------" + "\n";
                    }
                }
            }
        }
        
        lcDecisionOutput = lcDecisionOutput + "\n" + "\n" + "Possible Directions:";

        //turn into loop
        if (prCurrentPlayer._currentArea.North != null)
        {
            lcDecisionOutput = lcDecisionOutput + "\n" + "go north";
        }

        if (prCurrentPlayer._currentArea.South != null)
        {
            lcDecisionOutput = lcDecisionOutput + "\n" + "go south";
        }

        if (prCurrentPlayer._currentArea.East != null)
        {
            lcDecisionOutput = lcDecisionOutput + "\n" + "go east";
        }

        if (prCurrentPlayer._currentArea.West != null)
        {
            lcDecisionOutput = lcDecisionOutput + "\n" + "go west";
        }

        return lcDecisionOutput;
    }
}


