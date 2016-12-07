using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KnockingScript : MonoBehaviour {

	private AudioSource audio;

	// Use this for initialization
	void Start () {

		if (audio == null)
			audio = GetComponent <AudioSource> ();
	
	}

	// Update is called once per frame
	void Update () {

		if (audio.time > 8 || Input.GetKeyDown (KeyCode.Space)) {
			audio.Stop ();
			LoadNextScene ();

		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("startMenu");	
		}
	}

	void LoadNextScene()
	{
		SceneManager.LoadScene ("dialogue2");
	}
}
