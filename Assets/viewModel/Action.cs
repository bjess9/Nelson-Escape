using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action  {

    private static readonly string displayName;

    public static string DisplayName
    {
        get
        {
            return displayName;
        }
    }
}
