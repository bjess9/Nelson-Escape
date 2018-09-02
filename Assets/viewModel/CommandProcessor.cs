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

        //List index[0] = text if no SceneObject is present
        //List index[1] = text after SceneObject is picked up
        //List index[2] = text if a SceneObject is present
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
                        if (GameModel.CurrentPlayer.CurrentScene.SceneObject != null)
                        {
                            strResult = GameModel.CurrentPlayer.CurrentScene.LstStory[1];
                            GameModel.Pickup(GameModel.CurrentPlayer.CurrentScene.SceneObject);
                            GameModel.RemoveItemFromScene(GameModel.CurrentPlayer.CurrentScene.SceneObject);
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
                            if (GameModel.CurrentPlayer.CurrentScene.SceneObject == null)
                            {
                                strResult = GameModel.CurrentPlayer.CurrentScene.LstStory[0];
                            }
                            else
                            {
                                strResult = GameModel.CurrentPlayer.CurrentScene.LstStory[2];
                            }
                            break;
                        case "south":
                            Debug.Log("Got go South");
                            GameModel.go(GameModel.DIRECTION.South);
                            if (GameModel.CurrentPlayer.CurrentScene.SceneObject == null)
                            {
                                strResult = GameModel.CurrentPlayer.CurrentScene.LstStory[0];
                            }
                            else
                            {
                                strResult = GameModel.CurrentPlayer.CurrentScene.LstStory[2];
                            }
                            break;
                        case "east":
                            Debug.Log("Got go East");
                            GameModel.go(GameModel.DIRECTION.East);
                            if (GameModel.CurrentPlayer.CurrentScene.SceneObject == null)
                            {
                                strResult = GameModel.CurrentPlayer.CurrentScene.LstStory[0];
                            }
                            else
                            {
                                strResult = GameModel.CurrentPlayer.CurrentScene.LstStory[2];
                            }
                            break;
                        case "west":
                            Debug.Log("Got go West");
                            GameModel.go(GameModel.DIRECTION.West);
                            if (GameModel.CurrentPlayer.CurrentScene.SceneObject == null)
                            {
                                strResult = GameModel.CurrentPlayer.CurrentScene.LstStory[0];
                            }
                            else
                            {
                                strResult = GameModel.CurrentPlayer.CurrentScene.LstStory[2];
                            }
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
}


