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
	public float torque;
	public float steer;

	// Use this for initialization
	void Start () {
		isMoving = false;
		foreach(WheelCollider w in wheels){
			w.brakeTorque = 0; 	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(rigidbody.velocity > 0){
			isMoving = true;
		}
		else{
			isMoving = falst;
		}
		if(isMoving == true){
			foreach(Transform wheel in wheelModels){
				wheel.Rotate(Vector3.down,rigidbody.velocity.x*Time.deltaTime*100);
			}
		}
	}

	public void moveForward(float time){
		float nextTime = Time.time + time;
		while(Time.time < nextTime){
			foreach(WheelCollider w in wheels){
				w.motorTorque = torque;
			}
		}
	}

	public void turnLeft(float time){
		float nextTime = Time.time + time;
		while(Time.time < nextTime){
			wheels[0].motorTorque += steer;
			wheels[1].motorTorque += steer;
			wheels[2].motorTorque += steer;
			wheels[3].motorTorque += steer;
		}
	}

	public void turnRight(float time){
		float nextTime = Time.time + time;
		while(Time.time < nextTime){
			wheels[0].motorTorque += steer;
			wheels[1].motorTorque += steer;
			wheels[2].motorTorque -= steer;
			wheels[3].motorTorque -= steer;
		}
	}


	public void moveBackwards(float time){
		float nextTime = Time.time + time;
		while(Time.time < nextTime){
			foreach(WheelCollider w in wheels){
				w.motorTorque = -torque;
			}
		}
	}
}
