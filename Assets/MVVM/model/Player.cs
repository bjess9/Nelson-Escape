using System;
using System.Collections.Generic;

[Serializable]
public class Player
{
    //houses player information that temporarily exists in the game & doesnt need to be stored in the db.


    public string _email;
    public string _username; //not in use yet

    #region Commented out code
    //// Class
    //private static int _playerNumber = 0;

    //// Instance
    //private int _number = (Player._playerNumber++);

    //current area
    //public Area _currentArea;

    //public Area christChurchSteps;
    //public Area starbucks;
    //public Area NMIT;
    //public Area newWorld;
    //public Area stateCinemas;
    //private Boolean caffeinated = false;
    #endregion

    public Player( string prEmail, string prName)
    {
        _email = prEmail;
        _username = prName;
    }

    #region Commented out code
    //public void Move(DIRECTION pDirection)
    //{
    //    switch (pDirection)
    //    {
    //        case DIRECTION.North:

    //            if (_currentArea.North == "starbucks")
    //            {
    //                _currentArea = starbucks;
    //            }
    //            else if (_currentArea.North == "christChurchSteps")
    //            {
    //                _currentArea = christChurchSteps;
    //            }
    //            else if (_currentArea.North == "NMIT")
    //            {
    //                _currentArea = NMIT;
    //            }
    //            else if (_currentArea.North == "newWorld")
    //            {
    //                _currentArea = newWorld;
    //            }
    //            else if (_currentArea.North == "stateCinemas")
    //            {
    //                _currentArea = stateCinemas;
    //            }

    //            //if (_currentArea._connectedAreas[(int)DIRECTION.North] != null)
    //            //{
    //            //    _currentArea = _currentArea._connectedAreas[(int)DIRECTION.North];
    //            //}
    //            break;
    //        case DIRECTION.South:
    //            if (_currentArea.South == "starbucks")
    //            {
    //                _currentArea = starbucks;
    //            }
    //            else if (_currentArea.South == "christChurchSteps")
    //            {
    //                _currentArea = christChurchSteps;
    //            }
    //            else if (_currentArea.South == "NMIT")
    //            {
    //                _currentArea = NMIT;
    //            }
    //            else if (_currentArea.South == "newWorld")
    //            {
    //                _currentArea = newWorld;
    //            }
    //            else if (_currentArea.South == "stateCinemas")
    //            {
    //                _currentArea = stateCinemas;
    //            }
    //            break;
    //        case DIRECTION.East:
    //            if (_currentArea.East == "starbucks")
    //            {
    //                _currentArea = starbucks;
    //            }
    //            else if (_currentArea.East == "christChurchSteps")
    //            {
    //                _currentArea = christChurchSteps;
    //            }
    //            else if (_currentArea.East == "NMIT")
    //            {
    //                _currentArea = NMIT;
    //            }
    //            else if (_currentArea.East == "newWorld")
    //            {
    //                _currentArea = newWorld;
    //            }
    //            else if (_currentArea.East == "stateCinemas")
    //            {
    //                _currentArea = stateCinemas;
    //            }
    //            break;
    //        case DIRECTION.West:
    //            if (_currentArea.West == "starbucks")
    //            {
    //                _currentArea = starbucks;
    //            }
    //            else if (_currentArea.West == "christChurchSteps")
    //            {
    //                _currentArea = christChurchSteps;
    //            }
    //            else if (_currentArea.West == "NMIT")
    //            {
    //                _currentArea = NMIT;
    //            }
    //            else if (_currentArea.West == "newWorld")
    //            {
    //                _currentArea = newWorld;
    //            }
    //            else if (_currentArea.West == "stateCinemas")
    //            {
    //                _currentArea = stateCinemas;
    //            }
    //            break;
    //    }
    //}
    #endregion
}


