using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {
	public AOEScript AOE;
	public AudioClip ExplosionSound;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision other) {
		Debug.Log("boom");
		
		AOE.Explode ();
		Destroy(this.gameObject);
	}
}
