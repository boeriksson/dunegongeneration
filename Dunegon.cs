using System;
using Boo.Lang;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dunegon : MonoBehaviour {

	public GameObject floor;
	[SerializeField]
	public int noOfSegments;
	private int _direction;
	private int _x = 0, _z = 0;
	private List<Segment> floors = new List<Segment>();
	
	// Use this for initialization
	void Start () {
		_direction = 0;
		BuildDunegon();
	}
	
	void BuildDunegon() {
		Debug.Log("Building dunegon...");
		
		for (int i = 0; i < noOfSegments; i++) {
			bool spaceOk = false;
			Segment tile = null;
			while(!spaceOk) {
				tile = DecideAction();
				spaceOk = checkSpace(tile);
			}
			floors.Add(tile);
			_x = tile.X;
			_z = tile.Z;
			_direction = tile.Direction;
			Corridor.InstaCorridor(tile, floor);
		}
	}
	
	bool checkSpace(Segment tile) {
		foreach (Segment f in floors) {
			var checkSpace = tile.CheckSpace;
			for (var i = 0; i < checkSpace.GetLength(0); i++) {
				var cx = checkSpace[i, 0];
				var cz = checkSpace[i, 1];
				if (f.X == cx && f.Z == cz) {
					return false;
				}
			}
		}

		return true;
	}

	Segment DecideAction() {
		return DecideAction(100);
	}
	
	/**
	 * Scope should be set smaller than failiure - and bigger stuff should be in higher scoopes
	 */
	Segment DecideAction(int scope) {
		int ran = Random.Range(1, scope);
		if (ran <= 70) {
			Segment segment = Corridor.AddCorridor(_direction, _x, _z, floor);
			return segment ?? DecideAction(100);
		}
		if (ran > 70 && ran <= 80) {
			Segment segment = Corridor.AddCorridor(_direction + 1, _x, _z, floor);
			return segment ?? DecideAction(100);
		}
		if (ran > 80 && ran <= 90) {
			Segment segment = Corridor.AddCorridor(_direction + 2, _x, _z, floor);
			return segment ?? DecideAction(100);
		} 
		if (ran > 90 && ran <=100) {
			Segment segment = Corridor.AddCorridor(_direction + 3, _x, _z, floor);
			return segment ?? DecideAction(100);
		}

		throw new Exception("Cant decide action... ran: " + ran);
	}
}
