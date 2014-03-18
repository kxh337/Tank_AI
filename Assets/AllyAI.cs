using UnityEngine;
using System.Collections;

public class AllyAI : MonoBehaviour {

	private int Health = 100;
	private int range = 50;
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
		if (!sighted) {
			// wander	
			// Enemy is seen in the SightTrigger script
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
