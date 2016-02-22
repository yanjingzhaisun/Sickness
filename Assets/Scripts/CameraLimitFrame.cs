using UnityEngine;
using System.Collections;

public class CameraLimitFrame : MonoBehaviour {


	Transform limitFrame;

	float left, right, up, down;
	// Use this for initialization
	void Start () {
		if (GameObject.Find ("LimitFrame") != null) {
			limitFrame = GameObject.Find ("LimitFrame").transform;
			float vertExtent = Camera.main.orthographicSize;
			float horiExtent = vertExtent * Screen.width / Screen.height;

			left = (float)(horiExtent - limitFrame.GetComponent<SpriteRenderer> ().sprite.bounds.size.x * limitFrame.localScale.x / 2.0f + limitFrame.position.x);
			right = (float)(-horiExtent + limitFrame.GetComponent<SpriteRenderer> ().sprite.bounds.size.x * limitFrame.localScale.x / 2.0f + limitFrame.position.x);
			down = (float)(vertExtent - limitFrame.GetComponent<SpriteRenderer> ().sprite.bounds.size.y * limitFrame.localScale.y / 2.0f + limitFrame.position.y);
			up = (float)(-vertExtent + limitFrame.GetComponent<SpriteRenderer> ().sprite.bounds.size.y * limitFrame.localScale.y / 2.0f + limitFrame.position.y);
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate(){
		if (limitFrame == null)
			return;
		Camera.main.transform.position = new Vector3 (
			Mathf.Clamp (Camera.main.transform.position.x, left, right),
			Mathf.Clamp (Camera.main.transform.position.y, down, up),
			Camera.main.transform.position.z
		);
	}
}
