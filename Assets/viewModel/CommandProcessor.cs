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
        String strResult = "Do not understand";

        char[] charSeparators = new char[] { ' ' };
        pCmdStr = pCmdStr.ToLower();
        String[] parts = pCmdStr.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries); // tokenise the command

        // process the tokens
        switch (parts[0])
        {
            case "pick":
                if (parts[1] == "up")
                {
                    Debug.Log("Got Pick up");
                    if (GameModel.CurrentPlayer.CurrentScene.SceneObject != null)
                    {
                        strResult = GameModel.CurrentPlayer.CurrentScene.Text[1];
                        GameModel.Pickup(GameModel.CurrentPlayer.CurrentScene.SceneObject);
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
                break;
            case "go":
                switch (parts[1])
                {
                    case "north":
                        Debug.Log("Got go North");
                        // strResult = "Got Go North";
                        GameModel.go(GameModel.DIRECTION.North);

                        break;
                    case "south":
                        Debug.Log("Got go South");
                        GameModel.go(GameModel.DIRECTION.South);

                        break;
                    case "east":
                        Debug.Log("Got go East");
                        GameModel.go(GameModel.DIRECTION.East);

                        break;
                    case "west":
                        Debug.Log("Got go West");
                        GameModel.go(GameModel.DIRECTION.West);

                        break;
                    default:
                        Debug.Log(" do not know how to go there");
                        strResult = "Do not know how to go there";
                        break;
                }// end switch

                //call function from scene inherited scene object, two types of scenes
                // yes/no scene
                // pickup item scene

                // yes/no displays different text upon yes or no
                // pick up simply places item in your inventory array


                //strResult = GameModel.CurrentPlayer.CurrentScene.Text[0];
                display(strResult);
                break;
            default:
                Debug.Log("Do not understand");
                strResult = "Do not understand";
                break;

        }// end switch

        // return strResult;

    }// Parse
}


