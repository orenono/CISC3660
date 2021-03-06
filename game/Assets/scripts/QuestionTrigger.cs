﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class QuestionTrigger : MonoBehaviour {
	public static int QuestionsCounter;
	public GameObject player;



	// Use this for initialization
	void Start () {
		gameObject.GetComponent<QuestionTrigger> ();
		if (GameController.instance.GetTriggerUsed (int.Parse(gameObject.name)) == true) {
			Debug.Log ("bool index: " + (int.Parse (gameObject.name)));
			this.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// When the player collides with QA trigger, swith to QA scene
	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {

			gameObject.GetComponent<Renderer> ().material.color = Color.black;
			GameController.instance.SetTriggerUse (int.Parse (gameObject.name), true);

			Debug.Log ("Changing scene to Dialogue");
			//SceneManager.LoadScene ("dialogue");

			SceneManager.LoadScene ("QA_scene");

		}
	}

	public int GetCounter() {
		return QuestionsCounter;
	}




	IEnumerator wait(float n) {
		yield return new WaitForSeconds (n);
	}
}
