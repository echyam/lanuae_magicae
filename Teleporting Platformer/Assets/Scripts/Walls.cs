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
		if (prevCollision1 && !prevCollision2) {
			prevCollision1 = false;
			hit = false;
		}
	}
	private void OnTriggerEnter2D(Collider2D other){
		if (!prevCollision1 && !prevCollision2) {
			if (other.gameObject.tag == "kunai") {
				hit = true;
				prevCollision1 = true;
			}
		} else if (prevCollision1) {
			prevCollision2 = true;
		}
	}
	public bool isHit(){ return hit; }
}
