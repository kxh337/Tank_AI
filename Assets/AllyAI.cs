using UnityEngine;
using System.Collections;

public class AllyAI : MonoBehaviour {

	private int Health = 20;
	private double range = 2.5;
	public GameObject target;
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

	}
	
	// Update is called once per frame
	void Update () {
		if (Health < 35) {
			lowHealth = true;
		}
		if (!sighted) {
			// wander	
			// Enemy is seen in the SightTrigger script
		}
		else if (sighted && !lowHealth) {
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards (Turret.transform.forward, target.transform.position - Turret.transform.position, .01f, .01f);	
			Turret.transform.rotation = Quaternion.LookRotation (new Vector3 (amttorotate.x, 0f, amttorotate.z), new Vector3 (0f, 1f, 0f));
			if (inRange){
				// attack
				if (Vector3.Distance(this.gameObject.transform.position, this.target.transform.position) > range){
					inRange = false;
				}
			}
			else  {
				// follow/set inRange if it becomes true
				if (Vector3.Distance(this.gameObject.transform.position, this.target.transform.position) < range){
					inRange = true;
				}
			}
		}
		else if (lowHealth && sighted) {
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards (transform.forward, - target.transform.position, .01f, .01f);	
			transform.rotation = Quaternion.LookRotation (new Vector3 (amttorotate.x, 0f, amttorotate.z), new Vector3 (0f, 1f, 0f));
			// flee, maybe shoot during?		
		}
	}
}
