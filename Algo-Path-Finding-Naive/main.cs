// http://theory.stanford.edu/~amitp/GameProgramming/ImplementationNotes.html
// Naive algorithm(Dijkstra’s Algorithm)
// BFS, optimal solution


using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    byte[][] map = new byte[][] {
      new byte[] {0, 0, 0, 1, 0, 0, 0},
      new byte[] {0, 0, 0, 1, 0, 1, 0},
      new byte[] {0, 0, 0, 0, 0, 1, 0},
      new byte[] {0, 0, 0, 0, 1, 1, 0},
      new byte[] {0, 0, 1, 1, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 1, 1},
      new byte[] {0, 0, 0, 0, 0, 0, 0}      
    };

    NaiveSearch naive = new NaiveSearch(new Grid(map));
    naive.FindPath(new Node(0,0), new Node(6,6));
    print(naive.pathGrid[0]);// == " 0  7  0  0  0  0  0");
    print(naive.pathGrid[1]);// == " 0  7  0  0  0  0  0");
    print(naive.pathGrid[2]);// == " 0  7  0  0  0  0  0");
    print(naive.pathGrid[3]);// == " 0  7  0  0  0  0  0");
    print(naive.pathGrid[4]);// == " 0  7  0  0  0  0  0");
    print(naive.pathGrid[5]);// == " 0  7  7  7  7  0  0");
    print(naive.pathGrid[6]);// == " 0  0  0  0  7  7  7");
    print("\n");
    print(naive.costGrid[0]);// == " 0  1  2  0  8  9 10");
    print(naive.costGrid[1]);// == " 1  2  3  0  7  0 11");
    print(naive.costGrid[2]);// == " 2  3  4  5  6  0 12");
    print(naive.costGrid[3]);// == " 3  4  5  6  0  0 13");
    print(naive.costGrid[4]);// == " 4  5  0  0 10 11 12");
    print(naive.costGrid[5]);// == " 5  6  7  8  9  0  0");
    print(naive.costGrid[6]);// == " 6  7  8  9 10 11 12");

    map = new byte[][] {
      new byte[] {0, 1, 0, 0, 0, 0, 0},
      new byte[] {0, 1, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 1, 0, 0, 0, 0},
      new byte[] {0, 1, 1, 0, 0, 0, 0},
      new byte[] {0, 0, 1, 1, 1, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0}      
    };
    naive = new NaiveSearch(new Grid(map));
    naive.FindPath(new Node(1,4), new Node(6,2));
    print(naive.pathGrid[0] == " 0  0  0  0  0  0  0");  // " 0  0  0  0  0  0  0"
    print(naive.pathGrid[1] == " 0  0  0  0  0  7  0");  // " 0  0  0  0  0  0  0"
    print(naive.pathGrid[2] == " 0  0  0  0  0  7  0");  // " 0  0  0  0  7  0  0"
    print(naive.pathGrid[3] == " 0  0  0  0  0  7  0");  // " 0  0  0  0  7  0  0"
    print(naive.pathGrid[4] == " 0  0  0  0  0  7  0");  // " 0  0  0  0  7  7  0"
    print(naive.pathGrid[5] == " 0  0  0  0  0  7  0");  // " 0  0  0  0  0  7  0"
    print(naive.pathGrid[6] == " 0  0  7  7  7  7  0");  // " 0  0  7  7  7  7  0"    

    print(naive.costGrid[0] == " 7  0  3  2  1  2  3");
    print(naive.costGrid[1] == " 6  0  2  1  0  1  2");
    print(naive.costGrid[2] == " 5  4  3  2  1  2  3");
    print(naive.costGrid[3] == " 6  5  0  3  2  3  4");
    print(naive.costGrid[4] == " 7  0  0  4  3  4  5");
    print(naive.costGrid[5] == " 8  9  0  0  0  5  6");
    print(naive.costGrid[6] == " 9  0  9  8  7  6  7");

    map = new byte[][] {
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0}      
    };
    naive = new NaiveSearch(new Grid(map));
    naive.FindPath(new Node(3,3), new Node(6,6));
    print(naive.pathGrid[0]);
    print(naive.pathGrid[1]);
    print(naive.pathGrid[2]);
    print(naive.pathGrid[3]);
    print(naive.pathGrid[4]);
    print(naive.pathGrid[5]);
    print(naive.pathGrid[6]);
    print("\n");
    print(naive.costGrid[0]);
    print(naive.costGrid[1]);
    print(naive.costGrid[2]);
    print(naive.costGrid[3]);
    print(naive.costGrid[4]);
    print(naive.costGrid[5]);
    print(naive.costGrid[6]);    
  }
}

