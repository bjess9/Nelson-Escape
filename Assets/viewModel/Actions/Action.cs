using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class PlayerAction
{

    //display name for an action, this is the text that will be displayed to the user in the story
    private static string _displayName;

    public static string DisplayName
    {
        get
        {
            return _displayName;
        }

        set
        {
             _displayName = value;
        }
    }

    public string ReturnDisplayName()
    {
        return _displayName;
    }

    public void SetDisplayName(string prName)
    {
        _displayName = prName;
    }

}
