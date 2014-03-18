using UnityEngine;
using System.Collections;

public class AllyAI : MonoBehaviour {

	private int Health = 100;
	private int range = 50;
	private GameObject target;
	private GameObject[] Enemies;
	public GameObject[] Wheels; // 0 and 1 should be front, 2 and 3 back.
	public GameObject Projectile;
	public GameObject Barrel;
	public GameObject Turret;

	public bool sighted = false;
	public bool lowHealth = false;
	public bool inRange = false;

	// Use this for initialization
	void Start () {
		if (gameObject.tag == "Ally")
			Enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		else
			Enemies = GameObject.FindGameObjectsWithTag ("Ally");

	}
	
	// Update is called once per frame
	void Update () {
		if (!sighted) {
			// wander	
			foreach(GameObject x in Enemies) {
				if (target == null)
					target = x;
				else {
					if(Vector3.Distance(this.gameObject.transform.position, x.transform.position) < Vector3.Distance(this.gameObject.transform.position, target.transform.position))
						target = x;
				}
			}
			if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) <= this.range)
				sighted = true;
		}
		if (sighted && !lowHealth) {
			if (inRange){
				// attack
			}
			else  {
				// follow/set inRange if it becomes true
			}
		}
		if (lowHealth && sighted) {
			// flee		
		}
	}
}
