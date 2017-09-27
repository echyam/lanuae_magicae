using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GrateElectricPrefab : MonoBehaviour {
	public Sprite[] frames;

	public float framesPerSecond = 5;

	SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		StartCoroutine (PlayAnimation ());
	}

	IEnumerator PlayAnimation(){
		int currentFrameIndex = 0;
		while (currentFrameIndex < frames.Length) {
			spriteRenderer.sprite = frames [currentFrameIndex];
			yield return new WaitForSeconds(1f / framesPerSecond); // this halts the functions execution for x seconds. Can only be used in coroutines.
			currentFrameIndex++;
			if (currentFrameIndex == frames.Length) {
				currentFrameIndex = currentFrameIndex % (int) framesPerSecond;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D _collision){
		if(_collision.gameObject.tag=="Player"){
			PlayerController _playerScript = _collision.gameObject.GetComponent<PlayerController>();
			_playerScript.kill();
		}
	}
}
