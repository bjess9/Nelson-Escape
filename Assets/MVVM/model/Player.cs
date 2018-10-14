using System;
using System.Collections.Generic;

[Serializable]
public class Player
{
    // Class
    private static int _playerNumber = 0;

    // Instance
    private int _number = (Player._playerNumber++);

    public string _email;
    public string _username; //default name before login implemented

    // list of items in the players inventory
    public List<Item> _lstInventory = new List<Item>();

    //current area
    public Area _currentArea;

    public Area christChurchSteps;
    public Area starbucks;
    public Area NMIT;
    public Area newWorld;
    public Area stateCinemas;
    //private Boolean caffeinated = false;

    public Player( string prEmail, string prName, List<Item> prInventory, Area prCurrentArea)
    {
        _email = prEmail;
        _username = prName;
        _lstInventory = prInventory;
        _currentArea = prCurrentArea;
    }

    //public Area CurrentArea
    //{
    //    get
    //    {
    //        return _currentArea;
    //    }
    //    set
    //    {
    //        _currentArea = value;
    //    }
    //}

    //public String Name
    //{
    //    get
    //    {
    //        return _name;
    //    }
    //    set
    //    {
    //        _name = value;
    //    }
    //}

    //public bool Caffeinated
    //{
    //    get
    //    {
    //        return caffeinated;
    //    }

    //    set
    //    {
    //        caffeinated = value;
    //    }
    //}

    //public List<Item> LstInventory
    //{
    //    get
    //    {
    //        return _lstInventory;
    //    }

    //    set
    //    {
    //        _lstInventory = value;
    //    }
    //}

    //public string Email
    //{
    //    get
    //    {
    //        return _email;
    //    }

    //    set
    //    {
    //        _email = value;
    //    }
    //}

    //moving players current area
    public void Move(DIRECTION pDirection)
    {
        switch (pDirection)
        {
            case DIRECTION.North:

                if (_currentArea.North == "starbucks")
                {
                    _currentArea = starbucks;
                }
                else if (_currentArea.North == "christChurchSteps")
                {
                    _currentArea = christChurchSteps;
                }
                else if (_currentArea.North == "NMIT")
                {
                    _currentArea = NMIT;
                }
                else if (_currentArea.North == "newWorld")
                {
                    _currentArea = newWorld;
                }
                else if (_currentArea.North == "stateCinemas")
                {
                    _currentArea = stateCinemas;
                }

                //if (_currentArea._connectedAreas[(int)DIRECTION.North] != null)
                //{
                //    _currentArea = _currentArea._connectedAreas[(int)DIRECTION.North];
                //}
                break;
            case DIRECTION.South:
                if (_currentArea.South == "starbucks")
                {
                    _currentArea = starbucks;
                }
                else if (_currentArea.South == "christChurchSteps")
                {
                    _currentArea = christChurchSteps;
                }
                else if (_currentArea.South == "NMIT")
                {
                    _currentArea = NMIT;
                }
                else if (_currentArea.South == "newWorld")
                {
                    _currentArea = newWorld;
                }
                else if (_currentArea.South == "stateCinemas")
                {
                    _currentArea = stateCinemas;
                }
                break;
            case DIRECTION.East:
                if (_currentArea.East == "starbucks")
                {
                    _currentArea = starbucks;
                }
                else if (_currentArea.East == "christChurchSteps")
                {
                    _currentArea = christChurchSteps;
                }
                else if (_currentArea.East == "NMIT")
                {
                    _currentArea = NMIT;
                }
                else if (_currentArea.East == "newWorld")
                {
                    _currentArea = newWorld;
                }
                else if (_currentArea.East == "stateCinemas")
                {
                    _currentArea = stateCinemas;
                }
                break;
            case DIRECTION.West:
                if (_currentArea.West == "starbucks")
                {
                    _currentArea = starbucks;
                }
                else if (_currentArea.West == "christChurchSteps")
                {
                    _currentArea = christChurchSteps;
                }
                else if (_currentArea.West == "NMIT")
                {
                    _currentArea = NMIT;
                }
                else if (_currentArea.West == "newWorld")
                {
                    _currentArea = newWorld;
                }
                else if (_currentArea.West == "stateCinemas")
                {
                    _currentArea = stateCinemas;
                }
                break;
        }
    }
}


