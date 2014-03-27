using UnityEngine;
using System.Collections;

public class FloatingHealthBar : MonoBehaviour {
	public GameObject greenBar;
	public GameObject redBar;
	
	public float currentHealth;
	private float maxHealth;
	private float temp;

	// Sets the position of health bar with some Y-offset
	void Start () {
		this.transform.localPosition = new Vector3 (0, 0.5f, 0);
		currentHealth = 100 + (GameEventManager.difficulty - 1) * 100;
		maxHealth = 100 + (GameEventManager.difficulty - 1) * 100;
	}
	
	// turns the health bar to face the camera
	void Update () {
		gameObject.transform.LookAt(Camera.main.transform.position);
	}


	// @param adj the amount of health you want to adjust
	// will keep adjusting the health bar's position
	// for example, if you want the object to take 15 damage, you would have to use -15 instead of 15
	public void health(int adj) {
		currentHealth += adj;
		if (currentHealth <= 0) {
			currentHealth = 0;
			Debug.Log ("Health zero. Dead!");
			greenBar.transform.localPosition = new Vector3 (0.5f, 0, 0);
			greenBar.transform.localScale = new Vector3 (0, greenBar.transform.localScale.y, greenBar.transform.localScale.z);

		} else if (currentHealth >= maxHealth) {
			// just in case we get current health exceeding max health
			// readjusts the current health to max health (e.g. you can't have 120 out of 100 health)
			// can change if we want something like mega health from quake, but we don't need/want that for now...
			currentHealth = maxHealth;
			Debug.Log ("health is over 100. readjusting it back to 100...");
			greenBar.transform.localScale = new Vector3 (1,
			                                             greenBar.transform.localScale.y,
			                                             greenBar.transform.localScale.z);
			
			greenBar.transform.localPosition = new Vector3 (0,
			                                                greenBar.transform.localPosition.y,
			                                                greenBar.transform.localPosition.z);
		} else {
			greenBar.transform.Translate (-(adj / (maxHealth*2)), 0, 0);
			greenBar.transform.localScale = new Vector3 ((currentHealth) / maxHealth,
			                                             greenBar.transform.localScale.y,
			                                             greenBar.transform.localScale.z);
		}
	}
	
}
