using UnityEngine;
using System.Collections;

public class Questions : MonoBehaviour {

	// Create a 2D string array for questions and answers
	public static string[,] qa = new string[,] {
		{
			"What's the most common cancer?",
			"Lung Cancer",
			"Bladder Cancer",
			"Skin Cancer",
			"Breast Cancer",
			"3",
		},

		{
			"In the 1990's, about how many women has \ncontracted breast cancer??",
			"1,100,000",
			"2,600,000",
			"3,500,000",
			"2,000,000",
			"4",
		},

		{
			"Which Cancer is most deadly?",
			"Kidney Cancer",
			"Lung Cancer",
			"Breast Cancer",
			"Colon Cancer",
			"2",
		},

		{
			"How much money is spent on Cancer??",
			"20 billion",
			"45 billion",
			"100 billion",
			"75 billion",
			"3"
		}
	};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

}
