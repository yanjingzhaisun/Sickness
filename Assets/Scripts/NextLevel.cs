using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public string theNextLevel;

	public static NextLevel instance;

	// Use this for initialization

	void Awake(){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartChangeLevel(){
		StartCoroutine (ChangeLevel (theNextLevel));
	}

	IEnumerator ChangeLevel(string levelName){
		float fadeTime = 1f/GetComponent<FadeScreen> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel(levelName);
	}
}
