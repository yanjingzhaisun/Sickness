using UnityEngine;
using System.Collections;

public class ItemSaveManager : MonoBehaviour {
	TextMesh txt;
	Transform player;
	// Use this for initialization
	void Start () {
		txt = transform.FindChild ("SaveText").GetComponent<TextMesh> ();
		player = GameObject.Find ("prefabBasicPlayer").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.SqrMagnitude (player.position - transform.position) > 20f) {
			txt.color = new Color (txt.color.r, txt.color.g, txt.color.b, 0f);
		} else {
			float alpha = 1 - Vector3.SqrMagnitude (player.position - transform.position) / 20f;
			txt.color = new Color (txt.color.r, txt.color.g, txt.color.b, alpha);
		}

	}

	void OnTriggerStay2D(Collider2D player){
		if (player.CompareTag ("Player")) {
			if (Input.GetKeyDown (KeyCode.S)) {
				txt.text = "Save Successful!";
				SaveLoadFunction.instance.Save ();
				StartCoroutine (ChangeRoutine ());

			}
		}
	}

	IEnumerator ChangeRoutine(){
		yield return new WaitForSeconds (2f);
		txt.text = "Press S to Save";
	}

}
