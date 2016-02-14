using UnityEngine;
using System.Collections;

public class CameraMoveMent : MonoBehaviour {

	GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("prefabBasicPlayer");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = Vector3.Lerp(transform.position,Player.transform.position, 0.1f) ;
		position.z = transform.position.z;
		position.y = position.y + 0.1f;
		transform.position = position;

	}
}
