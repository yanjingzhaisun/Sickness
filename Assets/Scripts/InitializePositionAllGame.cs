using UnityEngine;
using System.Collections;

public class InitializePositionAllGame : MonoBehaviour {

	public Vector3 initlialPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetInitialPosition(){
		PlayerPrefs.SetFloat ("PlayerX", initlialPosition.x);
		PlayerPrefs.SetFloat ("PlayerY", initlialPosition.y);
		PlayerPrefs.SetFloat ("PlayerZ", initlialPosition.z);
		PlayerBagManager.instance.DataClear ();
		NextLevel.instance.theNextLevel = "Scene01-MainRoom";
		NextLevel.instance.StartChangeLevel ();
	}
}
