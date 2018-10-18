using UnityEngine;

namespace DefaultNamespace {
    public class Corridor : MonoBehaviour {
        public static Segment AddCorridor(int dir, int x, int z, GameObject floor) {
            Debug.Log("CurrentPos: (" + x + ", " + z + ") direction: " + dir);
            Segment tile = GetNewCorridorTilePosition(dir, x, z);
            
            Debug.Log("New Pos: (" + tile.X + ", " + tile.Z + ") direction: " + tile.Direction);
            
            return tile;
        }
        
        public static void InstaCorridor(Segment tile, GameObject floor) {
            Instantiate(floor, new Vector3(tile.X, 0, tile.Z), Quaternion.identity);
        }
	
        static Segment GetNewCorridorTilePosition(int dir, int x, int z) {
            int[,] checkSpace;
            switch(dir) {
                case 0:
                    checkSpace = new [,] {{x + 20, z}, {x + 20, z - 20}, {x + 40, z - 20}, {x + 40, z}, {x + 40, z + 20}, {x + 20, z + 20}};
                    return new Segment(x + 20, z, dir, checkSpace);
                case 1:
                    checkSpace = new [,] {{x, z + 20}, {x + 20, z + 20}, {x + 20, z + 40}, {x, z + 40}, {x - 20, z + 40}, {x - 20, z + 20}};
                    return new Segment(x, z + 20, dir, checkSpace);
                case 2:
                    checkSpace = new [,] {{x, z - 20}, {x + 20, z - 20}, {x + 20, z - 40}, {x, z - 40}, {x - 20, z - 40}, {x - 20, z - 20}};
                    return new Segment(x, z - 20, dir, checkSpace);
                case 3:
                    checkSpace = new [,] {{x - 20, z}, {x - 20, z - 20}, {x - 40, z - 20}, {x - 40, z}, {x - 40, z + 20}, {x - 20, z + 20}};
                    return new Segment(x - 20, z, dir, checkSpace);
                default:
                    Debug.Log("dir större än 3 - dir: " + dir);
                    return GetNewCorridorTilePosition(dir - 3, x, z);
            }
        }
    }
}