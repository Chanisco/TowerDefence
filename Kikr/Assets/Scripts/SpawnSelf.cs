using UnityEngine;
using System.Collections;

public class SpawnSelf : MonoBehaviour {
	
	private Color defaultColor;
	private Color mouseOverColor;
	void Start(){
		GameObject light = GameObject.Find("LightMouse");
		defaultColor = light.light.color;
		mouseOverColor = new Color(10,10,0,0.1f);	
	}
	void OnMouseDown() {
		if(Global.money < Global.spawnprice)
		{
			Global.message = "Sorry sir we dont have enough cash for units" as string;
		}
		else{
		GameObject Minion = Instantiate(Resources.Load("Min"),transform.position,transform.rotation) as GameObject;
		Global.money -= Global.spawnprice;
		}
	}
	void OnMouseOver(){
		GameObject light = GameObject.Find("LightMouse");
		light.light.color = mouseOverColor;
	}
	void OnMouseExit(){
		GameObject light = GameObject.Find("LightMouse");
		light.light.color = defaultColor;	
	}
	
}
