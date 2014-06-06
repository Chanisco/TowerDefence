using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	bool LeftGoing 	= true;
	bool RightGoing = true;
	bool TopGoing 	= true;
	bool DownGoing	= true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(LeftGoing){
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
				transform.Translate(-1,0,0);
			}
		}
		if(RightGoing){
			if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
				transform.Translate(1,0,0);
			}
		}
		if(DownGoing){
			if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
				transform.Translate(0,0,-1);
			}
		}
		if(TopGoing){
			if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
				transform.Translate(0,0,1);
			}
		}
		//transform.Translate(0,1 * Input.GetAxis("Mouse ScrollWheel"),0);
		
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Top"){
			TopGoing = false;	
		}
		if(other.gameObject.tag == "Bot"){
			DownGoing = false;	
		}
		if(other.gameObject.tag == "Right"){
			RightGoing = false;	
		}
		if(other.gameObject.tag == "Left"){
			LeftGoing = false;	
		}
	}
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Top"){
			TopGoing = true;	
		}
		if(other.gameObject.tag == "Bot"){
			DownGoing = true;	
		}
		if(other.gameObject.tag == "Right"){
			RightGoing = true;	
		}
		if(other.gameObject.tag == "Left"){
			LeftGoing = true;	
		}
	}
}
