using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkSpeed;
	public float jumpHeight;
	public float airAccel;
	public float slideSpeed;
	public float wallJumpHeight;
	public float wallJumpAngle;

	private Rigidbody2D myBody;
	private bool isGrounded;
	private bool isWalledL;
	private bool isWalledR;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//[STATE CHECK] Performs raycasts to set boolean values indicating if touching the floor, a left wall, or a right wall
		isGrounded = false;
		isWalledL = false;
		isWalledR = false;
		RaycastHit2D groundedCheck = Physics2D.Raycast (transform.position,transform.up*-1.0f,0.53f);
		if(groundedCheck.collider!=null){
			isGrounded=true;
		}
		RaycastHit2D walledLCheck = Physics2D.Raycast (transform.position,transform.right*-1.0f,0.53f);
		if(walledLCheck.collider!=null){
			isWalledL=true;
		}
		RaycastHit2D walledRCheck = Physics2D.Raycast (transform.position,transform.right,0.53f);
		if(walledRCheck.collider!=null){
			isWalledR=true;
		}

		//[AIR MOVEMENT] Accelerate horizontal velocity as though in the air.  This change will be overwritten later if touching ground
		Vector2 resultVelo = myBody.velocity;
		resultVelo.x += Input.GetAxis ("Horizontal") * airAccel * Time.deltaTime;
		resultVelo.x = Mathf.Clamp (resultVelo.x,-walkSpeed,walkSpeed);

		//[GROUND MOVEMENT] If touching ground, instantly jump to full speed movement in desired direction as though running. When space is pressed, instantly change vertical velocity as though jumping
		if(isGrounded){
			resultVelo.x = Input.GetAxis ("Horizontal") * walkSpeed;
			if(Input.GetKeyDown("space")){
				resultVelo.y = jumpHeight;
			}
		}

		//[WALL MOVEMENT] If touching a wall,
		if(isWalledL){
			if(Input.GetAxis("Horizontal")==-1){
				resultVelo.y = Mathf.Max (resultVelo.y,slideSpeed);
			}
			if(Input.GetKeyDown("space")){
				resultVelo.x = wallJumpHeight * Mathf.Cos (wallJumpAngle);
				resultVelo.y = wallJumpHeight * Mathf.Sin (wallJumpHeight);
			}
		}

		if(isWalledR){
			if(Input.GetAxis("Horizontal")==1){
				resultVelo.y = Mathf.Max (resultVelo.y,slideSpeed);
			}
			if(Input.GetKeyDown("space")){
				resultVelo.x = wallJumpHeight * -1.0f * Mathf.Cos (wallJumpAngle);
				resultVelo.y = wallJumpHeight * Mathf.Sin (wallJumpHeight);
			}
		}

		myBody.velocity = resultVelo;
	}

/*	IEnumerator wallJumpL(){
		Vector2 resultVelo = myBody.velocity;
			while(isWalledL){
				resultVelo.x = wallJumpHeight * Mathf.Cos (wallJumpAngle);
				resultVelo.y = wallJumpHeight * Mathf.Sin (wallJumpHeight);
			yield return null;
			}
		myBody.velocity = resultVelo;
	}*/

/*	IEnumerator wallJumpR(){
		Vector2 resultVelo = myBody.velocity;
		while(isWalledR){
			resultVelo.x = wallJumpHeight * -1.0f * Mathf.Cos (wallJumpAngle);
			resultVelo.y = wallJumpHeight * Mathf.Sin (wallJumpHeight);
			yield return null;
		}
		myBody.velocity = resultVelo;
	}*/
}
