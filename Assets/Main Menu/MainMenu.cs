using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private RaycastHit hitInfo;
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
				if(hitInfo.collider.name =="Ally Tank"){
					//shoot
				}

			} 

		}
	}
			
}
