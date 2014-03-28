using UnityEngine;
using System.Collections;


/*
 * handles collision behavior for the cannonball
 */
public class CannonBall : MonoBehaviour {
	public AOEScript AOE; // script to handle AOE damage
	public AudioClip ExplosionSound; // sound of explosion
	public GameObject explosionSprite; // explosion visual

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*
	 * handles impact-triggered explosion
	 * @param other the object being hit by the cannonball
	 */
	void OnCollisionEnter(Collision other) {
		Debug.Log("boom");
		AOE.Explode ();
		Destroy(this.gameObject);
		GameObject explClone = (GameObject)Instantiate(explosionSprite,gameObject.transform.position,Camera.main.transform.rotation);
		Destroy (explClone, 2.0f);
	}
}
