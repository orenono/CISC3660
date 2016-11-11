using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextMovingScript : MonoBehaviour {

	private RectTransform textPosition;
	public float speed = 7.0f;

	// Use this for initialization
	void Start () {
		if (textPosition == null)
		textPosition = GetComponent<RectTransform> ();

	
	}
	
	// Update is called once per frame
	void Update () {

		textPosition.Translate (-1 * speed, 0, 0);

		if ((textPosition.position.x <= -13000) || Input.anyKey == true)
			LoadGame ();
	
	}

	void LoadGame()
	{
		SceneManager.LoadScene ("level01");
	}
}
