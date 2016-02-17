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

	// Use this for initialization



	void Awake(){
		
		if (instance == null) {
			List<Item> bagContent = new List<Item> ();
			DontDestroyOnLoad (gameObject);
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}


	}

	void OnLevelWasLoaded(){
		
	}

	void Start () {
		DontDestroyOnLoad (gameObject);
		//AddNewItemIntoBag (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddNewItemIntoBag(int itemID){

		//Debug.Log ("Entered AddNewItemIntoBag, itemID = " + itemID);

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
		if (bagPosition < bagContent.Count)
			return bagContent [bagPosition];
		return null;
	}
}
