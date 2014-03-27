using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public WheelCollider[] wheels;
	/*
	 * wheels
	 * 0 - left front
	 * 1 - left rear
	 * 2 - right front
	 * 3 - right rear
	 */
	public Transform[] wheelModels;
	public float maxSpeed;
	public static bool isMoving;
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
		if(gameObject.rigidbody.velocity.magnitude > 0){
			isMoving = true;
		}
		else{
			isMoving = false;
		}

		if(rigidbody.velocity.magnitude > maxSpeed){
			rigidbody.velocity *= maxSpeed / rigidbody.velocity.magnitude;
		}

		float power = Input.GetAxis("Vertical") * maxTorqueSpeed * Time.deltaTime * 250;
		float steer = Input.GetAxis("Horizontal") * maxTurnSpeed;
		//used to move the tank based on the input
		foreach(WheelCollider w in wheels){
			w.motorTorque = power;
		}
		//used to turn the tank like a car turns
		wheels[0].steerAngle = steer;
		//wheels[1].steerAngle += steer;
		wheels[2].steerAngle = steer;
		//wheels[3].steerAngle += steer;

		//rotates the models to make it seem like the tank is moving
		foreach(Transform wheel in wheelModels){
			wheel.Rotate(Vector3.down,rigidbody.velocity.x*Time.deltaTime*100);
		}

	}


}
