using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrateElectricPrefab : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D _collision){
		if(_collision.gameObject.tag=="Player"){
			PlayerController _playerScript = _collision.gameObject.GetComponent<PlayerController>();
			_playerScript.kill();
		}
	}
}
