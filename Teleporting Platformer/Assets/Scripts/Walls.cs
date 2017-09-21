using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {
	private bool prevCollision1 = false;	// so kunai can pass through without changing behavior
	private bool prevCollision2 = false;	// so kunai can pass through without changing behavior
	private bool hit = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (prevCollision1 && prevCollision2) {
			prevCollision2 = false;
		}
		// if kunai finished passing through wall, set collision boolean to false
		if (prevCollision1 && !prevCollision2) {
			prevCollision1 = false;
			hit = false;
		}
	}
	private void OnTriggerEnter2D(Collider2D other){
		// set collision boolean to true on impact
		if (!prevCollision1 && !prevCollision2) {
			if (other.gameObject.tag == "kunai") {
				hit = true;
				prevCollision1 = true;
			}
		// if still detecting collision within same wall
		} else if (prevCollision1) {
			prevCollision2 = true;
		}
	}
	// public getter for interactions like spinner or switcheroo
	public bool isHit(){ return hit; }
}
