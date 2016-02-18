using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartNewGame(){
		
		PlayerPrefs.SetFloat ("PlayerX", 0);
		PlayerPrefs.SetFloat ("PlayerY", 0);
		PlayerPrefs.SetFloat ("PlayerZ", 0);
		SceneManager.LoadScene ("testScene");
	}
}
