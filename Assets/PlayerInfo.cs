using UnityEngine;
using System.Collections;

public class PlayerInfo : AllyAI {

	// Use this for initialization
	void Start () {
		
	}
	public void shoot(){
		if(isPlayer && isReloaded == true){
			if(Input.GetMouseButtonDown(0)){
				GameObject cloneProj;
				Debug.Log("PLayer shot");
				cloneProj = (GameObject)Instantiate(Projectile,barrelTip.transform.position + instantOffset,Barrel.transform.rotation);
				cloneProj.rigidbody.AddForce(Turret.transform.right*shotSpeed);
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
