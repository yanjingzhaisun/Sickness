using UnityEngine;
using System.Collections;

public class VisualEffect_Flopping : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Sin (Time.time);
		transform.localScale = new Vector3 (x, transform.localScale.y, transform.localScale.z);
	}
}
