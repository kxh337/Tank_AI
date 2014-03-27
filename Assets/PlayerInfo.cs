using UnityEngine;
using System.Collections;

public class PlayerInfo : AllyAI {

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
				cloneProj.rigidbody.AddForce(Turret.transform.right*shotSpeed);
				audio.Play ();
				isReloaded = false;
				canShootTime = Time.time + reloadTime;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if(Time.time > canShootTime){
			isReloaded = true;
		}
		shoot();
	}
}
