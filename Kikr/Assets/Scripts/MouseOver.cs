using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {
	private GameObject turret;
	bool ocupied = false;		
	
	private Color defaultColor;
	private Color mouseOverColor;
	
	void Start() {
		defaultColor = renderer.material.color;	
		mouseOverColor = new Color(10,0,0,0.1f);
	}
	
   	void OnMouseOver() {
		renderer.material.color = mouseOverColor;
    }
	void OnMouseExit(){
		renderer.material.color = defaultColor;
	}
	void OnMouseDown() {
		Buy ();
	}
	
	void Buy(){
		if(!ocupied && Global.money > Global.towerprice){
			GameObject Turret = Instantiate(Resources.Load("Turret"),transform.position,transform.rotation) as GameObject;
			ocupied = true;
			Global.money -= Global.towerprice;
		}else if(Global.money > Global.towerprice){
			Global.message = "Sorry sir we can't do that";
		}else if(ocupied){
			Global.message = "That seat is already taken";
		}
	}
}
