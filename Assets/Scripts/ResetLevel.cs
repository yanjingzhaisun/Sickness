using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour {

	public static ResetLevel instance;

	void Awake(){
		if (instance == null) {
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

	public void StartResetLevel(){
		StartCoroutine (ResetLevelCoroutine());
	}

	IEnumerator ResetLevelCoroutine(){
		float fadeTime = 1f/GetComponent<FadeScreen> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
	}
}
