using UnityEngine;
using System.Collections;

public class LvlGate : MonoBehaviour {
	
	float lvl = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Global.EnemyLives < 1 && Global.lvl == 1){
			lvl += 1;
			Application.LoadLevel(2);
			Global.lvl = 2;
			Global.EnemyLives = 20;
		}else if(Global.EnemyLives < 1 && Global.lvl == 2){
			Application.LoadLevel("Win");
			Global.EnemyLives = 20;
			Global.Lives = 20;
			
		}
		if(Global.Lives < 1){
			Application.LoadLevel("Loss");
			Global.Lives = 20;
		}
		if(Input.GetKey(KeyCode.F)){
			Application.LoadLevel("Win");	
		}
	}
	void onGui(){
		if (GUI.Button (new Rect (0,0,500,500), "Continue to lvl 2")) {
			Global.Ready = true;
		}
	}
}
