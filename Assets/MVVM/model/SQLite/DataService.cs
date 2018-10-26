using SQLite4Unity3d;
using System.Linq;
using UnityEngine;

#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif

public class DataService
{
    #region Initialization
    private SQLiteConnection _connection;
    public SQLiteConnection Connection
    {
        get
        {
            return _connection;
        }
    }
    public DataService(string DatabaseName)
    {

#if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);

    }
    #endregion

    /// <summary>
    /// Creates the initial database, this happens upon first launch of the game due to the database not being created yet
    /// </summary>
    /// <param name="prEmail">email address used to identify the player</param>
    #region Database Creation
    public void CreateDB(string prEmail)
    {
        //------------------------------------------------------ Area Table ----------------------------------------------------\\
        _connection.DropTable<TableArea>();
        _connection.CreateTable<TableArea>();

        _connection.InsertAll(new TableArea[]{
            new TableArea{
                AreaName = "christChurchSteps",
                North = "starbucks",
                South = null,
                East = null,
                West = null

            },
            new TableArea{
               AreaName = "starbucks",
                North = "stateCinemas",
                South = "christChurchSteps",
                East = "NMIT",
                West = "newWorld"

            },
            new TableArea{
               AreaName = "newWorld",
                North = null,
                South = null,
                East = "starbucks",
                West = null

            },
            new TableArea{
               AreaName = "NMIT",
                North = null,
                South = null,
                East = null,
                West = "starbucks"

            },
            new TableArea{
               AreaName = "stateCinemas",
                North = null,
                South = "starbucks",
                East = null,
                West = null

            },
               new TableArea{
               AreaName = "randomEncounter",
                North = null,
                South = null,
                East = null,
                West = null

            }
        });

        //------------------------------------------------------ Story Table ----------------------------------------------------\\
        _connection.DropTable<TableStory>();
        _connection.CreateTable<TableStory>();

        _connection.InsertAll(new TableStory[]{

            //christChurchSteps
            new TableStory{
                Phase = "default",
                AreaName = "christChurchSteps",
                Description = "You return to the steps again, nothing to see here"
            },
            new TableStory{
                Phase = "firstVisit",
                AreaName = "christChurchSteps",
                Description = "You wake up on some stone steps in Nelson, you appear to be on the main street.\n\nEnter 'go north' to Begin."
            },

            //starBucks
            new TableStory{
                Phase = "default",
                AreaName = "starbucks",
                Description = "You return to starbucks."
            },
            new TableStory{
                Phase = "firstVisit",
                AreaName = "starbucks",
                Description = "You arrive at starbucks, no money on the ground this time."
            },
            new TableStory{
                Phase = "prePickup",
                AreaName = "starbucks",
                Description = "You arrive at starbucks, you see $5 on the ground."
            },
            new TableStory{
                Phase = "postPickup",
                AreaName = "starbucks",
                Description = "You pick up the moneys, another day another dolla. Where to go from here?"
            },

            //NMIT
            new TableStory{
                Phase = "default",
                AreaName = "NMIT",
                Description = "you return to nmit, decision not implemented yet"
            },
            new TableStory{
                Phase = "firstVisit",
                AreaName = "NMIT",
                Description = "you're at nmit, decision not implemented yet."
            },
            new TableStory{
                Phase = "preDecision",
                AreaName = "NMIT",
                Description = "You walk onto the local polytech ground, searching for someone who might know now to escape this damn city." + "\n" + "Someone approaches you and asks" +
                            "you want to do their SYD survey, do you want to do it? yes/no."
            },
            new TableStory{
                Phase = "postDecisionYes",
                AreaName = "NMIT",
                Description = "YThe student is grateful and gives you a free coffee voucher in return!"
            },
            new TableStory{
                Phase = "postDecisionNo",
                AreaName = "NMIT",
                Description = "You politely decline and realize nobody helpful is here, where to next?"
            },

            //newWorld
            new TableStory{
                Phase = "default",
                AreaName = "newWorld",
                Description = "You return to new world."
            },
            new TableStory{
                Phase = "firstVisit",
                AreaName = "newWorld",
                Description = "new world, no flute on the ground anymore."
            },
            new TableStory{
                Phase = "prePickup",
                AreaName = "newWorld",
                Description = "new world, wow look there's a flute on the ground, enter 'pick up' to pick it up hahahaha"
            },
            new TableStory{
                Phase = "postPickup",
                AreaName = "newWorld",
                Description = "you picked up the flute, you absolute madman, lets get out of here!!"
            },

            //stateCinemas
            new TableStory{
                Phase = "default",
                AreaName = "stateCinemas",
                Description = "you return to state cinemas, decision not implemented yet."
            },
            new TableStory{
                Phase = "firstVisit",
                AreaName = "stateCinemas",
                Description = "you arrive at state cinemas, decision not implemented yet."
            },
            new TableStory{
                Phase = "preDecision",
                AreaName = "stateCinemas",
                Description = "cinemas, they're selling popcorn, do you want to buy? Enter y/n."
            },
            new TableStory{
                Phase = "postDecisionYes",
                AreaName = "stateCinemas",
                Description = "The student is grateful and gives you a free coffee voucher in return!"
            },
            new TableStory{
                Phase = "postDecisionNo",
                AreaName = "stateCinemas",
                Description = "You politely decline and realize nobody helpful is here, where to next?"
            },

            //randomEncounter
            new TableStory{
                Phase = "attack",
                AreaName = "randomEncounter",
                Description = "You attack the monster, landing a blow, it strikes you back in reteliation."
            },
            new TableStory{
                Phase = "bribe",
                AreaName = "randomEncounter",
                Description = "You hand over the $5, the spookyboi gives you the map out in return, upon reading the map you realize if you go back to christ church steps you can escape!"
            },
            new TableStory{
                Phase = "death",
                AreaName = "randomEncounter",
                Description = "The spookyboi strikes you down, you die on the streets of Nelson."
            },
            new TableStory{
                Phase = "defeat",
                AreaName = "randomEncounter",
                Description = "You defeat the spookyboi, it hands over the map. \n After reading it you learn that if you go back to christ church steps you can escape nelson!"
            },
            new TableStory{
                Phase = "firstVisit",
                AreaName = "randomEncounter",
                Description = "You found the spookyboi! Defeat him in order to Win the game and retrieve the map to escape nelson!"
            },
        });

        //------------------------------------------------------ Player Table ----------------------------------------------------\\
        _connection.DropTable<TablePlayer>();
        _connection.CreateTable<TablePlayer>();

        //------------------------------------------------------ Item Table ----------------------------------------------------\\
        _connection.DropTable<TableItem>();
        _connection.CreateTable<TableItem>();

        _connection.InsertAll(new TableItem[]{

            //christChurchSteps
            new TableItem{
                Description = "$5"
            },
            new TableItem{
                Description = "Flute"
            }

            });

        //------------------------------------------------------ AreaItem Table ----------------------------------------------------\\
        _connection.DropTable<TableAreaItem>();
        _connection.CreateTable<TableAreaItem>();

        _connection.InsertAll(new TableAreaItem[]{

            //christChurchSteps
            new TableAreaItem{
                ItemID = 1,
                AreaName = "starbucks",
                Email = prEmail

            },
            new TableAreaItem{
                ItemID = 2,
                AreaName = "newWorld",
                Email = prEmail
            }

            });

        //------------------------------------------------------ Inventory Table ----------------------------------------------------\\
        _connection.DropTable<TableInventory>();
        _connection.CreateTable<TableInventory>();

        //------------------------------------------------------ Visited Table ----------------------------------------------------\\
        _connection.DropTable<TableVisited>();
        _connection.CreateTable<TableVisited>();

        //------------------------------------------------------ NPC Table ----------------------------------------------------\\
        _connection.DropTable<TableNPC>();
        _connection.CreateTable<TableNPC>();
    }
    #endregion

