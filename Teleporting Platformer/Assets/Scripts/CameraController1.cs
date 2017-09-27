using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour {
	public GameObject _player;
	public float speed;
	private float initY;
	private float initZ;
	// Use this for initialization
	void Start () {
		initY = transform.position.y;
		initZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 destVec = transform.position;
		destVec.x += (_player.transform.position.x - destVec.x) * speed * Time.deltaTime;
		destVec.y += (_player.transform.position.y - destVec.y) * speed * Time.deltaTime;
		transform.position = destVec;
	}
}
