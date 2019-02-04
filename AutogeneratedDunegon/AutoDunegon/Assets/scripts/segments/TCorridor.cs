using System;
using Boo.Lang;
using Rect = Util.Rect;

namespace DefaultNamespace {
    public class TCorridor : Segment {
    
        public TCorridor(int x, int z, int direction) : base(x, z, direction, GetCheckSpaceByDir(direction, x, z)) {
            _space = GetSpace(_x, _z, direction);
            _spaceRect = GetSpaceRect(_x, _z, direction);
            _exits = GetExits(_x, _z, _direction);
        }

        public List<Path> GetExits(int x, int z, int dir) {
            switch(dir) {
                case 0: return new List<Path> {new Path(x, z - 20, 1), new Path(x, z + 20, 2)};
                case 1: return new List<Path> {new Path(x - 20, z, 3), new Path(x + 20, z, 0)};
                case 2: return new List<Path> {new Path(x, z - 20, 1), new Path(x, z + 20, 2)};
                case 3: return new List<Path> {new Path(x - 20, z, 3), new Path(x + 20, z, 0)};
            }
            throw new Exception("GetExits dir: " + dir);
        }
        
        public int[,] GetSpace(int x, int z, int dir) {
            switch(dir) {
                case 0: return new [,] {{x, z}, {x, z + 20}, {x, z - 20}};
                case 1: return new [,] {{x, z}, {x - 20, z}, {x + 20, z}};
                case 2: return new [,] {{x, z}, {x - 20, z}, {x + 20, z}};
                case 3: return new [,] {{x, z}, {x, z + 20}, {x, z - 20}};
            }
            throw new Exception("GetSpace dir: " + dir);
        }
        
        public Rect GetSpaceRect(int x, int z, int dir) {
            switch(dir) {
                case 0: return new Rect(x, z + 20, x, z - 20);
                case 1: return new Rect(x - 20, z, x + 20, z);
                case 2: return new Rect(x - 20, z, x + 20, z);
                case 3: return new Rect(x, z + 20, x, z - 20);
            }
            throw new Exception("GetSpaceRect dir: " + dir);
        }
        
        public static Rect GetCheckSpaceByDir(int dir, int x, int z) {
            switch(dir) {
                case 0: return new Rect(x + 20, z + 40, x + 40, z - 40);
                case 1: return new Rect(x - 40, z + 40, x + 40, z + 20);
                case 2: return new Rect(x - 40, z - 20, x + 40, z - 40);
                case 3: return new Rect(x - 40, z + 40, x - 20, z - 40);
                default: throw new Exception("GetCheckSpaceByDir - dir större än 3, borde inte ske...");
            }
        }
    }
}