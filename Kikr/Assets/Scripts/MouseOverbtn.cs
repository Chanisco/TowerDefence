using UnityEngine;
using System.Collections;

public class MouseOverbtn : MonoBehaviour {

	private Color defaultColor;
	private Color mouseOverColor;
	public AudioClip Theme;
	public float FunctionNr;
	void Start(){
		GameObject light = GameObject.Find("ChooseLight");
		defaultColor = new Color(10,0,0,0.1f);	
		mouseOverColor = light.light.color;
		light.light.color = defaultColor;
	}

	void OnMouseOver(){
		Debug.Log("Dit werkt01");
		AudioSource.PlayClipAtPoint(Theme, transform.position,10);
		GameObject light = GameObject.Find("ChooseLight");
		light.light.color = mouseOverColor;
	}
	void OnMouseExit(){
		GameObject light = GameObject.Find("ChooseLight");
		light.light.color = defaultColor;	
	}
	void OnMouseDown(){
		if(FunctionNr == 1){
			Application.LoadLevel("Tower");	
		}else if(FunctionNr == 2){
			GameObject Cred = GameObject.Find("CredScherm");
			Cred.transform.Translate(0,-20,0);
		}
	}
}
