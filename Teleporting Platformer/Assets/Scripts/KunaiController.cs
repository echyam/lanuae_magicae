﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += speed * transform.right * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Method Called!");
		if (other.gameObject.tag != "Player") {
			speed = 0.0f;
		}
	}
}
