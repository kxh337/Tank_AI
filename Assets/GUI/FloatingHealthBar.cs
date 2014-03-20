using UnityEngine;
using System.Collections;

public class FloatingHealthBar : MonoBehaviour {
	public GameObject GreenBarPrefab;
	public GameObject RedBarPrefab;

	public Vector3 pos;
	private float currentXPosition;

	public int currHealth = 100;
	public int damage = -1;
	private int maxHealth = 100;



	// Use this for initialization
	void Start () {
		currentXPosition = GreenBarPrefab.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt(Camera.main.transform.position);
		health (0);
	}
	
	void health(int adj) {
		currHealth = 50;

		/*GreenBarPrefab.transform.position = new Vector3 (currentXPosition * 0.5f - 0.5f,
		                                                 GreenBarPrefab.transform.position.y,
		                                                 GreenBarPrefab.transform.position.z);*/

		currentXPosition = GreenBarPrefab.transform.position.x;

		GreenBarPrefab.transform.localScale = new Vector3(currHealth/(float)100,
		                                                  GreenBarPrefab.transform.localScale.y,
		                                                  GreenBarPrefab.transform.localScale.z);
		
	}

}
