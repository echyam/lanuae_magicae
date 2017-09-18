using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiManager : MonoBehaviour {
	private GameObject currentKun;
	public GameObject kunaiPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 direcVec = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		float deg = (Mathf.Atan2 (direcVec.y, direcVec.x) * Mathf.Rad2Deg);
		transform.rotation = Quaternion.AngleAxis (deg, transform.forward);
		if(Input.GetMouseButtonDown(0)){
			if(currentKun!=null){
				Destroy (currentKun);
			}
			currentKun = Instantiate (kunaiPrefab);
			currentKun.transform.position = transform.position;
			currentKun.transform.rotation = transform.rotation;
		}
		if(Input.GetMouseButtonDown(1)&&currentKun!=null){
			transform.parent.transform.position= currentKun.transform.position;
			Destroy (currentKun);
		}
	}
}
