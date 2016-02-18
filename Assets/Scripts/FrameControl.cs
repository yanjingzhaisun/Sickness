using UnityEngine;
using System.Collections;

public class FrameControl : MonoBehaviour {
	public int CurrentItemBagPosition {
		get;
		set;
	}

	GameObject frameImage;
	// Use this for initialization
	void Start () {
		frameImage = GameObject.Find ("SlotFrame");
	}
	
	// Update is called once per frame
	void Update () {
		float x = frameImage.GetComponent<RectTransform> ().anchoredPosition.x;
		//Debug.Log (x + " " + CurrentItemBagPosition);
		x = Mathf.Lerp (x, CurrentItemBagPosition * 41f, 10f * Time.deltaTime);

		frameImage.GetComponent<RectTransform> ().anchoredPosition = new Vector2(x, frameImage.GetComponent<RectTransform> ().anchoredPosition.y);
	
	}
}
