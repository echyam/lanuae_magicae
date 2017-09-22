using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalReached : MonoBehaviour {
	public string nextLevel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D obstacle) {
		if (obstacle.gameObject.tag == "Player") {
			print ("lvl completed!");
			//SceneManager.LoadScene (nextLevel);
		}
	}
}
