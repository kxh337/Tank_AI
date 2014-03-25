using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	public GUIText enemyCountText;
	private int enemyCount;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//need to divide by 2 because both "Enemy Tank" object and its child object "Body" are tagged as "Enemy"
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length / 2; 

		enemyCountText.text = enemyCount.ToString ();
	}

}
