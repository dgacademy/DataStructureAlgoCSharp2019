// http://theory.stanford.edu/~amitp/GameProgramming/ImplementationNotes.html
// A*
// Greedy Best First Search 
// not optimal solution

using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print(AStarSearch.Heuristic(new AStarNode(0,0), new AStarNode(0,0) ) == 0);
    print(AStarSearch.Heuristic(new AStarNode(1,1), new AStarNode(2,2) ) == 2);
    print(AStarSearch.Heuristic(new AStarNode(0,0), new AStarNode(6,6) ) == 12);

    byte[][] map = new byte[][] {
      new byte[] {0, 0, 0, 1, 0, 0, 0},
      new byte[] {0, 0, 0, 1, 0, 1, 0},
      new byte[] {0, 0, 0, 0, 0, 1, 0},
      new byte[] {0, 0, 0, 0, 1, 1, 0},
      new byte[] {0, 0, 1, 1, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 1, 1},
      new byte[] {0, 0, 0, 0, 0, 0, 0}      
    };

    AStarSearch naive = new AStarSearch(new Grid(map));
    naive.FindPath(new AStarNode(0,0), new AStarNode(6,6));
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
    print("\n");

    map = new byte[][] {
      new byte[] {0, 1, 0, 0, 0, 0, 0},
      new byte[] {0, 1, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 1, 0, 0, 0, 0},
      new byte[] {0, 1, 1, 0, 0, 0, 0},
      new byte[] {0, 0, 1, 1, 1, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0}      
    };
    naive = new AStarSearch(new Grid(map));
    naive.FindPath(new AStarNode(1,4), new AStarNode(6,2));
    print(naive.pathGrid[0]);// == " 0  0  0  0  0  0  0");  // " 0  0  0  0  0  0  0"
    print(naive.pathGrid[1]);// == " 0  0  0  0  0  7  0");  // " 0  0  0  0  0  0  0"
    print(naive.pathGrid[2]);// == " 0  0  0  0  0  7  0");  // " 0  0  0  0  7  0  0"
    print(naive.pathGrid[3]);// == " 0  0  0  0  0  7  0");  // " 0  0  0  0  7  0  0"
    print(naive.pathGrid[4]);// == " 0  0  0  0  0  7  0");  // " 0  0  0  0  7  7  0"
    print(naive.pathGrid[5]);// == " 0  0  0  0  0  7  0");  // " 0  0  0  0  0  7  0"
    print(naive.pathGrid[6]);// == " 0  0  7  7  7  7  0");  // " 0  0  7  7  7  7  0"    
    print("\n");
    print(naive.costGrid[0]);// == " 7  0  3  2  1  2  3");
    print(naive.costGrid[1]);// == " 6  0  2  1  0  1  2");
    print(naive.costGrid[2]);// == " 5  4  3  2  1  2  3");
    print(naive.costGrid[3]);// == " 6  5  0  3  2  3  4");
    print(naive.costGrid[4]);// == " 7  0  0  4  3  4  5");
    print(naive.costGrid[5]);// == " 8  9  0  0  0  5  6");
    print(naive.costGrid[6]);// == " 9  0  9  8  7  6  7");
    print("\n");
    
    map = new byte[][] {
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0},
      new byte[] {0, 0, 0, 0, 0, 0, 0}      
    };
    naive = new AStarSearch(new Grid(map));
    naive.FindPath(new AStarNode(3,3), new AStarNode(6,6));
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

public class AStarNode : IComparable, IEquatable<AStarNode> {
  public int X { get; set; }
  public int Y { get; set; }
  public int G { get; set; }
  public int H { get; set; }
  public int F { 
    get {
      return G + H;
    }
  }  
  public AStarNode parent;

  public AStarNode(int x, int y) {
    X = x; Y = y;
    parent = null;
  }
  
  public bool Equals(AStarNode other) {
    if (other == null)
      return false;
    return X == other.X && Y == other.Y;
  }
  
  public int CompareTo(object other) {
    if (other == null) return 1;
    return this.F.CompareTo(((AStarNode)other).F);
  }  

  // public override bool Equals(Object other) {
  //   if (other == null || !(other is AStarNode))
  //     return false;
  //   return X == ((AStarNode)other).X && Y == ((AStarNode)other).Y;
  // }

  // // this.GetHashCode() != other.GetHashCode()면 Equals() 비교를 하지 않는다 !!!
  // public override int GetHashCode() {     
  //   return X ^ Y;
  // }
} 

public class Grid {
  byte[][] map;
  
  public int Width { get; private set; }
  public int Height { get; private set; }

  public HashSet<byte> Walls = new HashSet<byte>();

