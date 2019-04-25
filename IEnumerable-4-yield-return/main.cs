// http://theeye.pe.kr/archives/2725

using System;
using System.Collections.Generic;

public class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    foreach (int n in OddNumbers()) {
      print (n);
    }
    print("\n");

    IEnumerator<int> enumerator = OddNumbers().GetEnumerator();
    while (enumerator.MoveNext()) {
      print (enumerator.Current);
    } 

    foreach (var n in Neighbors(10, 10))
      print(n.X+","+n.Y);   
  }

  // 자동으로 IEnumerator를 구현해 주는 것 같음
  public static IEnumerable<int> OddNumbers() {       // Notice: not IEnumerator, Async function
    yield return 1;
    yield return 3;
    yield return 5;
  }

 public static IEnumerable<AStarNode> Neighbors(int x, int y) {
   yield return new AStarNode(x-1,y+0);
   yield return new AStarNode(x+0,y+1);
   yield return new AStarNode(x+1,y+0);
   yield return new AStarNode(x+0,y-1);
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
  public AStarNode(int x, int y) {
    X = x; 
    Y = y;
    G = 0;
    H = 0;
    parent = null;
  }
  public AStarNode parent;
  
  public bool Equals(AStarNode other) {
    return X == other.X && Y == other.Y;
  }
  public int CompareTo(object other)
  {
    if (other == null) return 1;
    return this.F.CompareTo(((AStarNode)other).F);
  }
}

// public class PowersOf2
// {
//   static void Main()
//   {
//     // Display powers of 2 up to the exponent of 8:
//     foreach (int i in Power(2, 8))
//     {
//       Console.Write("{0} ", i);
//     }
//   }

//   public static IEnumerable<int> Power(int number, int exponent)
//   {
//     int result = 1;

//     for (int i = 0; i < exponent; i++)
//     {
//       result = result * number;
//       yield return result;
//     }
//   }

//   // Output: 2 4 8 16 32 64 128 256
// }