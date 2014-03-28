using UnityEngine;
using System.Collections;

/*
 * AI class for all tanks
 */
public class AllyAI : MonoBehaviour {
	public GameObject parentTank; // the parent object of the tank
	public int Health = 100; // health, reduced by taking damage
	private double range = 9; // range that the tank should be able to hit things at
	public GameObject target; // target enemy tank
	public GameObject Projectile; // the projectile to be shot
	public GameObject Barrel; // the barrel of this tank
	public GameObject Turret; // the turret of this tank
	public FloatingHealthBar healthBar; // the healthbar of this tank
	public float reloadTime; // time it takes to reload the projectile
	public float shotSpeed; // speed at which the projectile travels
	public Vector3 instantOffset;
	public float nextWander = 0; // time between wander commands
	public AudioClip shotSound; // the sound made when you shoot
	public bool sighted = false; // if an enemy tank is sighted
	public bool lowHealth = false; // if the tank has low heatlh
	public bool inRange = false; // if the target is in range to fire at
	public bool aimed = false; // if the tank is pointing at the target
	public bool isReloaded = true; // if the tank is reloading
	public bool isPlayer; // if the tank is the player
	public Transform barrelTip; // the position of the tip of the barrel
	public GameObject explosion; // the explosion animation

	public float canShootTime; //  how often the tank can shoot
	private GameObject cloneProj;



	// Use this for initialization
	void Start () { // initialize health and audioclip
		Health = 100 + (GameEventManager.difficulty - 1) * 100;
		audio.clip = shotSound;
	}

	/*
	 * used to assign damage to a tank
	 * @param damage the amount of damage taken
	 */
	public void takeDamage(int damage) {
		Health -= damage;
		healthBar.health(-damage);
		if (Health <= 0) { // death protocol
			GameEventManager.tankDeath(this.gameObject.tag);
			GameObject explClone = (GameObject)Instantiate(explosion,gameObject.transform.position,Camera.main.transform.rotation);
			Destroy(parentTank);		
			Destroy(explClone, 1.5f);
		}
	}


	/*
	 * movement and AI
	 */
	void Update () {
		Debug.DrawRay(barrelTip.transform.position, barrelTip.transform.TransformDirection(Vector3.forward)*(float)range,Color.red);
		if(Time.time > canShootTime){ // allows the tank to fire after reloading
			isReloaded = true;
		}
		if (target == null) // handles when the tank's target dies while it is sighted
			sighted = false;
		if (Health < 35) { // low health threshold
			lowHealth = true;
		}
		if (!sighted && Time.time > nextWander) { // wander state, sight is determined in SightTrigger
			float choice = Random.Range(0f,1f);
			if (choice < 0.15f) {
				parentTank.GetComponent<AIMovementController>().turnLeft(1);
			}
			else if (choice > .85f) {
				parentTank.GetComponent<AIMovementController>().turnRight(1);
				Debug.Log ("ROLLOUT");
			}
			else 
				parentTank.GetComponent<AIMovementController>().moveForward(1);
			nextWander = Time.time + 1;
		}


		else if (sighted && !lowHealth) { //attack state
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards (Turret.transform.forward, target.transform.position - Turret.transform.position, .01f, .01f);	
			Turret.transform.rotation = Quaternion.LookRotation (amttorotate, new Vector3 (0f, 1f, 0f)); // rotates the turret towards the target
			if (inRange){
				// attack
				RaycastHit hit;


				if(Physics.Raycast(barrelTip.transform.position, barrelTip.transform.forward,out hit,(float)range)){ // fires is the target is hit by the raycast and the tank is done reloading

				if((hit.transform.gameObject.tag == "Enemy" &&parentTank.tag =="Ally")||((hit.transform.gameObject.tag == "Ally"||hit.transform.gameObject.tag =="Player") &&parentTank.tag =="Enemy")){
					if(isReloaded == true){
						Debug.Log("shot");
						cloneProj= (GameObject)Instantiate(Projectile,barrelTip.transform.position+instantOffset,Turret.transform.rotation);
						Rigidbody projRigid = cloneProj.rigidbody;
						projRigid.AddForce(Turret.transform.forward*shotSpeed);
							audio.Play();
						isReloaded = false;
						canShootTime = Time.time + reloadTime;
					}
				}
				}

				if (Vector3.Distance(this.gameObject.transform.position, this.target.transform.position) > range){
					inRange = false;
				}
			}
			else  {
				// follow/set inRange if it becomes true
				if (Vector3.Distance(this.gameObject.transform.position, this.target.transform.position) < range){
					inRange = true;
				}
				Vector3 bodytorotate;
				bodytorotate = Vector3.RotateTowards (parentTank.transform.forward, (target.transform.position - parentTank.transform.position), .01f, .01f);	
				parentTank.transform.rotation = Quaternion.LookRotation (new Vector3 (bodytorotate.x, 0f, bodytorotate.z), new Vector3 (0f, 1f, 0f)); // turns tank towards target
				if( parentTank.GetComponent<AIMovementController>().getCmdFinished() == true && Vector3.Distance(this.gameObject.transform.position, target.transform.position) > range){
					parentTank.GetComponent<AIMovementController>().moveForward(0.0001f);
				}
			}
		}

		//enemy sighted and not low health
		else if (lowHealth && sighted) { // flee
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards (parentTank.transform.forward, -(target.transform.position - parentTank.transform.position), .01f, .01f);	
			parentTank.transform.rotation = Quaternion.LookRotation (new Vector3 (amttorotate.x, 0f, amttorotate.z), new Vector3 (0f, 1f, 0f)); // rotates away from enemy
			parentTank.GetComponent<AIMovementController>().moveForward(0.001f); // move forward
			// flee, maybe shoot during?		

		}
	}
}
