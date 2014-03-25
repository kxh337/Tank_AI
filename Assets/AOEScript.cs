using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AOEScript : MonoBehaviour {
	private List<AllyAI> inArea;
	
	// Use this for initialization
	void Start () {
		inArea = new List<AllyAI>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Explode() {
		foreach (AllyAI x in inArea) {
			x.takeDamage (15);
		}
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Ally") || other.gameObject.CompareTag ("Enemy")) {
			inArea.Add (other.gameObject.GetComponent<AllyAI> ());
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Ally") || other.gameObject.CompareTag ("Enemy")) {
			inArea.Remove (other.gameObject.GetComponent<AllyAI> ());
		}
	}
}
