using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang.Environments;
using UnityEngine;
using Random = UnityEngine.Random;

public class floor : MonoBehaviour {
	
	public GameObject f;
	
	void Start () {
		Debug.Log("Starting floor...");
	}
	
	void Place (int direction) {
		var currentPos = transform.position;
		
		Debug.Log("floor place direction: " + direction);
		
		GameObject newFloor = Instantiate(f, GetNewPos(currentPos, direction), Quaternion.identity);
		newFloor.SendMessage("Place", GetNewDirection(direction));
	}
	
	private static Vector3 GetNewPos(Vector3 pos, int direction) {
		Debug.Log("GetNewPos...");
		switch(direction) {
			case 0: 
				return new Vector3(pos.x + 2, 0, pos.z);
			case 1: 
				return new Vector3(pos.x - 2, 0, pos.z);
			case 2:
				return new Vector3(pos.x, 0, pos.z + 2);
			case 3:
				return new Vector3(pos.x, 0, pos.z - 2);
			default:
				throw new Exception("Error in switch");
		}
	}
	
	private static int GetNewDirection(int direction) {
		Debug.Log("GetNewDirection direction: " + direction);
		int result = 0;
		int ran = Random.Range(1, 100);
		if (ran < 60) {
			result = direction;
		} else if (ran < 70) {
			result = direction + 1;
		} else if (ran < 80) {
			result = direction + 2;
		} else if (ran < 90) {
			result = direction + 3;
		}
		
		if (result > 3) {
			result -= 3;
		}

		return result;
	}
}
