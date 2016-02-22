using UnityEngine;
using System.Collections;

public class TextTransformCorrection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (Mathf.Abs (transform.localScale.x), Mathf.Abs (transform.localScale.y), Mathf.Abs (transform.localScale.z));
	}
}
