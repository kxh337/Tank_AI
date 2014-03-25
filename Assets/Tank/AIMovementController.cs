﻿using UnityEngine;
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
	public float torque;
	public float steer;
	public float turnTorque;
	public float maxSpeed;
	public float stopTime;
	public bool cmdFinished = true;


	public bool getCmdFinished(){
		return cmdFinished;
	}

	// Use this for initialization
	void Start () {
		isMoving = false;
		foreach(WheelCollider w in wheels){
			w.brakeTorque = 0; 	
		}


	}

	
	// Update is called once per frame
	void Update () {
		if(rigidbody.velocity.magnitude > 0){
			isMoving = true;
		}
		else{
			isMoving = false;
		}
		if(rigidbody.velocity.magnitude > maxSpeed){
			rigidbody.velocity *= maxSpeed / rigidbody.velocity.magnitude;
		}
		if(isMoving == true){
			foreach(Transform wheel in wheelModels){
				wheel.Rotate(Vector3.down,rigidbody.velocity.x*Time.deltaTime*100);
			}
		}
		if(Time.time > stopTime){
			cmdFinished = true;
			wheels[0].steerAngle = 0;
			wheels[2].steerAngle = 0;
			foreach(WheelCollider w in wheels){
				w.motorTorque = 0;
			}
		}

	}

	public void moveForward(float time){
		stopTime = Time.time + time;
		cmdFinished = false;
			foreach(WheelCollider w in wheels){
				w.motorTorque = torque;
			}
	}

	public void turnLeft(float time){
		stopTime = Time.time + time;
		cmdFinished = false;
		wheels[0].steerAngle = -steer;
		//wheels[1].motorTorque -= steer;
		wheels[2].steerAngle = -steer;
		//wheels[3].motorTorque += steer;
		foreach(WheelCollider w in wheels){
			w.motorTorque = turnTorque;
		}
	}
	public void turnRight(float time){
		stopTime = Time.time + time;
		cmdFinished = false;
		wheels[0].steerAngle = steer;
		//wheels[1].motorTorque += steer;
		wheels[2].steerAngle = steer;
		//wheels[3].motorTorque -= steer;	
		foreach(WheelCollider w in wheels){
				w.motorTorque = turnTorque;
		}
	}


	public void moveBackwards(float time){
		stopTime = Time.time + time;
		cmdFinished = false;
		foreach(WheelCollider w in wheels){
			w.motorTorque = -torque;
		foreach(Transform wheel in wheelModels){
			wheel.Rotate(Vector3.down,rigidbody.velocity.x*Time.deltaTime*100);
		}
	}
}
}