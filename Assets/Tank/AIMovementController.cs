using UnityEngine;
using System.Collections;

public class AIMovementController : MonoBehaviour {
	public WheelCollider[] wheels;
	/*
	 * wheels
	 * 0 - left front
	 * 1 - left rear
	 * 2 - right front
	 * 3 - right rear
	 */
	public Transform[] wheelModels;
	private bool isMoving;
	public float maxTorqueSpeed;
	public float maxTurnSpeed;

	// Use this for initialization
	void Start () {
		isMoving = false;
		foreach(WheelCollider w in wheels){
			w.brakeTorque = 0; 	
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Transform wheel in wheelModels){
			wheel.Rotate(Vector3.down,rigidbody.velocity.x*Time.deltaTime*100);
		}
	}
}
