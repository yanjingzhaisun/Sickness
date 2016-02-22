using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {
	public int slot_id;
	public FrameControl frameControl;

	Image img;

	Item thisItem;
	// Use this for initialization
	void Start () {
		img = transform.FindChild ("item").GetComponent<Image>();
		thisItem = PlayerBagManager.instance.GetThingInBag (slot_id);
	}
	
	// Update is called once per frame
	void Update () {
		thisItem = PlayerBagManager.instance.GetThingInBag (slot_id);

		if (thisItem != null) {
			//Debug.Log (thisItem.Image);
			img.sprite = Resources.Load<Sprite> ("Images/" + thisItem.Image);
			//transform.FindChild ("item").GetComponent<Image> ().sprite = Resources.Load<Sprite> ("Images/basicEnemy");
		}
		if (Input.GetKeyDown (KeyCode.Alpha1 + slot_id)) {
			//Debug.Log (slot_id + "has been clicked!");
			frameControl.CurrentItemBagPosition = slot_id;
		}
	}
}
