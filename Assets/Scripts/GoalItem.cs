using UnityEngine;
using System.Collections;

public class GoalItem : MonoBehaviour {

	bool isTouched = false;

	// Use this for initialization
	void Start () {
		isTouched = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.CompareTag ("Player")) {
			if (!isTouched) {
				NextLevel.instance.StartChangeLevel ();
			}
			isTouched = true;
		}
	}
}
