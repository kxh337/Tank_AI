using UnityEngine;
using System.Collections;

public class TurretTurn : MonoBehaviour {
	public GameObject cameraholder;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion amttorotate;
		amttorotate = Quaternion.Lerp(transform.rotation,cameraholder.transform.rotation,Time.deltaTime);
		transform.rotation = amttorotate;
	}
}
