using UnityEngine;
using System.Collections;

public class FloatingHealthBar : MonoBehaviour {
	public GameObject greenBar;
	public GameObject redBar;

	private float currentXPosition;

	public float currHealth;
	private float maxHealth;
	private float temp;



	// Use this for initialization
	void Start () {
		currentXPosition = greenBar.transform.position.x;
		currHealth = 100f;
		maxHealth = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt(Camera.main.transform.position);
		//test - gives 10 damage with every left click
		/*if(Input.GetMouseButtonDown(0)){
			health (-10);
			Debug.Log("Gave 10 Damage");
		}*/
	}
	
	void health(int adj) {
		temp = currHealth;
		currHealth += adj;
		greenBar.transform.Translate((adj/200f),0,0);
		greenBar.transform.localScale = new Vector3((currHealth)/100f,
		                                                  greenBar.transform.localScale.y,
		                                                  greenBar.transform.localScale.z);
		
	}

}
