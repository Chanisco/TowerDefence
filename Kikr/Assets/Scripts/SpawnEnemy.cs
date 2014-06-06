using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {
	
	void OnMouseDown() {
		if(Global.money < Global.spawnprice)
		{
			Global.message = "Sorry sir we dont have enough cash for units";
		}
		else{
			GameObject Enemy = Instantiate(Resources.Load("Enemy"),transform.position,transform.rotation) as GameObject;
			Global.money -= Global.spawnprice;
		}
	}
	
}
