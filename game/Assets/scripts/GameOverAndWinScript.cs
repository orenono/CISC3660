using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverAndWinScript : MonoBehaviour {

	public Button restartButton;
	public Button MenuButton;

	// Use this for initialization
	void Start () {
		restartButton = restartButton.GetComponent<Button> ();
		MenuButton = MenuButton.GetComponent<Button> ();
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void restartPressed() {

		SceneManager.LoadScene ("level01");
	}

	public void menuPressed() {

		SceneManager.LoadScene ("startMenu");
	}
}
