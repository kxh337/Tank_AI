using UnityEngine;
using System.Collections;

public class AllyAI : MonoBehaviour {
	public GameObject parentTank;
	private int Health = 100;
	private double range = 2.5;
	public GameObject target;
	private GameObject[] Enemies;
	public GameObject[] Wheels; // 0 and 1 should be front, 2 and 3 back.
	public GameObject Projectile;
	public GameObject Barrel;
	public GameObject Turret;
	public FloatingHealthBar healthBar;
	public float reloadTime;
	public float shotSpeed;
	public Vector3 instantOffset;

	public bool sighted = false;
	public bool lowHealth = false;
	public bool inRange = false;
	public bool aimed = false;
	public bool isReloaded = true;

	private float canShootTime;
	private GameObject cloneProj;


	// Use this for initialization
	void Start () {

	}

	public void takeDamage(int damage) {
		Health -= damage;
		healthBar.health(-damage);
		if (Health <= 0) {
			Destroy(parentTank);		
		}
	}


	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		Debug.DrawRay(Turret.transform.position, Turret.transform.TransformDirection(Vector3.forward)*10,Color.red);
		if(Time.time > canShootTime){
			isReloaded = true;
		}
		if (target == null)
			sighted = false;
=======
>>>>>>> FETCH_HEAD
		if (Health < 35) {
			lowHealth = true;
		}
		if (!sighted) {
			// wander	
			// Enemy is seen in the SightTrigger script
		}

		//enemy sighted and not low health
		else if (sighted && !lowHealth) {
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards (Turret.transform.forward, target.transform.position - Turret.transform.position, .01f, .01f);	
			Turret.transform.rotation = Quaternion.LookRotation (amttorotate, new Vector3 (0f, 1f, 0f));
			if (inRange){
				// attack
				RaycastHit hit;
				Ray aim = new Ray(Barrel.transform.position, Turret.transform.TransformDirection(Vector3.forward));


				Physics.Raycast(aim,out hit,10);
				Debug.Log(hit.transform.gameObject.tag);
				if((hit.transform.gameObject.tag == "Enemy")){
					if(isReloaded == true){
						Debug.Log("shot");
						cloneProj= (GameObject)Instantiate(Projectile,Turret.transform.position+instantOffset,Turret.transform.rotation);
						Rigidbody projRigid = cloneProj.rigidbody;
						projRigid.AddForce(Turret.transform.forward*shotSpeed);
						isReloaded = false;
						canShootTime = Time.time + reloadTime;
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
			}
		}

		//enemy sighted and not low health
		else if (lowHealth && sighted) {
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards (transform.forward, - target.transform.position, .01f, .01f);	
			parentTank.transform.rotation = Quaternion.LookRotation (new Vector3 (amttorotate.x, 0f, amttorotate.z), new Vector3 (0f, 1f, 0f));
			// flee, maybe shoot during?		
		}
	}
}
