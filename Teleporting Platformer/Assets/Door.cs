using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
	public Sprite[] frames;

	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D collision){
		DoorActivate ();
	}

	void DoorActivate(){
		int curScene = SceneManager.GetActiveScene ().buildIndex;
		int curIndex = 0;

		Debug.Log (curScene);

		if (curIndex == 0) {
			curIndex = 1;
		} else if (curIndex == 1){
			curIndex = 0;
		}

		spriteRenderer.sprite = frames [curIndex];
	}
}