  static readonly AStarNode[] Dir = {
    new AStarNode(-1, 0), 
    // new AStarNode(-1, +1),
    new AStarNode(0, +1), 
    // new AStarNode(+1, +1),
    new AStarNode(+1, 0), 
    // new AStarNode(+1, -1),
    new AStarNode(0, -1)
    // new AStarNode(-1, -1)
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

  public bool InBounds(AStarNode n) {
    if (n.X < 0 || n.X >= Height || n.Y < 0 || n.Y >= Width)
      return false;
    return true;
  }

  public bool IsWall(AStarNode n) {
    return Walls.Contains(this[n.X, n.Y]);
  }

  public IEnumerable<AStarNode> Neighbors(AStarNode c) {
    int x = c.X;
    int y = c.Y;
    foreach(var d in Dir) {
      AStarNode n = new AStarNode(x+d.X, y+d.Y);
      if (InBounds(n) && !IsWall(n))
        yield return n;
    }
  }  
}


public class AStarSearch {
  Grid mapGrid;
  public Grid pathGrid;
  public Grid costGrid;

  public AStarSearch(Grid grid) {
    this.mapGrid = grid;
    pathGrid = new Grid(grid.Width, grid.Height);
    costGrid = new Grid(grid.Width, grid.Height);
    mapGrid.Walls.Add(1); // 1 is wall
  }

  public bool FindPath(AStarNode start, AStarNode goal) {
    Action<object> print = Console.WriteLine;

    var openList = new MinHeap<AStarNode>();
    var closedList = new List<AStarNode>();    

    openList.Insert(start);

    while (openList.Count > 0) {
      AStarNode current = openList.RemoveTop();
      closedList.Add(current);

      if (current.Equals(goal)) {
        AStarNode c = current;
        while (c.parent != null) {
          pathGrid[c.X, c.Y] = 7;
          c = c.parent;
        }
        return true;
      } else {
        foreach(var n in mapGrid.Neighbors(current)) {
          if (closedList.Contains(n))
            continue;

          n.G = current.G + 1;   // cost(c, n) = 1;
          AStarNode n2 = openList.Find( p=>p.Equals(n) );
          if (n2 != null) {
            // print( openList.list.FindAll(p=>p.Equals(n)).Count );
            // print("n2 not null");
            if (n.G < n2.G) {
              openList.Remove(n2);
              print("In n2");
            } else 
              continue;
          }
          // Random rand = new Random();
          // n.H = Heuristic(n, goal) + rand.Next(0,10) * 0.1;
          n.H = Heuristic(n, goal);
          costGrid[n.X, n.Y] = (byte)n.G;          
          n.parent = current;
          openList.Insert(n);
        }
      }
    }
    return false;
  }

  public static int Heuristic(AStarNode a, AStarNode b) {
    return Math.Abs(a.X-b.X) + Math.Abs(a.Y-b.Y);   // Manhattan distance
  }
}


public class MinHeap<T> where T: IComparable, IEquatable<T> {
  public List<T> list;
  public int Count {
    get {
      return list.Count;
    }
  }
  public MinHeap() {
    list = new List<T>();
  }

  public void Insert(T v) {
    list.Add(v);
    HeapifyUp(list.Count-1);
  }

  public T RemoveTop() {
    if (list.Count > 0) {
      T v = list[0];              
      list[0] = list[list.Count-1];
      list.RemoveAt(list.Count-1);
      HeapifyDown(0);
      return v;
    } else {
      throw new InvalidOperationException("No data");
    }
  }

  public void Remove(T v) {
    if (list.Count > 0) {
      int index = list.FindIndex( o=>o.Equals(v) );
      if (index != -1) {
        list[index] = list[list.Count-1];
        list.RemoveAt(list.Count-1);
        HeapifyDown(index);
      }
    }
  }  
  
  public T Find(Predicate<T> f) {
    int i = list.FindIndex(f);
    if (i != -1)
      return list[i];
    else
      return default(T);
  }

  void HeapifyUp(int i) {
    if (i < 1)
      return;
    int p = Parent(i);
    //if (list[p] > list[i]) {
    if (list[p].CompareTo(list[i]) > 0) {
      list.Swap(p, i);
      HeapifyUp(p);
    }
  }

  void HeapifyDown(int p) {
    if (list.Count <= 1)
      return;
    int l = LChild(p);
    int r = RChild(p);
    if (IsLeaf(p))
      return;
    if (r > list.Count-1) {   // r does not exist(only l)
      // if (list[l] < list[p]) {
      if (list[l].CompareTo(list[p]) < 0) {  
        list.Swap(l, p);
        return;
      }
    } else {                  // l and r exist
      // if (list[l] <= list[r]) {
      if (list[l].CompareTo(list[r]) <= 0) {
        // if (list[l] < list[p]) {
        if (list[l].CompareTo(list[p]) < 0) {
          list.Swap(l, p);
          HeapifyDown(l);
        }
      } else {
        // if (list[r] < list[p]) {
        if (list[r].CompareTo(list[p]) < 0) {
          list.Swap(r, p);
          HeapifyDown(r);
        }
      }
    }
  }

  int Parent(int i)  { return (i-1)/2; }
  int LChild(int i) { return 2*i+1; }
  int RChild(int i) { return LChild(i)+1; }
  bool IsLeaf(int i) { return LChild(i) > list.Count-1; }

  public string Stringify() {
    return list.Stringify();
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

  // https://stackoverflow.com/questions/2094239/swap-two-items-in-listt
  public static IList<T> Swap<T>(this IList<T> list, int i, int j) {
    T temp = list[i];
    list[i] = list[j];
    list[j] = temp;
    return list;
  }    
}
