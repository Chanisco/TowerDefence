using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {
	
	public float Health;
	float lvl = 5;
	// Use this for initialization
	void Start () {
		Health = 5;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Bullet"){
			TakeDamage(1);
		}
		if(other.gameObject.tag == "Top" || other.gameObject.tag == "Bot" || other.gameObject.tag == "Left" || other.gameObject.tag == "Right"){
			Destroy(gameObject);
		}		
	}
	
	void OnMouseDown(){
		if(Global.money > Global.towerprice * lvl){
			Health += lvl;
			Global.money -= (Global.MinionTrain * lvl);
			Global.message = "Captain! Your Minion has been upgraded";
			Debug.Log(Health);
		}	
	}	
	public void TakeDamage(float dmg)
	{
		Health -= dmg;
		if(Health < 1){
			Destroy(gameObject);
			Global.money += 40;
		}
	}
}
