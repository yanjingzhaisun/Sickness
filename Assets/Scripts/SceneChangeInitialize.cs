using UnityEngine;
using System.Collections;

public class SceneChangeInitialize : MonoBehaviour {

	public Vector2 newScenePosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnColliderEnter2D(Collider2D c) {
		if (c.gameObject.CompareTag ("Player")) {
			PlayerPrefs.SetFloat ("PlayerX", newScenePosition.x);
			PlayerPrefs.SetFloat ("PlayerY", newScenePosition.y);
			PlayerPrefs.SetFloat ("PlayerZ", GameObject.Find ("prefabBasicPlayer").transform.position.z);

		}
	}
}
