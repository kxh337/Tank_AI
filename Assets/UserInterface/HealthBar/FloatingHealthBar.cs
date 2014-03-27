using UnityEngine;
using System.Collections;

public class FloatingHealthBar : MonoBehaviour {
	public GameObject greenBar;
	public GameObject redBar;
	
	public float currentHealth;
	private float maxHealth;
	private float temp;

	private AudioClip lowHealthWarning;
	
	// Use this for initialization
	void Start () {
		this.transform.localPosition = new Vector3 (0, 0.5f, 0);
		currentHealth = 100 + (GameEventManager.difficulty - 1) * 100;
		maxHealth = 100 + (GameEventManager.difficulty - 1) * 100;
	}
	
	// Update is called once per frame
	void Update () {
		//turns the health bar to face the camera
		gameObject.transform.LookAt(Camera.main.transform.position);
		//test - gives 15 damage with every left click
		//		 heals 10 damage with every right click
		/*
		if (Input.GetMouseButtonDown (0)) {
			health (-15);
			Debug.Log ("Gave 15 Damage");
		}
		if (Input.GetMouseButtonDown (1)) {
			health (10);
			Debug.Log("Healed 10 damage");
		}
		*/
	}

	// use negative number for damage amount! This adjusts the health bar based on the damage so the green part reperesents the remeaining health
	public void health(int adj) {
		currentHealth += adj;
		if (currentHealth <= 0) {
			currentHealth = 0;
			Debug.Log ("Health zero. Dead!");
			greenBar.transform.localPosition = new Vector3 (0.5f, 0, 0);
			greenBar.transform.localScale = new Vector3 (0, greenBar.transform.localScale.y, greenBar.transform.localScale.z);
			
			
			// trigger death here. explosion animation and destroy parent object (parent = the tank)
			
			
			
			
			
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
			greenBar.transform.Translate (-(adj / 200f), 0, 0);
			greenBar.transform.localScale = new Vector3 ((currentHealth) / maxHealth,
			                                             greenBar.transform.localScale.y,
			                                             greenBar.transform.localScale.z);
		}



		if (currentHealth < 35 && this.CompareTag ("Player"))
						audio.PlayOneShot (lowHealthWarning);
	}
	
}
