using UnityEngine;
using System.Collections;

public class SpikeControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D myCollision){
		if (myCollision.gameObject.CompareTag ("Player")) {
			Vector2 v = myCollision.gameObject.GetComponent<Rigidbody2D> ().velocity;
			myCollision.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(v.x, -v.y);
			myCollision.gameObject.GetComponent<DeathManager> ().IsDead = true;
		}
	}
}
