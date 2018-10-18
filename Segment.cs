namespace DefaultNamespace {
    public class Segment {
        private readonly int _x;
        private readonly int _z;
        private readonly int _direction;
        private readonly int[,] _checkSpace;


        public Segment(int x, int z, int direction, int[,] checkSpace) {
            _x = x;
            _z = z;
            _direction = direction;
            _checkSpace = checkSpace;
        }

        public int X {
            get { return _x; }
        }

        public int Z {
            get { return _z; }
        }
        
        public int Direction {
            get { return _direction; }
        }
        
        public int[,] CheckSpace {
            get { return _checkSpace; }
        }
    }
}