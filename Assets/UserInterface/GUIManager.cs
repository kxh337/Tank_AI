﻿using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	public GUIText enemyCountText, allyCountText, victoryText;
	private int enemyCount;
	private int allyCount;
	public AudioClip victorySound;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		//need to divide by 2 because both "Enemy Tank" object and its child object "Body" are tagged as "Enemy"
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length / 2; 
		allyCount = GameObject.FindGameObjectsWithTag ("Ally").Length / 2;
		enemyCountText.text = enemyCount.ToString ();
		allyCountText.text = allyCount.ToString ();
		
		if (enemyCount == 0) {

			victoryText.text = "Victory";
			audio.PlayOneShot(victorySound);
		}
		
	}
	
}
