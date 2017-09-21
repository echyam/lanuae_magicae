
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerScript : MonoBehaviour {
	private const float radius = 1f;
	private const float wallLen = 2.5f;
	private bool prevHit = false;

	public GameObject[] walls;
	private GameObject[] blades;

	// Use this for initialization
	void Start () {
		float angle = 360f / walls.Length;
		blades = new GameObject[walls.Length];
		Quaternion rot;
		Vector2 initial = new Vector2 (0, 0);
		Vector2 displacement;
		GameObject blade;
		for(int i = 0; i < walls.Length; i++) {
			rot = Quaternion.AngleAxis(i*angle,transform.forward);
			displacement = rot * initial;
			blade = Instantiate (walls [i], (Vector2)transform.position + displacement, rot);
			blade.GetComponent<Rigidbody2D> ().angularVelocity = 30;
			blades [i] = blade;
		}
	}

	// Update is called once per frame
	void Update () {
		bool hit = false;
		foreach (GameObject blade in blades) {
			hit = hit || blade.GetComponent<Walls> ().isHit ();
		}
		if (hit && !prevHit) {
			rotateBlades ();
		}
		prevHit = hit;
	}
	private void OnTriggerEnter2D(Collider2D other){
	}
	private void rotateBlades() {
		Vector2 tempPos = blades [0].transform.position;
		Quaternion tempRot = blades [0].transform.rotation;
		int i = 0;
		while (i < blades.Length - 1) {
			blades [i].transform.position = blades [i + 1].transform.position;
			blades [i].transform.rotation = blades [i + 1].transform.rotation;
			i++;
		}
		blades [i].transform.position = tempPos;
		blades [i].transform.rotation = tempRot;
	}
}
