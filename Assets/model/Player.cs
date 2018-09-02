using System;
using System.Collections.Generic;

public class Player
{
    // Class
    private static int _player_number = 0;

    // Instance
    private int _number = (Player._player_number++);
    private string _name;
    private List<Item> _lstInventory = new List<Item>();   
    private Scene _currentScene;
    private Boolean caffeinated = false;


    public Scene CurrentScene
    {
        get
        {
            return _currentScene;
        }
        set
        {
            _currentScene = value;
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

                if (_currentScene.North != null)
                {
                    _currentScene = _currentScene.North;
                }
                break;
            case GameModel.DIRECTION.South:
                if (_currentScene.South != null)
                {
                    _currentScene = _currentScene.South;
                }
                break;
            case GameModel.DIRECTION.East:
                if (_currentScene.East != null)
                {
                    _currentScene = _currentScene.East;
                }
                break;
            case GameModel.DIRECTION.West:
                if (_currentScene.West != null)
                {
                    _currentScene = _currentScene.West;
                }
                break;
        }
    }
    public Player()
    {
    }
}


