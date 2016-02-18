using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;
using System;

public class ItemDatabase : MonoBehaviour {
	[HideInInspector]
	public List<Item> database = new List<Item>();

	private JsonData itemData;
	// Use this for initialization

	public static ItemDatabase instance;

	void Awake(){
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		itemData = JsonMapper.ToObject (File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
		ConstructItemDatabase ();
		//Debug.Log (database [1].Title);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ConstructItemDatabase(){
		for (int i = 0; i < itemData.Count; i++) {
			database.Add (new Item ((int)itemData [i] ["id"], itemData [i] ["title"].ToString(), itemData [i] ["image"].ToString()));
		}
	}
}

[Serializable]
public class Item{

	public int ID {get; set;}

	public string Title {get; set;}

	public string Image{get;set;}

	public Item(int id, string title, string image){
		this.ID = id;
		this.Title = title;
		this.Image = image;
	}
	
}
