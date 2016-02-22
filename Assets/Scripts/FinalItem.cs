using UnityEngine;
using System.Collections;

public class FinalItem : MonoBehaviour {

	public Vector2 newScenePosition;

	public string nextLevelName;
	bool isTouched = false;

	// Use this for initialization
	void Start () {
		isTouched = false;
	}

	// Update is called once per frame
	void Update () {
		if (isTouched) {
			Vector3 aim = new Vector3 (transform.position.x, transform.position.y, Camera.main.transform.position.z);
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, aim, 0.1f);
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		Debug.Log ("Etnered 2d");
		if (c.gameObject.CompareTag ("Player")) {
			if (!isTouched) {
				NextLevel.instance.theNextLevel = nextLevelName;
				PlayerPrefs.SetFloat ("PlayerX", newScenePosition.x);
				PlayerPrefs.SetFloat ("PlayerY", newScenePosition.y);
				PlayerPrefs.SetFloat ("PlayerZ", GameObject.Find ("prefabBasicPlayer").transform.position.z);
				GameObject p = GameObject.Find ("prefabBasicPlayer");
				GetComponent<SpriteRenderer>().sprite =  Resources.Load<Sprite> ("Images/finalTerrain02");
				if (p != null) {
					p.GetComponent<PlayerControl> ().IsInputEnabled = false;
					p.GetComponent<SpriteRenderer> ().enabled = false;
				}
				Camera.main.GetComponent<CameraMoveMent> ().enabled = false;

				GetComponent<VisualEffect_Flopping> ().enabled = false;
				transform.localScale = new Vector3 (1, 1, 1);
				StartCoroutine (WaitTime ());


			}
			isTouched = true;
		}
	}

	IEnumerator WaitTime(){
		yield return new WaitForSeconds (5f);
		NextLevel.instance.StartChangeLevel ();
	}
}
