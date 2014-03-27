using UnityEngine;
using System.Collections;

public class faceCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//turns the explosion to face the camera
		gameObject.transform.LookAt(Camera.main.transform.position);
	}
}
