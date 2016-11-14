using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour {
	public Transform resultObj;
	private AudioSource nextButtonAudio;

	// Use this for initialization
	void Start () {

		if (nextButtonAudio == null)
			nextButtonAudio = GetComponent <AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		nextButtonAudio.Play ();
		
		// Change to another question and
		// limit the counter within the question array
		if (QuestionController.counter <= Questions.qa.GetLength (0)) {
			QuestionController.counter++;

			// When it's the 4th question, change the next button text
			if (QuestionController.counter % 3 == 0) {
				GetComponent<TextMesh> ().text = "Finish";
			}

			// Once the player hits 'Finish' button, change the scene
			if (QuestionController.counter % 4 == 0) {

				//QuestionController.counter = 0;
				Debug.Log ("Changing scene to level01");
				SceneManager.LoadScene ("level01");
			}
		}


		AnswerWithMouse.lockAnswer = false;
		resultObj.GetComponent<TextMesh> ().text = "";	
	}
				
}
