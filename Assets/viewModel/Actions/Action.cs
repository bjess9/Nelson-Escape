using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{

    //display name for an action, this is the text that will be displayed to the user in the story
    private static string displayName;

    public static string DisplayName
    {
        get
        {
            return displayName;
        }

        set
        {
             displayName = value;
        }
    }

    public string returnDisplayName()
    {
        return displayName;
    }

    public void setDisplayName(string prName)
    {
        displayName = prName;
    }

}
