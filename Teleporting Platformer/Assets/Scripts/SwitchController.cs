using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {
	public GameObject _mySubject;
	public Sprite[] _sprites;
	public bool _playerOnly;
	private SpriteRenderer _myRenderer;
	private Switchable _subjectScript;
	private bool _isOn;
	// Use this for initialization
	void Start () {
		_myRenderer = GetComponent<SpriteRenderer> ();
		_myRenderer.sprite = _sprites [0];
		_subjectScript = _mySubject.GetComponent<Switchable> ();
		_isOn = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(_isOn&&_subjectScript!=null&&((other.gameObject.tag=="Player"&&_playerOnly)||(other.gameObject.tag=="kunai"&&!_playerOnly))){
			_subjectScript.throwSwitch ();
			_isOn = false;
			_myRenderer.sprite = _sprites [1];
		}
	}
}
