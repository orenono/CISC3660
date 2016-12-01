using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public GameObject player;
	public GameObject healthbar;
	public Image healthbarColor;

	private int maxHealth = 100;
	private float currHealth = 100f;

	// Use this for initialization
	void Start () {
		healthbarColor = healthbarColor.GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position;
	}

	public float GetCurrentHealth() {
		return currHealth;
	}

	public void SetCurrentHealth (float h) {
		currHealth = h;
	}
		
	public void DecreaseHealth() {
		if (currHealth > 0) {
			currHealth -= 25;
			SetHealthBar (currHealth / maxHealth);
			ChangeBarColor ();
		}
	}

	public void SetHealthBar (float amount) {
		healthbar.transform.localScale = new Vector3 (amount, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
	}

	public void ChangeBarColor() {
		if (currHealth <= 100 && currHealth > 75) 
			healthbarColor.color = new Color (0, 255, 0, 100); // green

		if (currHealth <= 75 && currHealth > 50) 
			healthbarColor.color = new Color (255, 255, 0, 100); // yellow

		if (currHealth <= 50 && currHealth > 25)
			healthbarColor.color = new Color (1.0f, 0.5f, 0.0f); // orange

		if (currHealth <= 25 && currHealth > 0) 
			healthbarColor.color = new Color (255, 0, 0, 100); // red

	}
}
