using System;
using System.Collections.Generic;

public class Area
{
    private Players _players = new Players();
    private Area[] _connectedAreas = new Area[4];

    private Dictionary<string, string> dcStory = new Dictionary<string, string>();
    private List<Action> dcDecisions = new List<Action>();
    private Item _areaObject;
    private Pickup actionPickup;

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

    public List<Action> DcDecisions
    {
        get
        {
            return dcDecisions;
        }

        set
        {
            dcDecisions = value;
        }
    }

    public Pickup ActionPickup
    {
        get
        {
            return actionPickup;
        }

        set
        {
            actionPickup = value;
        }
    }

    public Area()
    {
    }
}


