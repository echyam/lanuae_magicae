using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkSpeed;
	public float jumpHeight;
	public float airAccel;
	public float airSpeedLimit;
	public float slideSpeed;
	public float wallJumpHeight;
	public float wallJumpAngle;

	private Rigidbody2D myBody;
	private bool isGrounded;
	private bool isWalledL;
	private bool isWalledR;

	private Vector3 respawn;
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
		respawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//[STATE CHECK] Performs raycasts to set boolean values indicating if touching the floor, a left wall, or a right wall
		isGrounded = false;
		isWalledL = false;
		isWalledR = false;
		RaycastHit2D groundedCheck = Physics2D.Raycast (transform.position,transform.up*-1.0f,0.53f);
		if(groundedCheck.collider!=null&&groundedCheck.collider.tag!="Switch"){
			isGrounded=true;
		}
		RaycastHit2D walledLCheck = Physics2D.Raycast (transform.position,transform.right*-1.0f,0.53f);
		if(walledLCheck.collider!=null&&walledLCheck.collider.tag!="Switch"){
			isWalledL=true;
		}
		RaycastHit2D walledRCheck = Physics2D.Raycast (transform.position,transform.right,0.53f);
		if(walledRCheck.collider!=null&&walledRCheck.collider.tag!="Switch"){
			isWalledR=true;
		}

		//[AIR MOVEMENT] Accelerate horizontal velocity as though in the air.  This change will be overwritten later if touching ground
		Vector2 resultVelo = myBody.velocity;
		resultVelo.x += Input.GetAxis ("Horizontal") * airAccel * Time.deltaTime;
		resultVelo.x = Mathf.Clamp (resultVelo.x,-airSpeedLimit,airSpeedLimit);

		//[GROUND MOVEMENT] If touching ground, instantly jump to full speed movement in desired direction as though running. When space is pressed, instantly change vertical velocity as though jumping
		if(isGrounded){
			resultVelo.x = Input.GetAxis ("Horizontal") * walkSpeed;
			if(Input.GetKeyDown("space")){
				resultVelo.y = jumpHeight;
			}
		}

		//[WALL MOVEMENT] If touching a wall, the act of pressing the horizontal button in the direction of the wall should limit downard velocity to no more than slideSpeed as though clinging to the wall. 
		//When space is pressed, set horizontal and vertical velocity such that speed is wallJumpSpeed and direction is wallJumpAngle above horizontal line as though kicking of the wall to jump.
		if (isWalledL) {
			if (Input.GetAxis ("Horizontal") < 0) {
				resultVelo.y += -9.81f * Time.deltaTime;
				resultVelo.y = Mathf.Max (resultVelo.y, slideSpeed);

			}
			//To possibly add back in later; let's player wall sliding move away from wall instantly rather than accelerate away
/*			if(Input.GetAxis("Horizontal")==		1){
				resultVelo.x = walkSpeed;
			}*/
			if(Input.GetKeyDown("space")&&!isGrounded){
				resultVelo.x = wallJumpHeight * Mathf.Cos (wallJumpAngle*Mathf.PI);
				resultVelo.y = wallJumpHeight * Mathf.Sin (wallJumpAngle*Mathf.PI);
			}
		}

		if(isWalledR){
			if(Input.GetAxis("Horizontal")> 0){
				resultVelo.y += -9.81f * Time.deltaTime;
				resultVelo.y = Mathf.Max (resultVelo.y,slideSpeed);
			}
			//Same as above but for other wall
/*			if(Input.GetAxis("Horizontal")==-1){
				resultVelo.x = walkSpeed*-1;
			}*/
			if(Input.GetKeyDown("space")&&!isGrounded){
				resultVelo.x = wallJumpHeight * -1.0f * Mathf.Cos (wallJumpAngle*Mathf.PI);
				resultVelo.y = wallJumpHeight * Mathf.Sin (wallJumpAngle*Mathf.PI);
			}
		}

		myBody.velocity = resultVelo;
	}

	public void kill(){
		transform.position = respawn;
	}

	//Coroutines I thought I needed at a time put now it seems I don't I'll likely delete them later but for now holding on just to be sure
/*	private IEnumerator wallJumpL(){
		while(isWalledL){
			Vector2 resultVelo = myBody.velocity;
			resultVelo.x = wallJumpHeight * Mathf.Cos (wallJumpAngle*Mathf.PI);
			resultVelo.y = wallJumpHeight * Mathf.Sin (wallJumpAngle*Mathf.PI);
			myBody.velocity = resultVelo;
			yield return 0;
		}
	}

	private IEnumerator wallJumpR(){
		while(isWalledR){
			Vector2 resultVelo = myBody.velocity;
			resultVelo.x = wallJumpHeight * -1.0f * Mathf.Cos (wallJumpAngle*Mathf.PI);
			resultVelo.y = wallJumpHeight * Mathf.Sin (wallJumpAngle*Mathf.PI);
			myBody.velocity = resultVelo;
			yield return 0;
		}
	}*/
}
