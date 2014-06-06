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
	
	
	float fireRate = 2F;
    float nextFire = 0.0F;
	Transform target;
	
	private Color defaultColor;
	private Color mouseOverColor;
	void Awake() { 
		defaultColor = new Color(0,0,0,0);
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
		}
	}
	void OnMouseDown() {
		if( Global.money > Global.towerprice * lvl){
			if(lvl < 3){
				lvl++;
				Global.message = "Leveled up to level" + lvl;
				Global.money -= Global.towerprice * lvl;
			}else{
				Global.message = "'We can't do that Master its already maxed'"	;
			}
		}else{
			Global.message = "'Sir you're out of cash'";
		}
	}
	/*void CalculateAimError(){
		aimError = Random.Range(0,100);
	}*/
}
