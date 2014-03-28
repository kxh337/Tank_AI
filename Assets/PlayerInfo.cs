using UnityEngine;
using System.Collections;

/*
 * Info class for player tank, an extension of AllyAI to handle AOE damage from the cannonball
 */
public class PlayerInfo : AllyAI {
	public LineRenderer predictionLine;
	// Use this for initialization
	void Start () {
		audio.clip = shotSound;
	}

	/*
	 * used to assign damage to a tank
	 * @param damage the amount of damage taken
	 */
	public void takeDamage(int damage) {
		Health -= damage;
		healthBar.health(-damage);
		if (Health <= 0) {
			GameEventManager.playerDeath();
		}
	}

	/*
	 * shoots if the player can
	 */
	public void shoot(){
		if(isPlayer && isReloaded == true){
			if(Input.GetMouseButtonDown(0)){
				GameObject cloneProj;
				Debug.Log("PLayer shot");
				cloneProj = (GameObject)Instantiate(Projectile,barrelTip.transform.position + instantOffset,Barrel.transform.rotation);
				//gives the cannon a short burst of force that should give it the speed, shotSpeed, in the direction of the barrel
				cloneProj.rigidbody.AddForce(Turret.transform.right*shotSpeed, ForceMode.Impulse);
				audio.Play ();
				isReloaded = false;
				canShootTime = Time.time + reloadTime;
			}
		}
	}
	// Update is called once per frame
	void Update () { // handles the reloading and aiming line
		UpdatePredictionLine ();
		if(Time.time > canShootTime){
			isReloaded = true;
		}
		shoot();
	}

	/*
	 * keeps the aiming line inline with the turret angle/position
	 */
	void UpdatePredictionLine() {
		//sets up the number of secttions the line renderer is split up into
		predictionLine.SetVertexCount(180);
		//runs through each position and finds where it should be located
		for(int i = 0; i < 180; i++)
		{
			Vector3 posN = GetTrajectoryPoint(barrelTip.transform.position, Turret.transform.right*shotSpeed, (float)i, Physics.gravity);
			predictionLine.SetPosition(i,posN);
		}
	}
	//formulat that runs through the physics of projectile motion step by step to find where the next section of the line should be located
	Vector3 GetTrajectoryPoint(Vector3 startingPosition, Vector3 initialVelocity, float timestep, Vector3 gravity)
	{
		float physicsTimestep = Time.fixedDeltaTime;
		Vector3 stepVelocity = physicsTimestep * initialVelocity;

		Vector3 stepGravity = physicsTimestep * physicsTimestep * gravity;
		
		return startingPosition + (timestep * stepVelocity) + ((( timestep * timestep + timestep) * stepGravity ) / 2.0f);
	}
	
}
