using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startButton;
	public Button exitButton;
	public Button instructionsButton;
	public Canvas playMenu;
	public InputField input;
	public Slider musicSlider;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startButton = startButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		playMenu = playMenu.GetComponent < Canvas> ();
		instructionsButton = instructionsButton.GetComponent<Button>();

		input = GetComponent<InputField> ();


		quitMenu.enabled = false;
		playMenu.enabled = false;
	}

	public void ExitPressed()
	{
		quitMenu.enabled = true;
		exitButton.enabled = false;
		startButton.enabled = false;
		instructionsButton.enabled = false;
	}

	public void DontQuitPress()
	{
		quitMenu.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;
		playMenu.enabled = false;
		instructionsButton.enabled = true;

	}

	public void PlayPress()
	{
		quitMenu.enabled = false;
		playMenu.enabled = true;
		exitButton.enabled = false;
		startButton.enabled = false;
		instructionsButton.enabled = false;
	}

	public void InstructionsPressed(){

		SceneManager.LoadScene ("Instructions");
	}



	public void StartGame()
	{
    //  string pName = input.text;
	//	print (pName);	
	//	GameControl.Instance.setName (pName);
		SceneManager.LoadScene("IntroCutscene");
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	public void HighScore()
	{
		SceneManager.LoadScene("HighScore");
	}

	public void Instuction()
	{
		SceneManager.LoadScene("Instuction");
	}

	public void Setting()
	{
		SceneManager.LoadScene("Setting");
	}

	public void returnToMain()
	{
		SceneManager.LoadScene("startMenu");
	}

	public void OnMusicVolumeChange() {
		GameControl.Instance.musicVolume = musicSlider.value;
	}


}
	