    /// <summary>
    /// Sets players game data to default values
    /// </summary>
    /// <param name="prEmail">email address used to identify the player</param>
    #region New Game
    public void NewGame(string prEmail)
    {
        //remove existing entries for player
        _connection.Query<TableAreaItem>(
        "delete from TableAreaItem"
        + " where TableAreaItem.Email = ?",
        dataBetweenScenesManager.dataBetweenScenesInstance.Email);

        _connection.Query<TableInventory>(
        "delete from TableInventory"
        + " where TableInventory.Email = ?",
        dataBetweenScenesManager.dataBetweenScenesInstance.Email);

        _connection.Query<TableNPC>(
        "delete from TableNPC"
        + " where TableNPC.Email = ?",
        dataBetweenScenesManager.dataBetweenScenesInstance.Email);

        _connection.Query<TableVisited>(
        "delete from TableVisited"
        + " where TableVisited.Email = ?",
        dataBetweenScenesManager.dataBetweenScenesInstance.Email);

        //pull player out
        TablePlayer lcPlayer = _connection.Table<TablePlayer>().Where(x => x.Email == prEmail).FirstOrDefault();

        //update to default values
        lcPlayer.CurrentArea = "christChurchSteps";
        lcPlayer.Health = 10;

        //put back in
        _connection.Update(lcPlayer);

        //insert new entires for area item as default values
        TableAreaItem lcNewAreaItem1 = new TableAreaItem
        {
            ItemID = 1,
            AreaName = "starbucks",
            Email = prEmail
        };

        TableAreaItem lcNewAreaItem2 = new TableAreaItem
        {
            ItemID = 2,
            AreaName = "newWorld",
            Email = prEmail
        };

        TableNPC lcNPC = new TableNPC
        {
            Name = "spookyboi",
            Health = 20,
            Email = prEmail,
            CurrentArea = "stateCinemas"
        };

        _connection.Insert(lcNewAreaItem1);
        _connection.Insert(lcNewAreaItem2);
        _connection.Insert(lcNPC);
    }
    #endregion
    
