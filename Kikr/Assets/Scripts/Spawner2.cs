using UnityEngine;
using System.Collections;

public class Spawner2 : MonoBehaviour {
	float spawn = 10;
	float endTime = 10;
	float Tps = 2;
	
	
	void Update () {
		if(Time.time >= endTime || Global.Choice == 1){
			GameObject Enemy = Instantiate(Resources.Load("Enem"),transform.position,transform.rotation) as GameObject;
			Global.Round++;
			endTime += Tps;
			Global.Choice = 0;
		}
	}
}