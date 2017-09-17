using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkSpeed;
	public float jumpHeight;

	private Rigidbody2D myBody;
	private bool isGrounded;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = false;
		Vector2 origin = new Vector2 (0.0f, 0.0f);
		Vector2 direction = new Vector2 (0.0f, -1.0f);
		RaycastHit2D groundedCheck = Physics2D.Raycast (origin,direction,0.52f);
		if(groundedCheck!=null){
			isGrounded=true;
		}
		Debug.Log ("Grounded" + isGrounded);

		Vector2 resultVelo = myBody.velocity;
		resultVelo.x = Input.GetAxis ("Horizontal") * walkSpeed;
		if(Input.GetKeyDown("space")&&isGrounded){
			resultVelo.y = jumpHeight;
		}
		myBody.velocity = resultVelo;
	}
}
