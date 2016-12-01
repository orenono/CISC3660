using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviorLv01 : MonoBehaviour {

	public GameObject[] DisplayWhenPaused;
	public GameObject[] DisplayWhenResumed;
	public bool paused;

	// Use this for initialization
	void Start () {

		//if (pauseText == null) {
		DisplayWhenPaused = GameObject.FindGameObjectsWithTag("Paused");
		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (false);
		//if (pauseText == null) {
		DisplayWhenResumed = GameObject.FindGameObjectsWithTag("Unpaused");
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (true);

		//pauseText.SetActive(false);
		paused = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump") && !paused) 
			PauseGame ();
		else if (Input.GetButtonDown ("Jump") && paused) 
			ResumeGame ();
		else if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene("startMenu");
		}
	}

	public void PauseGame()
	{
		paused = true;
		Time.timeScale = 0.0f;
		//pauseText.SetActive (true);
		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (true);
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (false);
	}

	public void ResumeGame()
	{
		paused = false;
		Time.timeScale = 1.0f;
		//pauseText.SetActive (false); 
		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (false);
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (true);
	}

	public void Menu()
	{
		SceneManager.LoadScene ("startMenu");
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
