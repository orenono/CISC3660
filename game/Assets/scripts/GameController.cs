/*
 *  This script will hold variables and fuctions, that will
 *  hold their value throughout the game. This can be useful
 *  when we are changing scenes and we want to pass any data
 *  between the scenes.
*/

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private int correctAns = 0;
	private bool[] isTriggerUsed = new bool[8];
	private bool countdown = false;
	PlayerController player;
	Vector2 playerPos;

	void Awake() {

		// If an instance already exists, destroy this one
		if (instance != null)
			Destroy (this.gameObject);

		// Otherwise, make this the instance
		else
			instance = this;

		// Enable persistence across scenes
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		if (player == null)
			player = GameObject.FindObjectOfType (typeof(PlayerController)) as PlayerController; 


		// Score Variables
		//correctAns = 0;


	}

	/////////////////////////////////////////////
	//		QuestionTrigger Methods
	/////////////////////////////////////////////

	public void SetTriggerUse (int index, bool toggle) {
		isTriggerUsed[index] = toggle;
	}

	public bool GetTriggerUsed (int index) {
		return isTriggerUsed[index];
	}

	/////////////////////////////////////////////
	//		Score Methods
	/////////////////////////////////////////////

	public void IncreaseScore() {
		correctAns++;
	}

	public int GetNumberOfQuestions () {
		return Questions.qa.GetLength (0);
	}

	public int GetCorrectAnswerCount() {
		return correctAns;
	}

	public double GetScorePercentage() {
		return GetCorrectAnswerCount() / GetNumberOfQuestions ();
	}

	/////////////////////////////////////////////
	//		UI Methods
	/////////////////////////////////////////////

	public bool isCountdownPlaying() {
		return countdown;
	}

	public void SetCountdownActive(bool toggle) {
		countdown = toggle;
	}

	/////////////////////////////////////////////
	//		Player Methods
	/////////////////////////////////////////////

	public void SavePlayerPosition() {
		playerPos = player.transform.position;
	}

	public void LoadPlayerPosition() {
		player.transform.position = playerPos;
	}

}
