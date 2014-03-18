using UnityEngine;

using System.Collections;



public class GuiHealth : MonoBehaviour {
	
	public Vector3 pos;
	
	public float xOffset;
	
	public float yOffset;
	
	public Texture aTexture;
	
	public SkeletonMotor scelMotor;
	
	public SkeletonHealth guiHscript;
	
	public float tisekato;
	
	
	
	
	
	
	
	
	
	// Use this for initialization
	
	void Start () {
		
		
		
	}
	
	
	
	// Update is called once per frame
	
	void Update () {
		
		guiHscript = GetComponent<SkeletonHealth>();
		
		scelMotor = GetComponent<SceletonMotor>();
		
		pos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x + xOffset, transform.position.y + yOffset,transform.position.z));
		
		pos.y = Screen.height - pos.y;
		
		tisekato = HealthValue(guiHscript.maxHealth,guiHscript.health);
		
		print(tisekato);
		
		
		
		
		
		
		
		
		
		
		
	}
	
	void OnGUI(){
		
		if(scelMotor.Distance < 10)
			
			GUI.DrawTexture(new Rect(pos.x,pos.y,69,50),aTexture, ScaleMode.ScaleToFit, true, 10.0F);
		
	}
	
	public float HealthValue(float max,float current){
		
		float sum = current * 100;
		
		float sum1 = sum / max;
		
		
		
		return(sum1 / 100);
		
	}
	
	
	
}