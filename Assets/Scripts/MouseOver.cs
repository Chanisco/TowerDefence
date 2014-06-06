using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {
	public GameObject turret;
	bool ocupied = false;
	public Material Grass;	
	Color Rood = new Color(10,0,0,2);
	
	
   	void OnMouseOver() {
		renderer.material.color = Rood;
    }
	void OnMouseExit(){
		renderer.material = Grass;
	}
	void OnMouseDown() {
		Buy ();
	}
	void Buy(){
		if(!ocupied && Global.money > Global.towerprice){
			GameObject Turret = Instantiate(Resources.Load("Turret"),transform.position,transform.rotation) as GameObject;
			ocupied = true;
			Global.money -= Global.towerprice;
			Debug.Log(Global.money);
		}else if(Global.money > Global.towerprice){
			Global.message = "Sorry sir we can't do that";
		}else if(ocupied){
			Global.message = "That seat is already taken";
		}
	}
}
