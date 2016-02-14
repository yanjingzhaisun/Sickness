using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChpterStartRoutine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (ChpterStartCoroutine ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ChpterStartCoroutine(){
		yield return new WaitForSeconds (3);
		NextLevel.instance.StartChangeLevel ();
	}
}
