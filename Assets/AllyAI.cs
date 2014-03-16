using UnityEngine;
using System.Collections;

public class AllyAI : MonoBehaviour {

	private int Health = 100;
	public GameObject[] Wheels; // 0 and 1 should be front, 2 and 3 back.
	public GameObject Projectile;
	public GameObject Barrel;
	public GameObject Turret;

	public bool sighted;
	public bool lowHealth;
	public bool inRange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!sighted) {
			// wander		
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
