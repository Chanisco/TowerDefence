using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	float myRange = 20;
	float mySpeed = 50;
	float myDist;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * mySpeed);
		myDist += Time.deltaTime * mySpeed;
			if(myDist >= myRange){
			Destroy(gameObject);		
		}
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Minion"){
			Destroy(gameObject);
		}
			
	}
}
