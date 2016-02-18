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
		playerdata.playerPositionX = GameObject.Find ("prefabBasicPlayer").transform.position.x;
		playerdata.playerPositionY = GameObject.Find ("prefabBasicPlayer").transform.position.y;
		playerdata.currentScene = SceneManager.GetActiveScene ().buildIndex;
		Debug.Log (SceneManager.GetActiveScene ().buildIndex);

		bf.Serialize (file, playerdata);
		file.Close ();
	}

	public void Load(){
		if (File.Exists (Application.dataPath + "/SaveData/playerInfo.dat")) {
			Debug.Log ("into the Save Data!");
			BinaryFormatter bf = new BinaryFormatter ();
			Debug.Log ("finish bf define bf!");
			FileStream file = File.Open (Application.dataPath + "/SaveData/playerInfo.dat",FileMode.Open);
			Debug.Log ("finish open");
			PlayerData data = (PlayerData)bf.Deserialize (file);
			Debug.Log ("finish data deserialize!");
			file.Close();


			PlayerPrefs.SetFloat ("PlayerX", data.playerPositionX);
			Debug.Log ("finish load playerpositionX");
			PlayerPrefs.SetFloat ("PlayerY", data.playerPositionY);
			Debug.Log ("finish load playerpositionY");
			PlayerPrefs.SetFloat ("PlayerZ", 0);
			Debug.Log ("finish load playerpositionZ");
			PlayerBagManager.instance.BagContent = data.bagContent;
			Debug.Log ("finish load bagContent");
			SceneManager.LoadScene (data.currentScene);
		}
	}



	[Serializable]
	class PlayerData{
		public List<Item> bagContent { get; set;}
		public float playerPositionX;
		public float playerPositionY;
		public int currentScene;
	}

}
