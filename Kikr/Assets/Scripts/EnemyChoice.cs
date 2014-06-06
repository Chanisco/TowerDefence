using UnityEngine;
using System.Collections;

public class EnemyChoice : MonoBehaviour {
	float endTime = 1;
	float Tps = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= endTime){
			Global.Choice = Random.Range(0,2);
			endTime += Tps;
		}
	}
}