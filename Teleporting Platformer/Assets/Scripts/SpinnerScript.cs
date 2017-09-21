
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerScript : MonoBehaviour {
	private const float radius = 1f;
	private const float wallLen = 2.5f;
	private bool prevHit = false;

	// list of interaction types (passed as prefabs)
	public GameObject[] walls;

	// array of wall prefabs to be spun as windmill blades
	private GameObject[] blades;
	// length of windmill blades
	public float bladeLength = 5;
	// angular velocity of blades
	public float omega = 15;

	// Use this for initialization
	void Start () {
		
		// even angle between each blade
		float angle = 360f / walls.Length;

		// create windmill blades
		blades = new GameObject[walls.Length];
		Quaternion rot;
		Vector2 initial = Vector2.zero;										// blades placed at (0,0) the center of the spinner object
		Vector2 displacement;
		GameObject blade;
		for(int i = 0; i < walls.Length; i++) {
			rot = Quaternion.AngleAxis(i*angle,transform.forward);			// set orientation of blade
			displacement = rot * initial;									// find position to instantiate blade
			blade = Instantiate (walls [i], (Vector2)transform.position + displacement, rot);
			blade.transform.localScale = new Vector2 (bladeLength, 1);		// set blade length
			blade.GetComponent<Rigidbody2D> ().angularVelocity = omega;		// set angular velocity
			blades [i] = blade;												// add to array
		}
	}

	// Update is called once per frame
	void Update () {
		bool hit = false;
		foreach (GameObject blade in blades) {
			//hit = hit || blade.GetComponent<Walls> ().isHit ();
		}
		if (hit && !prevHit) {
			rotateBlades ();
		}
		prevHit = hit;
	}

	// old function never used - delete later
	private void OnTriggerEnter2D(Collider2D other){
	}

	// old function never used - delete later
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
