﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text scoreText;


	// Use this for initialization
	void Start () {
		scoreText = scoreText.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		DisplayScore ();
	}

	public void DisplayScore() {
		scoreText.text = "Score: " + GameController.instance.GetCorrectAnswerCount() + "/" +
				GameController.instance.GetNumberOfQuestions();
	}
		
}
