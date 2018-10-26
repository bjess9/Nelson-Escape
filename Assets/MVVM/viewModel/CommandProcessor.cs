using System;
using UnityEngine;

public delegate void aDisplayer(String prValue);

public class CommandProcessor
{
    DataService DataServiceInstance = GameManager.GameManagerInstance.GameModelInstance.DataServiceInstance;

    /// <summary>
    /// used to parse text input into the various game commands available within this processor
    /// </summary>
    /// <param name="prCmdStr"></param>
    /// <param name="prCurrentPlayer"></param>
    /// <returns>string result for display on the story screen</returns>
    public string[] Parse(String prCmdStr, Player prCurrentPlayer)
    {
        string lcDebugText = "";

        if (String.IsNullOrEmpty(prCmdStr) == true)
        {
            string lcStrResult = "";
            string lcStory = DataServiceInstance.GetStory(prCurrentPlayer._email);
            lcStrResult = lcStrResult + "\n" + "\n" + lcStory;
            lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);

            string[] lcOutput = { lcStrResult, lcDebugText };

            return lcOutput;
        }
        else
        {
            // default display
            string lcStrResult = "Do not understand";

            //seperating input by spaces and putting into an array for processing
            char[] lcCharSeparators = new char[] { ' ' };
            prCmdStr = prCmdStr.ToLower();
            String[] lcParts = prCmdStr.Split(lcCharSeparators, StringSplitOptions.RemoveEmptyEntries); // tokenise the command

            if (lcParts.Length > 1)
            {

                switch (lcParts[0])
                {//first condition logic
                    case "pick":
                        if (lcParts[1] == "up")
                        {
                            lcStrResult = "Nothing to pick up.";
                            Debug.Log("Got Pick up");

                            //take item from AreaItem and put into Inventory
                            bool lcPickupResult = DataServiceInstance.AddItemToInven(prCurrentPlayer._email);
                            bool lcDeleteResult = DataServiceInstance.DeleteAreaItem(prCurrentPlayer._email);
                            if (lcPickupResult == true && lcDeleteResult == true)
                            {
                                //get post pickup text and add to lcstrresult
                                string lcStory = DataServiceInstance.GetPostPickupStory(prCurrentPlayer._email);
                                lcStrResult = lcStory;
                            }
                            else
                            {
                                Debug.Log("Error picking up.");
                            }

                            //adds displaydecisions result to current output 
                            lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
                        }

                        break;
                    case "go":
                        //movement case, moves in specified direction
                        switch (lcParts[1])
                        {
                            case "north":
                                lcDebugText = "Got go North";

                                bool lcNorthResult = DataServiceInstance.Move(DIRECTION.North, prCurrentPlayer._email);

                                if (lcNorthResult == true)
                                {
                                    string lcStory = DataServiceInstance.GetStory(prCurrentPlayer._email);
                                    lcStrResult = lcStory;
                                }
                                else
                                {
                                    lcStrResult = "Can't move in that direction.";
                                }
                                lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
                                break;
                            case "south":
                                lcDebugText = "Got go South";
                                bool lcSouthResult = DataServiceInstance.Move(DIRECTION.South, prCurrentPlayer._email);

                                if (lcSouthResult == true)
                                {
                                    string lcStory = DataServiceInstance.GetStory(prCurrentPlayer._email);
                                    lcStrResult = lcStory;
                                }
                                else
                                {
                                    lcStrResult = "Can't move in that direction.";
                                }
                                lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
                                break;
                            case "east":
                                lcDebugText = "Got go East";
                                bool lcEastResult = DataServiceInstance.Move(DIRECTION.East, prCurrentPlayer._email);

                                if (lcEastResult == true)
                                {
                                    string lcStory = DataServiceInstance.GetStory(prCurrentPlayer._email);
                                    lcStrResult = lcStory;
                                }
                                else
                                {
                                    lcStrResult = "Can't move in that direction.";
                                }
                                lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
                                break;
                            case "west":
                                lcDebugText = "Got go West";
                                bool lcWestResult = DataServiceInstance.Move(DIRECTION.West, prCurrentPlayer._email);

                                if (lcWestResult == true)
                                {
                                    string lcStory = DataServiceInstance.GetStory(prCurrentPlayer._email);
                                    lcStrResult = lcStory;
                                }
                                else
                                {
                                    lcStrResult = "Can't move in that direction.";
                                }
                                lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
                                break;
                            default:
                                lcDebugText = " do not know how to go there";
                                lcStrResult = "Do not know how to go there";
                                lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
                                break;

                        }

                        break;
                    case "show"://shows canvas using text input
                        switch (lcParts[1])
                        {

                            case "story":
                                GameManager.GameManagerInstance.SetActiveCanvas("cnvStory");
                                string lcStory = DataServiceInstance.GetStory(prCurrentPlayer._email);
                                lcStrResult = lcStory;
                                lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
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
                                //firebaseManager.FirebaseManagerInstance.SavePlayerJSON(
                                //    firebaseManager.FirebaseManagerInstance.UID,
                                //    prCurrentPlayer._email,
                                //    prCurrentPlayer._username,
                                //    prCurrentPlayer._lstInventory,
                                //    prCurrentPlayer._currentArea,
                                //    prCurrentPlayer.christChurchSteps,
                                //    prCurrentPlayer.starbucks,
                                //    prCurrentPlayer.NMIT,
                                //    prCurrentPlayer.newWorld,
                                //    prCurrentPlayer.stateCinemas

                        //    );
                        lcDebugText = "Game not saved. (saving disabled for this milestone due to data being writted to db consistently)";
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
                //runs this if no existing command conditions were met
                string lcStory = DataServiceInstance.GetStory(prCurrentPlayer._email);
                lcStrResult = lcStrResult + "\n" + "\n" + lcStory;
                lcStrResult = lcStrResult + AvailableActions(prCurrentPlayer);
            }
            string[] lcOutput = { lcStrResult, lcDebugText };
            return lcOutput;
        }
    }// Parse

    /// <summary>
    /// logic for the text pertaining to what actions you can make and directions you can go in
    /// </summary>
    /// <param name="prCurrentPlayer"></param>
    /// <returns>returns string result that lists the available actions the player can make in the current area</returns>
    public static string AvailableActions(Player prCurrentPlayer)
    {
        DataService DataServiceInstance = GameManager.GameManagerInstance.GameModelInstance.DataServiceInstance;

        string lcDecisionOutput = "\n" + "\n" + "You can make these decisions:" + "\n" + "\n";

        bool lcContainsItem = DataServiceInstance.GetAreaItem(prCurrentPlayer);
        if (lcContainsItem == true)
        {
            lcDecisionOutput = lcDecisionOutput + "Pick up" + "\n" + "-------------------" + "\n";
        }

        //bool lcContainsNPC = DataServiceInstance.GetNPC(prCurrentPlayer);
        //if (lcContainsNPC == true)
        //{
        //    lcDecisionOutput = lcDecisionOutput + "Attack" + "\n" + "-------------------" + "\n" + "Bribe" + "\n" + "-------------------" + "\n";
        //    //lcDecisionOutput = lcDecisionOutput + 
        //}

        lcDecisionOutput = lcDecisionOutput + "\n" + "\n" + "Possible Directions:";

        string lcDirectionsPossible = DataServiceInstance.GetDirectionsPossible(prCurrentPlayer);

        lcDecisionOutput = lcDecisionOutput + lcDirectionsPossible;

        return lcDecisionOutput;
    }
}


