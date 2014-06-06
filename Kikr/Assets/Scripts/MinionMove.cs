	using UnityEngine;
using System.Collections;

public class MinionMove : MonoBehaviour {
	
	public int moveSpeed = 10;
	public float turnSpeed;
	public GameObject target;
	float timtim = 5;
	float tps = 10;
	
	public Transform[] waypoints;
	private int waypointIndex;
	bool inCombat = false;
	// Use this for initialization
	void Start () {
		if(Global.lvl == 1){
			waypointIndex = 0;
			Transform Dir0 = 	GameObject.Find("Direction1").transform;
			Transform Dir1 =	GameObject.Find("Direction2").transform;
			Transform Dir2 =	GameObject.Find("Direction3").transform;
			Transform Dir3 =	GameObject.Find("Direction4").transform;
			Transform Dir4 =	GameObject.Find("Direction5").transform;
			waypoints = new Transform[5];
			waypoints[0] = Dir0;
			waypoints[1] = Dir1;
			waypoints[2] = Dir2;
			waypoints[3] = Dir3;
			waypoints[4] = Dir4;
		}else if(Global.lvl == 2){
			waypointIndex = 0;
			Transform Dir10 = 	GameObject.Find("Direction10").transform;
			Transform Dir9 =	GameObject.Find("Direction9").transform;
			Transform Dir8 =	GameObject.Find("Direction8").transform;
			Transform Dir7 =	GameObject.Find("Direction7").transform;
			Transform Dir6 =	GameObject.Find("Direction6").transform;
			Transform Dir5 = 	GameObject.Find("Direction5").transform;
			Transform Dir4 =	GameObject.Find("Direction4").transform;
			Transform Dir3 =	GameObject.Find("Direction3").transform;
			Transform Dir2 =	GameObject.Find("Direction2").transform;
			Transform Dir1 =	GameObject.Find("Direction1").transform;
			Transform Dir0 =	GameObject.Find("Direction0").transform;
			waypoints = new Transform[11];
			waypoints[0] = 	Dir0;
			waypoints[1] = 	Dir1;
			waypoints[2] = 	Dir2;
			waypoints[3] = 	Dir3;
			waypoints[4] = 	Dir4;
			waypoints[5] = 	Dir5;
			waypoints[6] = 	Dir6;
			waypoints[7] = 	Dir7;
			waypoints[8] = 	Dir8;
			waypoints[9] = 	Dir9;
			waypoints[10] = Dir10;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!inCombat){
			if(waypoints.Length > 0){
				if(Vector3.Distance(transform.position,waypoints[waypointIndex].position) < 1){
					waypointIndex++;
					if(waypointIndex == waypoints.Length){
						Destroy(gameObject);
						Global.EnemyLives -= 1;
					}
				}
			}
			Vector3 targetDir = waypoints[waypointIndex].position - transform.position;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDir), turnSpeed * Time.deltaTime);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);	
			}
			else{
				fight ();
			}
		if(target == null){
			inCombat = false;	
		}
	
	}
	void OnTriggerEnter (Collider other){
		if(other.gameObject.tag == "Enemy"){
			inCombat = true;
			target = other.gameObject;
		}
	}
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Enemy"){
			inCombat = false;	
			target = null;
		}
	}
	void fight(){
		if(target){
			if(Time.time > timtim){
				target.GetComponent<EnemyCollision>().TakeDamage(1);
				if(GetComponent<EnemyCollision>().Health < 1){
				//	Debug.Log ("askbhsjv");
					Destroy(gameObject);
						timtim += tps;
				}
			}
		}
			
	}
}
