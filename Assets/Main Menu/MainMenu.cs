﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private RaycastHit hitInfo;
	public GameObject Turret;
	public GameObject Projectile;
	public Transform barrelTip;
	public float shotSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if( Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hitInfo ) ){
				if(Input.GetMouseButtonDown(0)){
				if(hitInfo.collider.name == "Play Game"){
					Application.LoadLevel(1);
				}
				if(hitInfo.collider.gameObject.tag =="Ally"){
					//shoot
					GameObject cloneProj= (GameObject)Instantiate(Projectile,barrelTip.transform.position,Turret.transform.rotation);
					Rigidbody projRigid = cloneProj.rigidbody;
					projRigid.AddForce(Turret.transform.forward*shotSpeed);
				}

			} 

		}
	}
			
}
