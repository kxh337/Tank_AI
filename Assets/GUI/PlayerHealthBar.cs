using UnityEngine;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour {
	public int maxHealth = 100;
	public int currentHealth = 100;

	private float healthBarLength;


	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width - 20;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustHealth (0);
	}

	void OnGUI () {
		GUI.Box (new Rect (10, Screen.height - 30, healthBarLength, 20), currentHealth+"%");
	}

	// @param adj the amount of health you want to adjust from current health
	public void AdjustHealth(int adj) {
		currentHealth += adj;

		if (currentHealth < 0) 
						currentHealth = 0;
		if (currentHealth > maxHealth)
						currentHealth = maxHealth;
		if (maxHealth < 1)
						maxHealth = 1;
		healthBarLength = (Screen.width - 20) * (currentHealth / (float)maxHealth);


	}

}
