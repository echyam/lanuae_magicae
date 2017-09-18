using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 direcVec = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		float deg = (Mathf.Atan2 (direcVec.y, direcVec.x) * Mathf.Rad2Deg)/* - 90.0f*/;
		transform.rotation = Quaternion.AngleAxis (deg, transform.forward);
	}
}
