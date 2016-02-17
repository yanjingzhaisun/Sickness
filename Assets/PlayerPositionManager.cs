using UnityEngine;
using System.Collections;

public class PlayerPositionManager : MonoBehaviour {
	public static PlayerPositionManager instance;

	public Vector3 PlayerPosition {
		get;
		set;
	}
	public int SceneNumber {
		get;
		set;
	}

	void Awake(){

		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
			
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
