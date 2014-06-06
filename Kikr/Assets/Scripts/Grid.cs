using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public GameObject gridPiece;
	public Vector3 size;
	float gridPS = 10;
	Vector3 startPS = new Vector3(-90,0,-90);
	void Start (){
		CreateGrid();
	}

	void CreateGrid(){
		for(var x = 0; x < size.x;x++){
			for(var z = 0; z < size.z;z++){
				Instantiate(gridPiece,startPS + new Vector3(x * gridPS,-0.2f,z * gridPS),Quaternion.identity);	
			}
		}
	}
}
