using System.Collections;
using UnityEngine;

public class RunOnlyOnce : MonoBehaviour {
    //not implemented
	public static RunOnlyOnce instance;
	void Awake() {
		if(instance != null && instance != this) {
			DestroyImmediate(gameObject);
			return;
		}
		instance = this;
		GameModel.MakeAreas();
		// DontDestroyOnLoad(gameObject);
	}
}
