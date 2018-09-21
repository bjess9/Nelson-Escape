using System;

[Serializable]
public class Item
	{
        //item description text
		private string _description;

		//public Item ()
		//{
		//}

    public string Description
    {
        get
        {
            return _description;
        }

        set
        {
            _description = value;
        }
    }
}


