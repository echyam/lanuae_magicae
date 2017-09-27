using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeKunaiController : MonoBehaviour {
	public GameObject _player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Destroy (gameObject);
		}
		if(Input.GetMouseButtonDown(1)){
			_player.transform.position = transform.position;
			Destroy (gameObject);
		}
	}
}