public class Node {
  public int X { get; set; }
  public int Y { get; set; }
  public Node parent;

  public Node(int x, int y) {
    X = x; Y = y;
    parent = null;
  }
  
  public override bool Equals(Object other) {
    if (other == null || !(other is Node))
      return false;
    return X == ((Node)other).X && Y == ((Node)other).Y;
  }

  // this.GetHashCode() != other.GetHashCode()면 Equals() 비교를 하지 않는다 !!!
  public override int GetHashCode() {     
    return X ^ Y;
  }
} 

public class Grid {
  byte[][] map;
  
  public int Width { get; private set; }
  public int Height { get; private set; }

  public HashSet<byte> Walls = new HashSet<byte>();

  static readonly Node[] Dir = {
    new Node(-1, 0),
    new Node(0, +1),
    new Node(+1, 0),
    new Node(0, -1)    
  };

  public Grid(byte[][] map) {
    this.map = map;
    Width = map[0].Length;
    Height = map.Length;
  }
  public Grid(int width, int height) {
    this.map = new byte[height][];
    for (int i = 0; i < height; i++)
      this.map[i] = new byte[width];
    Width = width;
    Height = height;
  }

  public string this[int i] {
    get {
      return map[i].Stringify();
    }
  }

  public byte this[int i, int j] {
    get {
      return map[i][j];
    }
    set {
      map[i][j] = value;
    }
  }  

  public bool InBounds(Node n) {
    if (n.X < 0 || n.X >= Height || n.Y < 0 || n.Y >= Width)
      return false;
    return true;
  }

  public bool IsWall(Node n) {
    return Walls.Contains(this[n.X, n.Y]);
  }

  public IEnumerable<Node> Neighbors(Node c) {
    int x = c.X;
    int y = c.Y;
    foreach(var d in Dir) {
      Node n = new Node(x+d.X, y+d.Y);
      if (InBounds(n) && !IsWall(n))
        yield return n;
    }
  }  
}


public class NaiveSearch {
  Grid mapGrid;
  public Grid pathGrid;
  public Grid costGrid;

  public NaiveSearch(Grid grid) {
    this.mapGrid = grid;
    pathGrid = new Grid(grid.Width, grid.Height);
    costGrid = new Grid(grid.Width, grid.Height);
    mapGrid.Walls.Add(1);
  }

  public bool FindPath(Node start, Node goal) {
    // Action<object> print = Console.WriteLine;

    var openList = new Queue<Node>();
    var closedList = new List<Node>();

    openList.Enqueue(start);

    while (openList.Count > 0) {
      Node current = openList.Dequeue();
      closedList.Add(current);

      if (current.Equals(goal)) {
        Node c = current;
        while (c.parent != null) {
          pathGrid[c.X, c.Y] = 7;
          c = c.parent;
        }
        return true;
      } else {
        foreach(var n in mapGrid.Neighbors(current)) {
          if (openList.Contains(n))
            continue;
          if (closedList.Contains(n))
            continue;

          costGrid[n.X, n.Y] = (byte)(costGrid[current.X, current.Y] + 1);  // cost(c, n) = 1;
          n.parent = current;
          openList.Enqueue(n);
        }
      }
    }
    return false;
  }

}



public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    string s = string.Empty;
    foreach(var v in list)
      s += string.Format("{0,2}", v) + " ";
    if (s.Length > 0)
      s = s.Substring(0, s.Length-1);
    return s;
  }
}
