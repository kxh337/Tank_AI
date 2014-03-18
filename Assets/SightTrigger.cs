using UnityEngine;
using System.Collections;

public class SightTrigger : MonoBehaviour {
	private int EnemyCount = 0;
	public AllyAI Tank;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if (this.gameObject.tag == "Enemy") {
			if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Ally")) {
				if (EnemyCount == 0)
					Tank.target = other.gameObject;
				EnemyCount++;
				Tank.sighted = true;
				Debug.Log("Enemy Sees You");
			}
		}
		if (this.gameObject.tag == "Ally") {
			if (other.gameObject.CompareTag ("Enemy")) {
				if (EnemyCount == 0)
					Tank.target = other.gameObject;
				EnemyCount++;
				Tank.sighted = true;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (this.gameObject.tag == "Enemy") {
			if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Ally")) {
				EnemyCount--;
				if (EnemyCount == 0){
					Tank.sighted = false;
					Debug.Log("Enemy sees someone");
				}
				if (EnemyCount > 0)
					Debug.Log("Enemy Can still see ally");
			}
		}
		if (this.gameObject.tag == "Ally") {
			if (other.gameObject.CompareTag ("Enemy")) {
				EnemyCount--;
				if (EnemyCount == 0)
					Tank.sighted = false;
			}
		}
	}
}