using UnityEngine;
using System.Collections;

public class PlayerInfo : AllyAI {
	public LineRenderer predictionLine;
	// Use this for initialization
	void Start () {
		audio.clip = shotSound;
	}
	
	public void takeDamage(int damage) {
		Health -= damage;
		healthBar.health(-damage);
		if (Health <= 0) {
			GameEventManager.tankDeath(this.gameObject.tag);
		}
	}
	
	public void shoot(){
		if(isPlayer && isReloaded == true){
			if(Input.GetMouseButtonDown(0)){
				GameObject cloneProj;
				Debug.Log("PLayer shot");
				cloneProj = (GameObject)Instantiate(Projectile,barrelTip.transform.position + instantOffset,Barrel.transform.rotation);
				cloneProj.rigidbody.AddForce(Turret.transform.right*shotSpeed, ForceMode.Impulse);
				audio.Play ();
				isReloaded = false;
				canShootTime = Time.time + reloadTime;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		UpdatePredictionLine ();
		if(Time.time > canShootTime){
			isReloaded = true;
		}
		shoot();
	}
	void UpdatePredictionLine() {
		predictionLine.SetVertexCount(180);
		for(int i = 0; i < 180; i++)
		{
			Vector3 posN = GetTrajectoryPoint(barrelTip.transform.position, Turret.transform.right*shotSpeed, (float)i, Physics.gravity);
			predictionLine.SetPosition(i,posN);
		}
	}
	
	Vector3 GetTrajectoryPoint(Vector3 startingPosition, Vector3 initialVelocity, float timestep, Vector3 gravity)
	{
		float physicsTimestep = Time.fixedDeltaTime;
		Vector3 stepVelocity = physicsTimestep * initialVelocity;
		
		//Gravity is already in meters per second, so we need meters per second per second
		Vector3 stepGravity = physicsTimestep * physicsTimestep * gravity;
		
		return startingPosition + (timestep * stepVelocity) + ((( timestep * timestep + timestep) * stepGravity ) / 2.0f);
	}
	
}
