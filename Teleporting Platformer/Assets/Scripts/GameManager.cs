using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	bool isPaused;
	public GameObject pauseMenu;
	// Use this for initialization
	void Start () {
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			
			if (isPaused) {
				pauseMenu.SetActive (false);
				isPaused = false;
			} else {
				pauseMenu.SetActive (true);
				isPaused = true;
			}
		}

	}
	public bool isGamePaused(){
		return isPaused;
	}
}
