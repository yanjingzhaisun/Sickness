using UnityEngine;
using System.Collections;

public class MyTriggerClass : MonoBehaviour {

	bool preFrame = false;
	bool thisFrame = false;


	bool onTriggerDown = false;

	bool onTriggerRelease = false;

	public bool OnTriggerDown{
		get { return onTriggerDown; }
	}

	public bool OnTriggerRelease{
		get { return onTriggerRelease; }
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate() {
		if ((!preFrame) && (thisFrame))
			onTriggerDown = true;
		else
			onTriggerDown = false;
		if ((preFrame) && (!thisFrame))
			onTriggerRelease = true;
		else
			onTriggerRelease = false;
		preFrame = thisFrame;

	}


	public void PressTriggerDown(){
		thisFrame = true;
	}
		
}
