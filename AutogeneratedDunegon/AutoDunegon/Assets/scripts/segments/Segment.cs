
using Boo.Lang;
using DefaultNamespace;
using Rect = Util.Rect;

public abstract class Segment {
    protected readonly int _x;
    protected readonly int _z;
    protected readonly int _direction;
    protected readonly Rect _checkSpace; //space to check before inserting this
    protected int[,] _space; //space that should be tiled
    protected Rect _spaceRect; //rectangle of space occupied by this
    protected List<Path> _exits;

    public Segment(int x, int z, int direction, Rect checkSpace) {
        _direction = direction > 3 ? direction - 3 : direction;
        _x = GetXByDirection(x, direction);
        _z = GetZByDirection(z, direction);
        _checkSpace = checkSpace;
    }
    
    private int GetXByDirection(int x, int dir) {
        switch (dir) {
            case 0: return x + 20;
            case 3: return x - 20;
            default: return x;
        }
    }
    
    private int GetZByDirection(int z, int dir) {
        switch (dir) {
            case 1: return z + 20;
            case 2: return z - 20;
            default: return z;
        }
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

    public Rect CheckSpace {
        get { return _checkSpace; }
    }

    public int[,] Space {
        get { return _space; }
    }
    
    public Rect SpaceRect {
        get { return _spaceRect; }
    }
    
    public List<Path> Exits {
        get { return _exits; }
    }

}
