using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour {
	public Transform resultObj;
	private AudioSource nextButtonAudio;
	QuestionController qc;

	// Use this for initialization
	void Start () {
		if (qc == null)
			qc = GameObject.FindObjectOfType (typeof(QuestionController)) as QuestionController; 
		
		if (nextButtonAudio == null)
			nextButtonAudio = GetComponent <AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		nextButtonAudio.Play ();

		// Only allow the player to click next if they have picked an answer
		if (AnswerWithMouse.lockAnswer == true) {	

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
		}

		AnswerWithMouse.lockAnswer = false;

		// Reset result text, answer text and colors
		resultObj.GetComponent<TextMesh> ().text = "Pick an answer";	
		qc.ResetAnswerColors (qc.ans1, Color.white, 36);
		qc.ResetAnswerColors (qc.ans2, Color.white, 36);
		qc.ResetAnswerColors (qc.ans3, Color.white, 36);
		qc.ResetAnswerColors (qc.ans4, Color.white, 36);
	}
				
}
