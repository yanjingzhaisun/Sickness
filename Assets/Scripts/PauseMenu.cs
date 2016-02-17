using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;

	[HideInInspector]
	public bool isPaused = false;

	GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		pauseMenu = GameObject.Find ("PauseMenu");
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			pauseMenu.SetActive (true);
		} else {
			pauseMenu.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void Resume(){
		isPaused = false;
	}

	public void LevelSelect(){
		
	}
}
