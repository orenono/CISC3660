using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviorLv01 : MonoBehaviour {

	public GameObject[] DisplayWhenPaused;
	public GameObject[] DisplayWhenResumed;
	public bool paused;
	public Transform playerTarget;
	public Transform enemyTarget;
	public Transform background;
	public float time;
	public Text jit1;
	public Text jit2;


	// Use this for initialization
	void Start () {
		DisplayWhenPaused = GameObject.FindGameObjectsWithTag("Paused");
		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (false);
		//if (pauseText == null) {
		DisplayWhenResumed = GameObject.FindGameObjectsWithTag("Unpaused");
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (true);
		time = Time.time;
		jit2.enabled = false;
		Destroy (jit1, 3);


		//pauseText.SetActive(false);
		paused = false;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - time >= 3 && Time.time - time <= 4){
			jit2.enabled = true;
			Destroy(jit2,3);
		}
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
		playerTarget.GetComponent<PlayerController> ().muteAudio ();
		enemyTarget.GetComponent<EnemyController> ().muteAudio ();
		background.GetComponent<backgroundMusic> ().muteAudio ();
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
		playerTarget.GetComponent<PlayerController> ().unmuteAudio ();
		enemyTarget.GetComponent<EnemyController> ().unmuteAudio ();
		background.GetComponent<backgroundMusic> ().unmuteAudio ();
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
