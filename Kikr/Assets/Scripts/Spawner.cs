using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	float spawn = 10;
	float endTime = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// UpdandTte is called once per frame
	void Update () {
		if(Time.time >= endTime){
			GameObject Minion = Instantiate(Resources.Load("Min"),transform.position,transform.rotation) as GameObject;
			endTime += 2;
		}
	}
}
