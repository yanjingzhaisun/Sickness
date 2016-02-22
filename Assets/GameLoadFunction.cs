using UnityEngine;
using System.Collections;

public class GameLoadFunction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameLoad(){
		SaveLoadFunction.instance.Load ();
	}
}
