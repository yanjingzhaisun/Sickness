using UnityEngine;
using System.Collections;
using System;

public class DeathManager : MonoBehaviour {

	public bool IsDead {
		get;set;
	}

	bool stopAllAction = false;

	ParticleSystem deathParticleSystem;

	// Use this for initialization
	void Start () {
//		Debug.Log (transform.FindChild ("prefabDieParticleSystem"));
		try {
			deathParticleSystem = transform.FindChild ("prefabDieParticleSystem").GetComponent<ParticleSystem> ();
			//Debug.Log(deathParticleSystem);
		} catch (Exception e) {
			Debug.LogError (e);
			deathParticleSystem = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (deathParticleSystem);
		if (IsDead) {
			if (stopAllAction)
				return;
			stopAllAction = true;


			GetComponent<PlayerControl> ().SetInputEnabled (false);
			if (deathParticleSystem != null) {
//				Debug.Log ("PlayingDeathParticle!");
				deathParticleSystem.Play ();
			}
			StartCoroutine (DeadChangeStaff ());
		}
	}


	IEnumerator DeadChangeStaff(){
		yield return new WaitForSeconds (2f);
		NextLevel.instance.theNextLevel = "TItle";
		NextLevel.instance.StartChangeLevel ();
	}
}
