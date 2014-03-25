using UnityEngine;
using System.Collections;

public class SightTrigger : MonoBehaviour {
	private int EnemyCount = 0;
	public AllyAI Tank;

	public AudioClip enemySeePlayer;
	
	// Use this for initialization
	void Start () {
		
	}

	void findNewTarget() {
		ArrayList enemies; 
		if (Tank.gameObject.tag == "Enemy") {
			enemies = new ArrayList (GameObject.FindGameObjectsWithTag ("Ally"));
			enemies.Add(GameObject.FindGameObjectWithTag("Player"));
		}
		else {
			enemies = new ArrayList(GameObject.FindGameObjectsWithTag("Enemy"));
		}
		if (enemies.Count != 0){
			foreach (GameObject x in enemies) {
				if (Vector3.Distance(Tank.gameObject.transform.position, x.gameObject.transform.position) < 20)
					Tank.target = x;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Tank.target == null && EnemyCount != 0) {
			findNewTarget();
		}
		else if (Tank.target == null) {
			Tank.sighted = false;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (Tank.gameObject.tag == "Enemy") {
			if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Ally")) {
				if (EnemyCount == 0 || other.gameObject.CompareTag("Player")) {
					Tank.target = other.gameObject;
					if (other.gameObject.CompareTag("Player")) audio.PlayOneShot(enemySeePlayer);
				}
				EnemyCount++;
				if (Tank.sighted == false)
					Tank.parentTank.GetComponent<AIMovementController>().stopTime = Time.time;
				Tank.sighted = true;
				Debug.Log("Enemies seen:" + EnemyCount);
			}
		}
		if (Tank.gameObject.tag == "Ally") {
			if (other.gameObject.CompareTag ("Enemy")) {
				if (EnemyCount == 0)
					Tank.target = other.gameObject;
				EnemyCount++;
				Tank.sighted = true;
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (Tank.gameObject.tag == "Enemy") {
			if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Ally")) {
				EnemyCount--;
				if (EnemyCount == 0){
					Tank.sighted = false;
					Debug.Log("Enemy sees Noone");
				}
				if (EnemyCount > 0){
					Debug.Log("Enemies seen:" + EnemyCount);
				}
				if (other.gameObject == Tank.target) {
					findNewTarget();
				}
			}
		}
		if (Tank.gameObject.tag == "Ally") {
			if (other.gameObject.CompareTag ("Enemy")) {
				EnemyCount--;
				if (EnemyCount == 0){
					Tank.sighted = false;
					Debug.Log("Enemy sees Noone");
				}
				if (EnemyCount > 0){
					Debug.Log("Enemies seen:" + EnemyCount);
				}
				if (other.gameObject == Tank.target) {
					findNewTarget();
				}
			}
		}
	}
}