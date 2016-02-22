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

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
			if (isPaused)
				Time.timeScale = 0f;
			else
				Time.timeScale = 1f;
		}

		if (pauseMenu != null) {
			if (isPaused) {
				pauseMenu.SetActive (true);
			} else {
				pauseMenu.SetActive (false);
			}
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
