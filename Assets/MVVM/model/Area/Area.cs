using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Area
{
    //Code responsible for general area variables and behaviours

    public Story _story = new Story();

    //private Players _players = new Players();

    //private Element[] areaElements = new Element[]();
    public ArrayList areaElements = new ArrayList();

    public string North;
    public string South;
    public string East;
    public string West;

    //story text for the current area object
    public Dictionary<string, string> dcStory = new Dictionary<string, string>();

    //visited flag to have customer text for first and following visits
    public bool visited = false;

    //un-instantiated classes that will be instantiated within the area object if applicable to the area
    //private Item _areaObject;
    //private Pickup _actionPickup;

    //public Area North
    //{
    //    get
    //    {
    //        return _connectedAreas[(int)DIRECTION.North];
    //    }
    //    set
    //    {
    //        _connectedAreas[(int)DIRECTION.North] = value;
    //    }
    //}

    //public Area South
    //{
    //    get
    //    {
    //        return _connectedAreas[(int)DIRECTION.South];
    //    }
    //    set
    //    {
    //        _connectedAreas[(int)DIRECTION.South] = value;
    //    }
    //}

    //public Area East
    //{
    //    get
    //    {
    //        return _connectedAreas[(int)DIRECTION.East];
    //    }
    //    set
    //    {
    //        _connectedAreas[(int)DIRECTION.East] = value;
    //    }
    //}

    //public Area West
    //{
    //    get
    //    {
    //        return _connectedAreas[(int)DIRECTION.West];
    //    }
    //    set
    //    {
    //        _connectedAreas[(int)DIRECTION.West] = value;
    //    }
    //}

    //public Item AreaObject
    //{
    //    get
    //    {
    //        return _areaObject;
    //    }

    //    set
    //    {
    //        _areaObject = value;
    //    }
    //}

    //public Dictionary<string, string> DcStory
    //{
    //    get
    //    {
    //        return dcStory;
    //    }

    //    set
    //    {
    //        dcStory = value;
    //    }
    //}

    //public List<PlayerAction> LstDecisions
    //{
    //    get
    //    {
    //        return lstDecisions;
    //    }

    //    set
    //    {
    //        lstDecisions = value;
    //    }
    //}

    //public Pickup ActionPickup
    //{
    //    get
    //    {
    //        return _actionPickup;
    //    }

    //    set
    //    {
    //        _actionPickup = value;
    //    }
    //}

    //public bool Visited
    //{
    //    get
    //    {
    //        return visited;
    //    }

    //    set
    //    {
    //        visited = value;
    //    }
    //}

    //public ArrayList AreaElements
    //{
    //    get
    //    {
    //        return areaElements;
    //    }

    //    set
    //    {
    //        areaElements = value;
    //    }
    //}
}


