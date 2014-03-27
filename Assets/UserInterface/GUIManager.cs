using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {
	public GUIText enemyCountText, allyCountText;
	private int enemyCount;
	private int allyCount;
	
	// Use this for initialization
	void Start () {

	}
	
	// displays remaining number of allies and enemies on the top-left edge of the screen
	// enemy count text is red, ally count is blue (these are set up using prefab settings, not through script)
	void Update () {
		// need to divide by 2 because both "Enemy Tank" parent object and child object "Body" are tagged as "Enemy"
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length / 2; 
		allyCount = GameObject.FindGameObjectsWithTag ("Ally").Length / 2;

		enemyCountText.text = enemyCount.ToString ();
		allyCountText.text = allyCount.ToString ();

	}
	
}
