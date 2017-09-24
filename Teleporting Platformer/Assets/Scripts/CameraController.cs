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
		// follow the player
		transform.position = player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 playerPos = player.transform.position;
		// enforce camera x,y within minimum bounds
		float x = Mathf.Max(playerPos.x, minX);
		float y = Mathf.Max(playerPos.y, minY);
		// enforce camera x,y within maximum bounds
		x = Mathf.Min (x, maxX);
		y = Mathf.Min (y, maxY);

		transform.position = new Vector3 (x, y, playerPos.z);
		print ("(" + x + "," + y + "," + playerPos.z + ")");	// track updated camera coordinates
	}
}
