
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherooScript : MonoBehaviour {
	private Rigidbody2D switcherooRB;
	private Collider2D switcherooCol;
	private SpriteRenderer switcherooSR;
	private int wallTypeInd = 0;

	// track kunai collision
	private bool prevCollision1 = false;	// so kunai can pass through without changing behavior
	private bool prevCollision2 = false;	// so kunai can pass through without changing behavior

	// save colors corresponding to kunai interactions
	private Color revColor = new Color (144f/255f, 35f/255f, 35f/255f, 255f/255f);		// red = reverse
	private Color lightColor = new Color (186f/255f, 183f/255f, 79f/255f, 255f/255f);	// yellow = light
	private Color fastColor = new Color (88f/255f, 146f/255f, 86f/255f, 255f/255f);		// green = faster
	private Color slowColor = new Color (68f/255f, 149f/255f, 204f/255f, 255/255f);		// blue = slower

	// boolean if switch interaction type every second
	public bool timer = false;

	// list of interaction types (passed as prefabs)
	public GameObject[] wallTypes;

	// Use this for initialization
	void Start () {
		switcherooRB = GetComponent<Rigidbody2D> ();
		switcherooCol = GetComponent<Collider2D> ();
		switcherooSR = GetComponent<SpriteRenderer> ();
		this.tag = wallTypes[0].tag;	// set initial tag to 1st wall type
		StartCoroutine (alternateSwitcherooCoroutine ());
	}

	// Update is called once per frame
	void Update () {
		// use modulus to keep index in array range
		wallTypeInd = wallTypeInd % wallTypes.Length;
		// update tag for next interaction
		this.tag = wallTypes [wallTypeInd].tag;

		// adjust color according to new interaction type
		switch (this.tag) {
			case "bounce_back":
				switcherooSR.color = revColor;
				break;
			case "bounce_light":
				switcherooSR.color = lightColor;
				break;
			case "bounce_fast":
				switcherooSR.color = fastColor;
				break;
			case "bounce_slow":
				switcherooSR.color = slowColor;
				break;
		}
		// if not in timer mode, track collisions and switch every time hit by kunai
		if (!timer) {
			if (prevCollision1 && prevCollision2) {
				prevCollision2 = false;
			}
			if (prevCollision1 && !prevCollision2) {
				prevCollision1 = false;
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D other){
		// if not in timer mode, switch every time hit by kunai
		if (!timer) {
			if (!prevCollision1 && !prevCollision2) {
				if (other.gameObject.tag == "kunai") {
					wallTypeInd++;
					prevCollision1 = true;
				}
			} else if (prevCollision1) {
				prevCollision2 = true;
			}
		}
	}

	// timed coroutine for cycling through interactions
	IEnumerator alternateSwitcherooCoroutine() {
		while (timer) {
			yield return new WaitForSeconds(1f);
			wallTypeInd++;
		}
	}
}
