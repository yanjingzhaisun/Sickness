using UnityEngine;
using System.Collections;

public class GoalItem : MonoBehaviour {

	public Vector2 newScenePosition;

	public string nextLevelName;
	bool isTouched = false;

	// Use this for initialization
	void Start () {
		isTouched = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c) {
		Debug.Log ("Etnered 2d");
		if (c.gameObject.CompareTag ("Player")) {
			if (!isTouched) {
				NextLevel.instance.theNextLevel = nextLevelName;
				PlayerPrefs.SetFloat ("PlayerX", newScenePosition.x);
				PlayerPrefs.SetFloat ("PlayerY", newScenePosition.y);
				PlayerPrefs.SetFloat ("PlayerZ", GameObject.Find ("prefabBasicPlayer").transform.position.z);
				NextLevel.instance.StartChangeLevel ();
				GameObject.Find ("prefabBasicPlayer").GetComponent<PlayerControl> ().IsInputEnabled = false;
			}
			isTouched = true;
		}
	}
}
