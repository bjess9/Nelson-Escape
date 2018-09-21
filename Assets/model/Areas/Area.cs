using System;
using System.Collections.Generic;

[Serializable]
public abstract class Area
{
    //Code responsible for general area variables and behaviours


    //private Players _players = new Players();

    //areas connected to the current area object
    private Area[] _connectedAreas = new Area[4];

    //story text for the current area object
    private Dictionary<string, string> dcStory = new Dictionary<string, string>();

    //list of action classes included with the area object
    private List<PlayerAction> lstDecisions = new List<PlayerAction>();

    //visited flag to have customer text for first and following visits
    private bool visited = false;

    //un-instantiated classes that will be instantiated within the area object if applicable to the area
    private Item _areaObject;
    private Pickup _actionPickup;

    public Area North
    {
        get
        {
            return _connectedAreas[(int)GameModel.DIRECTION.North];
        }
        set
        {
            _connectedAreas[(int)GameModel.DIRECTION.North] = value;
        }
    }

    public Area South
    {
        get
        {
            return _connectedAreas[(int)GameModel.DIRECTION.South];
        }
        set
        {
            _connectedAreas[(int)GameModel.DIRECTION.South] = value;
        }
    }

    public Area East
    {
        get
        {
            return _connectedAreas[(int)GameModel.DIRECTION.East];
        }
        set
        {
            _connectedAreas[(int)GameModel.DIRECTION.East] = value;
        }
    }

    public Area West
    {
        get
        {
            return _connectedAreas[(int)GameModel.DIRECTION.West];
        }
        set
        {
            _connectedAreas[(int)GameModel.DIRECTION.West] = value;
        }
    }

    public Item AreaObject
    {
        get
        {
            return _areaObject;
        }

        set
        {
            _areaObject = value;
        }
    }

    public Dictionary<string, string> DcStory
    {
        get
        {
            return dcStory;
        }

        set
        {
            dcStory = value;
        }
    }

    public List<PlayerAction> LstDecisions
    {
        get
        {
            return lstDecisions;
        }

        set
        {
            lstDecisions = value;
        }
    }

    public Pickup ActionPickup
    {
        get
        {
            return _actionPickup;
        }

        set
        {
            _actionPickup = value;
        }
    }

    public bool Visited
    {
        get
        {
            return visited;
        }

        set
        {
            visited = value;
        }
    }
}


