using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	private Button curButton;

	void Start(){
		curButton = gameObject.GetComponent<Button> ();
		curButton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick(){
		if (gameObject.name == "StartButton") {
			Debug.Log ("Start button");
			LoadByIndex (1);
		} else if (gameObject.name == "QuitButton") {
			Debug.Log ("Quit Button");
			Quit ();
		} else if (gameObject.name == "BackButton") {
			LoadByIndex (0);
		}
	}
	void LoadByIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}

	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}
}

