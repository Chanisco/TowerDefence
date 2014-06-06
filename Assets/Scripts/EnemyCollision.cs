using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {
	
	private float Health;
	// Use this for initialization
	void Start () {
		Health = 4;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Bullet"){
			Health -= 2;
			if(Health < 1){
				Destroy(gameObject);
			}
		}
			
	}
}
