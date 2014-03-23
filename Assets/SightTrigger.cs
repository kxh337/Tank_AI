using UnityEngine;
using System.Collections;

public class SightTrigger : MonoBehaviour {
	private int EnemyCount = 0;
	public AllyAI Tank;

	public AudioClip enemySeePlayer;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter(Collider other) {
		if (Tank.gameObject.tag == "Enemy") {
			if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Ally")) {
				if (EnemyCount == 0 || other.gameObject.CompareTag("Player")) {
					Tank.target = other.gameObject;


					if (other.gameObject.CompareTag("Player")) audio.PlayOneShot(enemySeePlayer);
				}
				EnemyCount++;
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
					ArrayList enemies = new ArrayList(GameObject.FindGameObjectsWithTag("Ally"));
					if (enemies.Count != 0){
						foreach (GameObject x in enemies) {
							if (Vector3.Distance(Tank.gameObject.transform.position, x.gameObject.transform.position) < 5)
								Tank.target = x;
						}
					}
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
					ArrayList enemies = new ArrayList(GameObject.FindGameObjectsWithTag("Enemy"));
					if (enemies.Count != 0){
						foreach (GameObject x in enemies) {
							if (Vector3.Distance(Tank.gameObject.transform.position, x.gameObject.transform.position) < 5)
								Tank.target = x;
						}
					}
				}
			}
		}
	}
}