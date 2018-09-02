using System;
using System.Collections.Generic;

public class Scene
	{
		private Players _players = new Players();
		private Scene[] _connected_scenes = new Scene[4];

    private List<string> lstStory = new List<string>();
    private Item _sceneObject;


	    
		public Scene North { 
			get { 
			return _connected_scenes[(int)GameModel.DIRECTION.North];
			}
			set { 
			_connected_scenes[(int)GameModel.DIRECTION.North] = value;
			}
		}

		public Scene South { 
			get { 
				return _connected_scenes[(int)GameModel.DIRECTION.South];
			}
			set { 
				_connected_scenes[(int)GameModel.DIRECTION.South] = value;
			}
		}

    public Scene East
    {
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.East];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.East] = value;
        }
    }

    public Scene West
    {
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.West];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.West] = value;
        }
    }



    public List<string> LstStory
    {
        get
        {
            return lstStory;
        }

        set
        {
            lstStory = value;
        }
    }

    public Item SceneObject
    {
        get
        {
            return _sceneObject;
        }

        set
        {
            _sceneObject = value;
        }
    }

    public Scene ()
		{
		}
	    
	    
	}


