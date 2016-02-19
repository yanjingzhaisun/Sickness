using UnityEngine;
using System.Collections;

public class ItemGetable : MonoBehaviour {

	public int item_id;

	Item thisItem;

	// Use this for initialization
	void Start () {
		thisItem = null;
		if (item_id < ItemDatabase.instance.database.Count) {
			thisItem = ItemDatabase.instance.database [item_id];
		}

		GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Images/" + thisItem.Image);
	}
	
	// Update is called once per frame
	void Update () {
		if (thisItem == null)
			return;
	}

	void OnTriggerEnter2D(Collider2D myCollider){
		if (myCollider.CompareTag ("Player")) {
			PlayerBagManager.instance.AddNewItemIntoBag (item_id);
			Destroy (gameObject);
		}
	}
}
