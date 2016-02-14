using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using InControl;


public class PlayerControl : MonoBehaviour {

	bool isJumping;
	Rigidbody2D rigidBody;

	public float gravityScale = 8f;

	public float maxSpeed = 8f;

	public float maxForce =2f;
	public float dragForce = 0.1f;

	public float jumpingGravityScale = 1f;
	public int jumpingLiftingTimeCounter = 12;
	public float jumpingForce = 5f;

	//used for raycast collision detection;
	public float spriteHeight = 1.28f;
	public float spriteWidth = 1.28f;

	public int ratioJumpingFactor=5;

	bool isInputEnabled = true;
	//InputDevice inputDevice;


	int jumpCounter;

	public LayerMask layerMask;

	Animator walkingAnimator;

	void Awake(){
	}

	void Start(){
		rigidBody = GetComponent<Rigidbody2D> ();
		//inputDevice = InputManager.ActiveDevice;
		rigidBody.gravityScale = gravityScale;
		walkingAnimator = GetComponent<Animator> ();
	}

	void Update(){
		walkingAnimator.SetFloat ("xSpeed", Mathf.Abs (rigidBody.velocity.x));
		walkingAnimator.SetBool ("isJumping", isJumping);
		//Debug.Log ("Drawing");

	}

	void FixedUpdate(){
		if (isInputEnabled) {
			InputMoving ();
		}
		ApplyDragForce ();
		JumpUpdate ();

		if (Input.GetKeyDown (KeyCode.R)) {
			ResetLevel.instance.StartResetLevel ();
		}
	}

	public void StartJumping(){
		if (!isJumping) {
			isJumping = true;
			rigidBody.gravityScale = -Mathf.Abs (jumpingGravityScale);
			rigidBody.velocity += new Vector2 (0, 10f);
			jumpCounter = 0;
		}
	}

	void JumpUpdate(){
		if (!isJumping) {
			rigidBody.gravityScale = Mathf.Abs (gravityScale);
			return;
		}
		if ((Input.GetKey (KeyCode.Space) || (jumpCounter < jumpingLiftingTimeCounter / ratioJumpingFactor)) && (jumpCounter <= jumpingLiftingTimeCounter)) {
			rigidBody.AddForce (new Vector2 (0, jumpingForce ), ForceMode2D.Force);
			Vector2 v = rigidBody.velocity;
			v.y = Mathf.Clamp (v.y, -1.7f * maxSpeed, 1.7f * maxSpeed);
			rigidBody.velocity = v;
			jumpCounter++;

		} else {
			rigidBody.gravityScale = Mathf.Abs (gravityScale);
		}
	}

	void InputMoving(){
		//Vector2 f = new Vector2(inputDevice.LeftStick.X, 0) * maxForce;
		if (Input.GetKey (KeyCode.A)) {
			Vector2 f = new Vector2 (-maxForce, 0);
			rigidBody.AddForce (f,ForceMode2D.Impulse);

		} else if (Input.GetKey (KeyCode.D)) {
			Vector2 f = new Vector2 (maxForce, 0);
			rigidBody.AddForce (f,ForceMode2D.Impulse);
		}
		Vector2 v = rigidBody.velocity;
		//v.y = 0;
		v.x = Mathf.Clamp (v.x, -maxSpeed, maxSpeed);
		rigidBody.velocity = v;
		//if (inputDevice)

		if (Input.GetKeyDown (KeyCode.Space)) {
			StartJumping ();
		}
	}

	void ApplyDragForce(){
		Vector2 v = rigidBody.velocity;
		v.y = 0;
		rigidBody.AddForce (dragForce * (-v) * v.magnitude);
	}






	public void OnCollisionEnter2D(Collision2D myCollision){
		if (myCollision.collider.CompareTag ("Terrain")) {
			if ((CollisionDirection ("Terrain") & 2) != 0) {
				isJumping = false;
			}
		}
	}

