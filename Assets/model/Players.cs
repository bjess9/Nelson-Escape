using System;
using System.Collections;
using System.Collections.Generic;

using System.IO;

	public class Players
	{
        // this class is currently not implemented

	   private List<Player> _players = new List<Player>();

	   public Player this[int index] 
	   {
			get
			{ 
				return  _players[index];
			} 
			set
			{
				_players[index] = value;
			}
	    }

	    public Players ()
		{
		
		}
	}


