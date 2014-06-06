using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {
	
	void OnGUI(){
		GUI.Box (new Rect (0,0,100,50), "Lives = " + Global.Lives);
		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Money = " + Global.money);
		GUI.Box (new Rect (100,Screen.height - 50,700,250), "Captain says " + Global.message);
	}
}
