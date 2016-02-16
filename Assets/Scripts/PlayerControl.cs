using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using InControl;



//this script requires:
//	RigidBody2D
//	Animator
//	Collider2D

public class PlayerControl : MonoBehaviour {


	//bool that decided whether it isjumping or not.
	bool isJumping;

	//rigidBody to be applied the forces
	Rigidbody2D rigidBody;

	//normal gravity Scales
	public float gravityScale = 8f;

	//maximus speed when moving
	public float maxSpeed = 8f;

	//moving max force. Not important in this version, yet might needed as implementing game pad.
	public float maxForce =2f;

	//draging forces, a mechanic to slow down players.
	public float dragForce = 0.1f;

	//jumpling gravity scale used when using reverse jumping gravity
	public float jumpingGravityScale = 1f;

	//jumping lifting time counter, using an integer as counters instead of using time period to control.
	public int jumpingLiftingTimeCounter = 12;

	//jumping lifting force
	public float jumpingForce = 100f;

	//used for raycast collision detection;
	public float spriteHeight = 0.8f;
	public float spriteWidth = 0.8f;

	//jumpingLiftingTimeCounter / ratioJumpingFactor = minimal jumping counter that a jump must went through.
	public int ratioJumpingFactor=5;

	//input control.
	bool isInputEnabled = true;
	//InputDevice inputDevice;

	//jumpCounter used for calculate fixed updated jumping.
	int jumpCounter;

	public LayerMask layerMask;

	//walking animator.
	Animator walkingAnimator;

	void Awake(){
	}

	void Start(){
		//set rigidBody
		rigidBody = GetComponent<Rigidbody2D> ();

		//setting gravity
		rigidBody.gravityScale = gravityScale;

		//get animator
		walkingAnimator = GetComponent<Animator> ();
	}

	void Update(){
		//setting all the animators;
		walkingAnimator.SetFloat ("xSpeed", Mathf.Abs (rigidBody.velocity.x));
		walkingAnimator.SetBool ("isJumping", isJumping);

	}

	void FixedUpdate(){
		if (isInputEnabled) {
			InputMoving ();
		}
		ApplyDragForce ();
		JumpUpdate ();


		//resetLevel
		if (Input.GetKeyDown (KeyCode.R)) {
			//ResetLevel.instance.StartResetLevel ();
		}
	}

	public void StartJumping(){
		if (!isJumping) {
			//initializing of parameters

			//start jumping so that isJumping is true
			isJumping = true;

			//reverse the gravity
			rigidBody.gravityScale = -Mathf.Abs (jumpingGravityScale);

			//apply the initial upwards velocity;
			rigidBody.velocity += new Vector2 (0, 10f);

			//initialize the counter;
			jumpCounter = 0;
		}
	}

	void JumpUpdate(){
		if (!isJumping) {
			//If we touch the terrain collider before the jump action finishes, the gravityScale should be set back to normal
			rigidBody.gravityScale = Mathf.Abs (gravityScale);
			return;
		}
		// if:
		// 		you are holding jumping space and it doesn't exceed the maximum time counter forjumping, or the jumping time is still smaller than minimal jumping counters
		if ((Input.GetKey (KeyCode.Space) || (jumpCounter < jumpingLiftingTimeCounter / ratioJumpingFactor)) && (jumpCounter <= jumpingLiftingTimeCounter)) {
			//add upwards force
			rigidBody.AddForce (new Vector2 (0, jumpingForce ), ForceMode2D.Force);

			//clamp max velocity
			Vector2 v = rigidBody.velocity;
			v.y = Mathf.Clamp (v.y, -1.7f * maxSpeed, 1.7f * maxSpeed);
			rigidBody.velocity = v;

			//add jumpCounter
			jumpCounter++;

		} else {
			//means that it exceed the maximum lifting time, or doesn't press jump button anymore
			//apply back gravity;
			rigidBody.gravityScale = Mathf.Abs (gravityScale);
		}
	}

	void InputMoving(){
		//Input of moving left/right
		if (Input.GetKey (KeyCode.A)) {
			Vector2 f = new Vector2 (-maxForce, 0);
			rigidBody.AddForce (f,ForceMode2D.Impulse);

		} else if (Input.GetKey (KeyCode.D)) {
			Vector2 f = new Vector2 (maxForce, 0);
			rigidBody.AddForce (f,ForceMode2D.Impulse);
		}

		//clamping xSpeed
		Vector2 v = rigidBody.velocity;
		v.x = Mathf.Clamp (v.x, -maxSpeed, maxSpeed);
		rigidBody.velocity = v;

		//startJumping
		if (Input.GetKeyDown (KeyCode.Space)) {
			StartJumping ();
		}
	}


	//apply Drag Force
	void ApplyDragForce(){
		Vector2 v = rigidBody.velocity;
		v.y = 0;
		rigidBody.AddForce (dragForce * (-v) * v.magnitude);
	}





	// Decide which direction that the player has touched.
	public void OnCollisionEnter2D(Collision2D myCollision){
		if (myCollision.collider.CompareTag ("Terrain")) {
			if ((CollisionDirection ("Terrain") & 2) != 0) {
				isJumping = false;
			}
		}
	}


	int CollisionDirection(string tag){
		RaycastHit2D hit;
		//LayerMask layerMask = ~(LayerMask.NameToLayer("Terrain"));
		int result = 0;

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
		Debug.Log (result);
		return result;
	}

	public void SetInputEnabled(bool setEnabled) {
		isInputEnabled = setEnabled;
	}
}
