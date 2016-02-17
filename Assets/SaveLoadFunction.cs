using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class SaveLoadFunction : MonoBehaviour {

	public static SaveLoadFunction instance;

	void Awake(){

		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.dataPath + "/SaveData/playerInfo.dat");

		PlayerData playerdata = new PlayerData ();
		playerdata.bagContent = PlayerBagManager.instance.BagContent;
		playerdata.playerPosition = GameObject.Find ("prefabBasicPlayer").transform.position;
		playerdata.currentScene = SceneManager.GetActiveScene ().buildIndex;

		bf.Serialize (file, playerdata);
		file.Close ();
	}

	public void Load(){
		if (File.Exists (Application.dataPath + "/SaveData/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.dataPath + "/SaveData/playerInfo.dat",FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close();


			PlayerPositionManager.instance.SceneNumber = data.currentScene;
			PlayerPositionManager.instance.PlayerPosition = data.playerPosition;
			PlayerBagManager.instance.BagContent = data.bagContent;
			SceneManager.LoadScene (data.currentScene);
		}
	}



	[Serializable]
	class PlayerData{
		public List<Item> bagContent { get; set;}
		public Vector3 playerPosition;
		public int currentScene;
	}

}
