using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class PlayerBagManager : MonoBehaviour {

	public static PlayerBagManager instance;

	public List<Item> BagContent {
		get{ return bagContent;}
		set { 
			for (int i = 0; i < value.Count; i++) {
				bagContent [i] = value [i];
			}
		}
	}
	List<Item> bagContent;


	void Awake(){
		
		if (instance == null) {
			transform.parent = null;
			bagContent = new List<Item> ();
			DontDestroyOnLoad (gameObject);
			instance = this;

		} else if (instance != this) {
			
//			Debug.Log ("instance's bagContent is " + instance.bagContent);
//			Debug.Log ("this object's bagContent is " + this.bagContent);
//			Debug.Log ("destory new instance");
			//Debug.Log (instance.bagContent);
			Destroy (gameObject);
		}

	}

	public void AddNewItemIntoBag(int itemID){

		//Debug.Log ("Entered AddNewItemIntoBag, itemID = " + itemID);
		if (instance == this) {
			if (instance.bagContent == null) {
				
				return;
			}

		}
		for (int i = 0; i < bagContent.Count; i++) {
			if (bagContent [i].ID == itemID)
				return;
		}

		try {
			bagContent.Add(GetComponent<ItemDatabase>().database[itemID]);
		} catch (Exception e){
			Debug.LogError (e);
		}
	}

	public Item GetThingInBag(int bagPosition){
		if (bagContent == null) {
//			bagContent = new List<Item> ();
			return null;
		}

		if (bagPosition < bagContent.Count)
			return bagContent [bagPosition];
		return null;
	}
}
