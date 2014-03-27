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
	public float turnTorque;
	public float maxSpeed;
	public float stopTime;
	public bool cmdFinished = true;

	// returns if the current movement command is finished
	public bool getCmdFinished(){
		return cmdFinished;
	}

	// Use this for initialization
	void Start () {
		isMoving = false;
		//stops the wheels
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
		//limits the speed of the tank
		if(rigidbody.velocity.magnitude > maxSpeed){
			rigidbody.velocity *= maxSpeed / rigidbody.velocity.magnitude;
		}
		//rotates the wheel models to make the tank look like it is moving
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
	/*moves the tank forward for float time
	 * param time- time for the tank to move forward
	 */
	public void moveForward(float time){
		stopTime = Time.time + time;
		cmdFinished = false;
			foreach(WheelCollider w in wheels){
				w.motorTorque = torque;
			}
	}
	/*turns the tank to the left for float time
	 * param time- time for the tank to turn left
	 */
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
	/*turns the tank to the right for float time
	 * param time- time for the tank to turn right
	 */
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

	/*moves the tank backwards for float time
	 * param time- time for the tank to move backwards
	 */
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