	//TODO
	//1: Up; 2: Down; 4:Left; 8:Right;
	int CollisionDirection(string tag){
		RaycastHit2D hit;
		//LayerMask layerMask = ~(LayerMask.NameToLayer("Terrain"));
		int result = 0;
		//Debug.Log ("Into CollisionDirection");
		//Debug.Log("Into COllisionDirection");	

		hit = Physics2D.Raycast (transform.position + new Vector3(spriteWidth/2, spriteHeight/2,0), Vector2.up, 0.4f,layerMask);
		Debug.DrawRay (transform.position + new Vector3(spriteWidth/2, spriteHeight/2,0), Vector2.up * 0.4f, Color.red , 2);
		if (hit.collider != null) {
			if (hit.collider.gameObject.CompareTag (tag)) {
				result = result | 1;
			}
		}

		hit = Physics2D.Raycast (transform.position + new Vector3(-spriteWidth/2, spriteHeight/2,0), Vector2.up, 0.4f,layerMask);
		Debug.DrawRay (transform.position + new Vector3(-spriteWidth/2, spriteHeight/2,0), Vector2.up * 0.4f, Color.red , 2);
		if (hit.collider != null) {
			if (hit.collider.gameObject.CompareTag (tag)) {
				result = result | 1;
			}
		}

		hit = Physics2D.Raycast (transform.position + new Vector3(spriteWidth/2, -spriteHeight/2,0), Vector2.down, 0.4f,layerMask);
		Debug.DrawRay (transform.position + new Vector3(spriteWidth/2, -spriteHeight/2,0), Vector2.down * 0.4f, Color.red , 2);
		if (hit.collider != null) {
			if (hit.collider.gameObject.CompareTag (tag)) {
				result = result | 2;
			}
		}

		hit = Physics2D.Raycast (transform.position + new Vector3(-spriteWidth/2, -spriteHeight/2,0), Vector2.down, 0.4f,layerMask);
		Debug.DrawRay (transform.position + new Vector3(-spriteWidth/2, -spriteHeight/2,0), Vector2.down * 0.4f, Color.red , 2);
		if (hit.collider != null) {
			//Debug.Log ("intoHitCollider");	
			if (hit.collider.gameObject.CompareTag (tag)) {
				result = result | 2;
			}
		}

		hit = Physics2D.Raycast (transform.position + new Vector3(-spriteWidth/2, -spriteHeight/2,0), Vector2.left, 0.4f,layerMask);
		Debug.DrawRay (transform.position + new Vector3(-spriteWidth/2, -spriteHeight/2,0), Vector2.left * 0.4f, Color.red , 2);
		if (hit.collider != null) {
			if (hit.collider.gameObject.CompareTag (tag)) {
				result = result | 4;
			}
		}

		hit = Physics2D.Raycast (transform.position + new Vector3(-spriteWidth/2, spriteHeight/2,0), Vector2.left, 0.4f,layerMask);
		Debug.DrawRay (transform.position + new Vector3(-spriteWidth/2, spriteHeight/2,0), Vector2.left * 0.4f, Color.red , 2);
		if (hit.collider != null) {
			if (hit.collider.gameObject.CompareTag (tag)) {
				result = result | 4;
			}
		}
			
		hit = Physics2D.Raycast (transform.position + new Vector3(spriteWidth/2, spriteHeight/2,0), Vector2.right, 0.4f,layerMask);
		Debug.DrawRay (transform.position + new Vector3(spriteWidth/2, spriteHeight/2,0), Vector2.right * 0.4f, Color.red , 2);
		if (hit.collider != null) {
			if (hit.collider.gameObject.CompareTag (tag)) {
				result = result | 8;
			}
		}

		hit = Physics2D.Raycast (transform.position + new Vector3(spriteWidth/2, -spriteHeight/2,0), Vector2.right, 0.4f,layerMask);
		Debug.DrawRay (transform.position + new Vector3(spriteWidth/2, -spriteHeight/2,0), Vector2.right * 0.4f, Color.red , 2);
		if (hit.collider != null) {
			if (hit.collider.gameObject.CompareTag (tag)) {
				result = result | 8;
			}
		}
		//Debug.Log (result);
		return result;
	}

	public void SetInputEnabled(bool setEnabled) {
		isInputEnabled = setEnabled;
	}
}
