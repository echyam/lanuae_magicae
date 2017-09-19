using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour {
	public float speed;
	private Rigidbody2D kunaiRB;
	// Use this for initialization
	void Start () {
		kunaiRB = GetComponent<Rigidbody2D> ();
		kunaiRB.position = transform.position;
		// move the kunai via velocity, not position updates
		kunaiRB.velocity = transform.rotation * new Vector2 (speed,0);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += speed * transform.right * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D other){
		// if kunai should stick
		if (other.gameObject.tag == "wall") {
			kunaiRB.velocity = Vector2.zero;

		// if kunai should completely reverse direction
		} else if (other.gameObject.tag == "bounce_back") {
			Quaternion reverse = Quaternion.AngleAxis (180, transform.forward);
			transform.rotation *= reverse;
			kunaiRB.velocity = reverse * kunaiRB.velocity;

		// if kunai should react like light
		} else if (other.gameObject.tag == "bounce_light") {
			
			// flip the kunai in the right direction
			kunaiRB.rotation = 180 - kunaiRB.rotation;

			// bounce horizontally
			if (other.transform.position.x - transform.position.x <= other.transform.localScale.x/2) {
				kunaiRB.velocity = new Vector2(kunaiRB.velocity.x, kunaiRB.velocity.y * -1);
			}
			// bounce vertically
			else if (other.transform.position.y - transform.position.y <= other.transform.localScale.y/2) {
				kunaiRB.velocity = new Vector2(kunaiRB.velocity.x * -1, kunaiRB.velocity.y);
			}
		
		// if kunai should bounce back faster
		} else if (other.gameObject.tag == "bounce_fast") {
			kunaiRB.velocity = new Vector2 (kunaiRB.velocity.x * 2, kunaiRB.velocity.y * 2);
		
		// if kunai should bounce back slower
		} else if (other.gameObject.tag == "bounce_slow") {
			kunaiRB.velocity = new Vector2 (kunaiRB.velocity.x * 0.5f, kunaiRB.velocity.y * 0.5f);
		}
	}
}
