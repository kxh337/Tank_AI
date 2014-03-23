using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {
	public AOEScript AOE;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Ally") || other.gameObject.CompareTag ("Enemy")) {
			AOE.Explode ();
			Debug.Log("boom");
			Destroy(this.gameObject);
		}

	}
}
