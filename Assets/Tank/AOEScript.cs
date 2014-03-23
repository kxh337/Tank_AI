using UnityEngine;
using System.Collections;

public class AOEScript : MonoBehaviour {
	private ArrayList inArea;

	// Use this for initialization
	void Start () {
		inArea = new ArrayList();
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void Explode() {
		foreach (GameObject x in inArea) {
			//x.GetComponent<AllyAI>().takeDamage(100);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Ally") || other.gameObject.CompareTag ("Enemy")) {
			inArea.Add (other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Ally") || other.gameObject.CompareTag ("Enemy")) {
			inArea.Remove (other.gameObject);
		}
	}
}