    #region Move + Get StoryText
    /// <summary>
    /// Attemps to move player in direction specified by parameter
    /// </summary>
    /// <param name="prDirection">Direction passed in by the command processor</param>
    /// <returns>returns true or false dependant on if the move command was successful</returns>
    public bool Move(DIRECTION prDirection, string prEmail)
    {
        
        //get player for current area
        TablePlayer lcPlayer = _connection.Table<TablePlayer>().Where(x => x.Email == prEmail).FirstOrDefault();

        //get area table to check for direction entry
        TableArea lcArea = _connection.Table<TableArea>().Where(x => x.AreaName == lcPlayer.CurrentArea).FirstOrDefault();

        if (prDirection == DIRECTION.North)
        {
            //return false if no north movement found
            if (lcArea.North == null)
            {
                return false;
            }
            else
            {
                //if direction found change current area to the corresponding area in that direction
                //update in database
                //return true
                lcPlayer.CurrentArea = lcArea.North;
                _connection.Update(lcPlayer);
                return true;
            }

        }
        else if (prDirection == DIRECTION.South)
        {
            //return false if no south movement found
            if (lcArea.South == null)
            {
                return false;
            }
            else
            {
                //if direction found chang current area to the corresponding area in that direction
                //update in database
                //return true
                lcPlayer.CurrentArea = lcArea.South;
                _connection.Update(lcPlayer);
                return true;
            }
        }
        else if (prDirection == DIRECTION.East)
        {
            //return false if no East movement found
            if (lcArea.East == null)
            {
                return false;
            }
            else
            {
                //if direction found chang current area to the corresponding area in that direction
                //update in database
                //return true
                lcPlayer.CurrentArea = lcArea.East;
                _connection.Update(lcPlayer);
                return true;
            }
        }
        else if (prDirection == DIRECTION.West)
        {
            //return false if no West movement found
            if (lcArea.West == null)
            {
                return false;
            }
            else
            {
                //if direction found chang current area to the corresponding area in that direction
                //update in database
                //return true
                lcPlayer.CurrentArea = lcArea.West;
                _connection.Update(lcPlayer);
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Logic processor used to obtain the correct story text for the current area that the player is inside
    /// </summary>
    /// <returns>returns the correct sotry text for the current area</returns>
    public string GetStory(string prEmail)
    {
        TablePlayer lcPlayer = _connection.Table<TablePlayer>().Where(x => x.Email == prEmail).FirstOrDefault();

        var itemInAreaCount = _connection.Query<TableAreaItem>(
                "select TableAreaItem.ItemID from TableAreaItem"
                + " inner join TablePlayer"
                + " on TableAreaItem.AreaName = TablePlayer.CurrentArea "
                + " where TableAreaItem.Email = ? and TableAreaItem.AreaName = ?",
                prEmail, lcPlayer.CurrentArea).ToList();

        if (itemInAreaCount.Count > 0)
        {
            TableVisited lcVisited = _connection.Table<TableVisited>().Where(x => x.AreaName == lcPlayer.CurrentArea && x.Email == lcPlayer.Email).FirstOrDefault();
            
            if (lcVisited == null)
            {
                //get first visit story & insert visited entry
                var lcNewVisited = new TableVisited
                {
                    AreaName = lcPlayer.CurrentArea,
                    Email = prEmail
                };
                _connection.Insert(lcNewVisited);
            }
                // select pre pickup story
                TableStory lcStory = _connection.Table<TableStory>().Where(x => x.Phase == "prePickup" && x.AreaName == lcPlayer.CurrentArea).FirstOrDefault();
                return lcStory.Description;
        }
        else
        {
            //TablePlayer lcPlayer = _connection.Table<TablePlayer>().Where(x => x.Email == firebaseManager.FirebaseManagerInstance.Email).FirstOrDefault();
            TableVisited lcVisited = _connection.Table<TableVisited>().Where(x => x.AreaName == lcPlayer.CurrentArea && x.Email == lcPlayer.Email).FirstOrDefault();
            //
            if (lcVisited == null)
            {
                //get first visit story & insert visited entry
                var lcNewVisited = new TableVisited
                {
                    AreaName = lcPlayer.CurrentArea,
                    Email = prEmail
                };
                _connection.Insert(lcNewVisited);
                TableStory lcStory = _connection.Table<TableStory>().Where(x => x.Phase == "firstVisit" && x.AreaName == lcPlayer.CurrentArea).FirstOrDefault();
                return lcStory.Description;
            }
            else
            {
                //get default story
                TableStory lcStory = _connection.Table<TableStory>().Where(x => x.Phase == "default" && x.AreaName == lcPlayer.CurrentArea).FirstOrDefault();
                return lcStory.Description;
            }
        }
    }

    /// <summary>
    /// Gets the story text that is to be displayed after picking up an item
    /// </summary>
    /// <returns>returns postPickup text for the current area</returns>
    public string GetPostPickupStory(string prEmail)
    {
        //get areaname for current player area
        TablePlayer lcPlayer = _connection.Table<TablePlayer>().Where(x => x.Email == prEmail).FirstOrDefault();

        //use area name to get correct post pickup text
        TableStory lcStory = _connection.Table<TableStory>().Where(x => x.AreaName == lcPlayer.CurrentArea && x.Phase == "postPickup").FirstOrDefault();
        return lcStory.Description;
    }
    #endregion

    #region Items
    /// <summary>
    /// Adds the current area item to the players inventory
    /// </summary>
    /// <param name="prEmail">email used to identify the player</param>
    /// <returns>returns true of false dependant on whether the command was successful or not</returns>
    public bool AddItemToInven(string prEmail)
    {
        try
        {
            //get current area from player table
            TablePlayer lcPlayer = _connection.Table<TablePlayer>().Where(x => x.Email == prEmail).FirstOrDefault();

            //get item id for current area
            TableAreaItem lcAreaItem = _connection.Table<TableAreaItem>().Where(x => x.AreaName == lcPlayer.CurrentArea && x.Email == lcPlayer.Email).FirstOrDefault();

            //add item to inventory
            TableInventory lcInventory = new TableInventory
            {
                ItemID = lcAreaItem.ItemID,
                Email = prEmail
            };
            _connection.Insert(lcInventory);

            //remove from areaItem
            //moved to its own function due to db file error
            //_connection.Delete(lcAreaItem);

            return true;
        }
        catch
        {
            return false;
        }

    }

    /// <summary>
    /// Deletes the current areaitem from the area
    /// </summary>
    /// <param name="prEmail">email used to identify the player</param>
    /// <returns>returns true of false dependant on whether the command was successful or not</returns>
    public bool DeleteAreaItem(string prEmail)
    {
        try
        {
            //get current area from player table
            TablePlayer lcPlayer = _connection.Table<TablePlayer>().Where(x => x.Email == prEmail).FirstOrDefault();

            //get item id for current area
            //TableAreaItem lcAreaItem = _connection.Table<TableAreaItem>().Where(x => x.AreaName == lcPlayer.CurrentArea && x.Email == lcPlayer.Email).FirstOrDefault();

            _connection.Query<TableAreaItem>(
            "delete from TableAreaItem"
            + " where TableAreaItem.Email = ? and TableAreaItem.AreaName = ?",
            prEmail, lcPlayer.CurrentArea);
            //_connection.Delete(lcAreaItem);

            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region Get Tables
    /// <summary>
    /// returns the current players database table
    /// </summary>
    /// <returns>returns the current players database table</returns>
    public int GetHealth(string prEmail)
    {
        TablePlayer lcPlayer = _connection.Table<TablePlayer>().Where(x => x.Email == prEmail).FirstOrDefault();
        return lcPlayer.Health;
    }

    /// <summary>
    /// returns the current areas areaitem table
    /// </summary>
    /// <param name="prPlayer">used to select the corrent areaitem row for the current player</param>
    /// <returns>returns the players current areaitem table for the area they are in</returns>
    public bool GetAreaItem(Player prPlayer)
    {
        TablePlayer lcPlayer = _connection.Table<TablePlayer>().Where(x => x.Email == prPlayer._email).FirstOrDefault();
        TableAreaItem lcAreaItem = _connection.Table<TableAreaItem>().Where(x => x.AreaName == lcPlayer.CurrentArea && x.Email == prPlayer._email).FirstOrDefault();

        if (lcAreaItem == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// gets current npc table for the area the player is in
    /// </summary>
    /// <param name="prPlayer">used to get the correct npc table for the player</param>
    /// <returns>returns the npc table</returns>
    public bool GetNPC(Player prPlayer)
    {
        TablePlayer lcPlayer = _connection.Table<TablePlayer>().Where(x => x.Email == prPlayer._email).FirstOrDefault();
        TableNPC lcNPC = _connection.Table<TableNPC>().Where(x => x.CurrentArea == lcPlayer.CurrentArea && x.Email == prPlayer._email).FirstOrDefault();

        if (lcNPC == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// gets the players currents area table for the area they are in
    /// </summary>
    /// <param name="prPlayer">used to correctly select the current area the player is in by using the email</param>
    /// <returns>returns the players current area table</returns>
    public string GetDirectionsPossible(Player prPlayer)
    {
        TablePlayer lcPlayer = _connection.Table<TablePlayer>().Where(x => x.Email == prPlayer._email).FirstOrDefault();
        TableArea lcArea = _connection.Table<TableArea>().Where(x => x.AreaName == lcPlayer.CurrentArea).FirstOrDefault();

        string lcDecisions = null;

        if (lcArea.North != null)
        {
            lcDecisions = lcDecisions + "\n" + "go north";
        }

        if (lcArea.South != null)
        {
            lcDecisions = lcDecisions + "\n" + "go south";
        }

        if (lcArea.East != null)
        {
            lcDecisions = lcDecisions + "\n" + "go east";
        }

        if (lcArea.West != null)
        {
            lcDecisions = lcDecisions + "\n" + "go west";
        }

        return lcDecisions;
        
    }
    #endregion
}
