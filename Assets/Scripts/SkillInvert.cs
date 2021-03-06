﻿using UnityEngine;
using System.Collections;

//Skill Invert itemID: 2

public class SkillInvert : MonoBehaviour {
	FrameControl fC;

	private int skillInvertItemId = 2;

	GameObject shaderInvert;
	GameObject invertTerrains;
	GameObject invertDisableTerrains;

	bool toggleKeyButton = false;

	// Use this for initialization
	void Start () {
		fC = GameObject.Find ("GameLogic").GetComponent<FrameControl> ();
		shaderInvert = GameObject.Find ("ShaderInvert");
		invertTerrains = GameObject.Find ("InvertTerrains");
		invertDisableTerrains = GameObject.Find ("InvertDisableTerrains");
//		Debug.Log (shaderInvert);
		if (shaderInvert != null)
			shaderInvert.SetActive (false);
		if (invertTerrains != null)
			invertTerrains.SetActive (false);
		if (invertDisableTerrains != null)
			invertDisableTerrains.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (fC.CurrentItemBagPosition >= PlayerBagManager.instance.BagContent.Count)
			return;
			
		if (PlayerBagManager.instance.BagContent [fC.CurrentItemBagPosition].ID == skillInvertItemId) {
			if (Input.GetKeyDown (KeyCode.J)) {
				if (!GetComponent<PlayerControl> ().IsInputEnabled)
					return;
				toggleKeyButton = !toggleKeyButton;
				if (shaderInvert != null)
					shaderInvert.SetActive (toggleKeyButton);
				if (invertTerrains != null)
					invertTerrains.SetActive (toggleKeyButton);
				if (invertDisableTerrains != null)
					invertDisableTerrains.SetActive (!toggleKeyButton);
			}
		}
	}

	public bool GetToggleKeyButton(){
		return toggleKeyButton;
	}
}
