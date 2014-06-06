using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	
	public int moveSpeed = 10;
	public float turnSpeed;
	
	public Transform[] waypoints;
	private int waypointIndex;
	// Use this for initialization
	void Start () {
		
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
	}
	
	// Update is called once per frame
	void Update () {
		if(waypoints.Length > 0){
			if(Vector3.Distance(transform.position,waypoints[waypointIndex].position) < 1){
				waypointIndex++;
				
				if(waypointIndex == waypoints.Length){
					waypointIndex = 0;
				}
				/*if(waypoints.Length < 0){
					Debug.Log("FUU");	
				}
				*/
			}
		}
			Vector3 targetDir = waypoints[waypointIndex].position - transform.position;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDir), turnSpeed * Time.deltaTime);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);	
	}
}
