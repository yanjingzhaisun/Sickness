using UnityEngine;
using System.Collections;

public class OnLoadChangePlayerPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("prefabBasicPlayer");
		player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"),PlayerPrefs.GetFloat("PlayerZ"));
		Camera.main.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"),Camera.main.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
