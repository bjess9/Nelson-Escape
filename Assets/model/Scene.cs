using System;


	public class Scene
	{
		private Players _players = new Players();
		private Scene[] _connected_scenes = new Scene[4];
    // yes/no scenes use Text[1] for the 'yes' response and Text[2] for the 'no' response.
        private string[] _text;
    private string _sceneObject;


	    
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

    public string[] Text
    {
        get
        {
            return _text;
        }

        set
        {
            _text = value;
        }
    }

    public string SceneObject
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


