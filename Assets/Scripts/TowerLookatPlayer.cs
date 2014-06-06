using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerLookatPlayer : MonoBehaviour {
	
	List<GameObject> enemyInRange;
	GameObject bullet;
	float turnSpeed = 5f;
	Transform myTarget;
	Vector3 Aimshot;
	float lvl = 1;
	
	
	float fireRate = 0.5F;
    float nextFire = 0.0F;
	Transform target;
	void Start () {
		enemyInRange = new List<GameObject>();
	}

	void Update () {
	if(myTarget){
			CalculatePosition(myTarget.position);
			Shooting();
		}
			
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Enemy"){
			myTarget = other.gameObject.transform;
			enemyInRange.Add(other.gameObject);
		}	
	}
	void OnTriggerExit(Collider other){
		if (enemyInRange.Contains(other.gameObject)) {
			enemyInRange.Remove(other.gameObject);
			if (other.transform == myTarget) {
				if (enemyInRange.Count >= 1) {
					myTarget = enemyInRange[0].transform;
				} 
				else {
					myTarget = null;
				}
			}
		}
	}
	void CalculatePosition(Vector3 targetPos) {
		Vector3 targetDir = targetPos - transform.position;
		Vector3 desiredRotation = Vector3.RotateTowards(transform.forward, targetDir, Time.deltaTime * turnSpeed, 0f);
		transform.rotation = Quaternion.LookRotation(desiredRotation);
	}
	void Shooting(){
		if(Time.time > nextFire){
			nextFire = Time.time + fireRate / lvl;
			GameObject Bullet = Instantiate(Resources.Load("Bullet"),transform.position,transform.rotation) as GameObject;
			/*Bullet.transform.Translate(transform.forward * 100);
			Bullet.rigidbody.AddForce(transform.forward * 500);*/
		}
	}	
	void OnMouseDown() {
		if(lvl < 3 && Global.money > Global.towerprice * lvl){
			lvl++;
			Global.message = "Leveled up to level" + lvl;
			Global.money -= Global.towerprice * lvl;
		}else{
			Global.message = "'Sir you're out of cash'";
		}
	}
	/*void CalculateAimError(){
		aimError = Random.Range(0,100);
	}*/
}
