﻿using UnityEngine;
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
		float power = Input.GetAxis("Vertical") * maxTorqueSpeed * Time.deltaTime * 250;
		float steer = Input.GetAxis("Horizontal") * maxTurnSpeed;
		foreach(WheelCollider w in wheels){
			w.motorTorque = power;
		}
		if(steer > 0){
			wheels[0].motorTorque += steer;
			wheels[1].motorTorque += steer;
			wheels[2].motorTorque -= steer;
			wheels[3].motorTorque -= steer;
		}
		else{
			wheels[0].motorTorque -= steer;
			wheels[1].motorTorque -= steer;
			wheels[2].motorTorque += steer;
			wheels[3].motorTorque += steer;
		}

	}


}
