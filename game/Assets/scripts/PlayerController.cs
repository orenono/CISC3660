using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	private Rigidbody2D rb2d;
	public float speed;
	public Health playerHealth;
	private AudioSource audio;
	private bool isFacingRight;
	private Animator animator;
	private float moveHorizontal;
	private float moveVertical;
	private float speedBoost;

	public GameObject startStreet, spawnStreet, policyStation;
	public Vector2 spawnLocation;
	public int spawnLimit;
	public Text winTxt;

	void Awake() {
		
		if (audio == null) {
			audio = GetComponent<AudioSource> ();
		}
	}

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		isFacingRight = true;
		speed = 3.0f;
		speedBoost = 1.0f;

		spawnLimit = 5;
		spawnLocation = new Vector2 (startStreet.transform.position.x, startStreet.transform.position.y);
		winTxt.enabled = false;

		GameController.instance.LoadData ("Player"); 
		//GameController.instance.LoadData ("Healthbar"); // doesn't work
	
	}
	
	// Update is called once per frame
	void Update () {
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");

		if (GameController.instance.IsDebugging()) {
			if (Input.GetKeyDown (KeyCode.LeftShift))
				speedBoost = 8.0f;
			if (Input.GetKeyUp (KeyCode.LeftShift))
				speedBoost = 1.0f;
		}

		Vector2 movement = new Vector2 (moveHorizontal * speed, moveVertical * speed * speedBoost);
		MovePlayer (movement);

		if ((moveHorizontal < 0 && isFacingRight) || (moveHorizontal > 0 && !isFacingRight))
			Flip ();

		//make footsteps sound when player moves
		if (IsMoving () && audio.isPlaying == false) {
			audio.Play ();
		} 
		// stop footsteps soundswhen player stops moving
		else if (!IsMoving () && audio.isPlaying) {
			audio.Stop ();
		}

		if (this.transform.position.y >= spawnLocation.y && spawnLimit > 0) {
			spawnLimit--;
			spawnLocation = new Vector2 (spawnLocation.x, spawnLocation.y + 63);
			Instantiate (spawnStreet, spawnLocation, Quaternion.identity);
		} 
		else if (spawnLimit == 0) {
			spawnLocation = new Vector2 (spawnLocation.x, spawnLocation.y + 38);
			Instantiate (policyStation, spawnLocation, Quaternion.identity);    
		}
	}


	//Is the player moving?
	bool IsMoving() {
		if (moveVertical == 0 && moveHorizontal == 0)
			return false;
		else
			return true;
	}

	void MovePlayer(Vector2 direction) {	
		// Get the player's current position
		Vector2 pos = transform.position;

		// Calculate the new position
		pos += direction * speed * Time.deltaTime;

		// Update the player's position
		transform.position = pos;
	}


	// Decrease player's health if the enemy collides with it
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			animator.SetBool("hit", true);
			playerHealth.DecreaseHealth ();
			//other.gameObject.SetActive (false);

		}
		if (other.gameObject.CompareTag ("PoliceStation")) {
			if (GameController.instance.GetCorrectAnswerCount () >= 22) {
				Time.timeScale = 0.0f;
				winTxt.fontSize = 70;
				winTxt.text = "You Win!";
				winTxt.enabled = true;
			}
			else {

				winTxt.fontSize = 30;
				winTxt.text = "You need at least 22 correct answers to enter!";
				winTxt.enabled = true;
			}
		}

	}

	void OnTriggerExit2D (Collider2D other) {

		if (other.gameObject.CompareTag ("PoliceStation")) {

			winTxt.enabled = false;
		}
	}



	// killing the player code
	public bool IsPlayerDead () {
		if (playerHealth.GetCurrentHealth () == 0)
			return true;
		else
			return false;
	}

	public void KillThePlayer() {
		if (IsPlayerDead()) {
			rb2d.gameObject.SetActive (false);

			// TODO
			// Play the gameover movie (killer killing the player, or something close to it)

			// Show the final score

			// Give the user an option to play the game again

		}
	}

	public void Flip() {
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x * -1;
		transform.localScale = playerScale;
		isFacingRight = !isFacingRight;
	}

/*
	public void SavePlayerPos() {
		PlayerPrefs.SetFloat ("X", transform.position.x);
		PlayerPrefs.SetFloat ("Y", transform.position.y);
		PlayerPrefs.SetFloat ("Z", transform.position.z);
	}

	public void LoadPlayerPos(float xOffset, float yOffset, float zOffset) {
		//transform.position.x = PlayerPrefs.GetFloat ("X");
		//transform.position.y = PlayerPrefs.GetFloat ("Y");
		//transform.position.z = PlayerPrefs.GetFloat ("Z");

		Vector3 playerPos = new Vector3 (PlayerPrefs.GetFloat ("X") + xOffset, PlayerPrefs.GetFloat ("Y") 
										+ yOffset, PlayerPrefs.GetFloat ("Z") + zOffset);
		transform.position = playerPos;
	}
	*/


}
