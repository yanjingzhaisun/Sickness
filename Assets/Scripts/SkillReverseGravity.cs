using UnityEngine;
using System.Collections;

public class SkillReverseGravity : MonoBehaviour {

	FrameControl fC;

	private int skillReverseGravityItemId = 3;

	GameObject shaderInvert;
	GameObject invertTerrains;
	GameObject invertDisableTerrains;

	bool toggleKeyButton = false;
	PlayerControl p;

	// Use this for initialization
	void Start () {
		fC = GameObject.Find ("GameLogic").GetComponent<FrameControl> ();
		p = GetComponent<PlayerControl> ();
	}

	// Update is called once per frame
	void Update () {
		if (fC.CurrentItemBagPosition >= PlayerBagManager.instance.BagContent.Count)
			return;
		if (p == null)
			return;
		
		if (PlayerBagManager.instance.BagContent [fC.CurrentItemBagPosition].ID == skillReverseGravityItemId) {
			if (Input.GetKeyDown (KeyCode.J)) {
				if (!p.IsInputEnabled)
					return;
				if (p.VectorInvert == 1) {
					Debug.Log ("p Vector Invert == 1!");
					p.VectorInvert = -1;
					transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y) * -1, transform.localScale.z);
					//p.SetGravityScale ();
				} else if (p.VectorInvert == -1) {
					p.VectorInvert = 1;
					transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
					//p.SetGravityScale ();
				}
			}
		}
	}
}

