// created with help from Unity tutorial

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	// Use this for initialization
	void Start () {
		transform.position = player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 playerPos = player.transform.position;
		float x = Mathf.Max(playerPos.x,minX);
		x = Mathf.Min (x, maxX);
		float y = Mathf.Max(playerPos.y, minY);
		y = Mathf.Min (y, maxY);
		transform.position = new Vector3 (x, y, playerPos.z);
		print ("(" + x + "," + y + "," + playerPos.z + ")");
		// print ("(" + this.transform.position.x + "," + this.transform.position.y + "," + this.transform.position.z + ")");
		//transform.position = player.transform.position;
	}
}
