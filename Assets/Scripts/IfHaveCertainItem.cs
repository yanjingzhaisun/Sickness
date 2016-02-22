using UnityEngine;
using System.Collections;

public class IfHaveCertainItem : MonoBehaviour {
	MeshRenderer t;

	public int requireItem = 2;
	// Use this for initialization
	void Start () {
		t = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
