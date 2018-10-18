using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entry : MonoBehaviour {

	public GameObject floor;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Hej");
		GameObject newFloor = Instantiate(floor, new Vector3(0, 0, 0), Quaternion.identity);
		newFloor.SendMessage("Place", 1);
	}
}
