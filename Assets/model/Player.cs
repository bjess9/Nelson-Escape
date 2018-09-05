﻿using System;
using System.Collections.Generic;

public class Player
{
    // Class
    private static int _player_number = 0;

    // Instance
    private int _number = (Player._player_number++);
    private string _name;
    private List<Item> _lstInventory = new List<Item>();   
    private Area _currentArea;
    private Boolean caffeinated = false;

    public Area CurrentArea
    {
        get
        {
            return _currentArea;
        }
        set
        {
            _currentArea = value;
        }
    }
    public String Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public bool Caffeinated
    {
        get
        {
            return caffeinated;
        }

        set
        {
            caffeinated = value;
        }
    }

    public List<Item> LstInventory
    {
        get
        {
            return _lstInventory;
        }

        set
        {
            _lstInventory = value;
        }
    }

    public void Move(GameModel.DIRECTION pDirection)
    {
        switch (pDirection)
        {
            case GameModel.DIRECTION.North: // but what do we do??

                if (_currentArea.North != null)
                {
                    _currentArea = _currentArea.North;
                }
                break;
            case GameModel.DIRECTION.South:
                if (_currentArea.South != null)
                {
                    _currentArea = _currentArea.South;
                }
                break;
            case GameModel.DIRECTION.East:
                if (_currentArea.East != null)
                {
                    _currentArea = _currentArea.East;
                }
                break;
            case GameModel.DIRECTION.West:
                if (_currentArea.West != null)
                {
                    _currentArea = _currentArea.West;
                }
                break;
        }
    }
    public Player()
    {
    }
}


