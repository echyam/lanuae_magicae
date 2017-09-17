using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkSpeed;
	public float jumpHeight;
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

		Debug.Log ("Walled Left:" + isWalledL + "Walled Right: " + isWalledR);

		Vector2 resultVelo = myBody.velocity;
		resultVelo.x = Input.GetAxis ("Horizontal") * walkSpeed;
		if(Input.GetKeyDown("space")&&isGrounded){
			resultVelo.y = jumpHeight;
		}

		if(isWalledL){
			if(Input.GetAxis("Horizontal")==-1){
				resultVelo.y = slideSpeed;
			}
			if(Input.GetKeyDown("space")){
				resultVelo.x = wallJumpHeight * Mathf.Cos (wallJumpAngle);
				resultVelo.y = wallJumpHeight * Mathf.Sin (wallJumpHeight);
			}
		}

		myBody.velocity = resultVelo;
	}
}
