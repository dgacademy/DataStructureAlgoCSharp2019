using System;

class MainClass {
  public static void Swap(ref int a, ref int b) {
    int temp = a;
    a = b;
    b = temp;
  }

  public static void Swap(ref object a, ref object b) {
    object temp = a;
    a = b;
    b = temp;
  }

  public static void Swap(Point a, Point b) {
    int x = a.x;
    int y = a.x;
    a.x = b.x;
    a.y = b.y;
    b.x = x;
    b.y = y;
  }  
  
  public static void Sum(int a, int b, out int sum) {
    sum = a + b;
  }
  
  public static void Main (string[] args) {
    int a = 10;
    int b = 20;
    Swap(ref a, ref b);
    Console.WriteLine(a == 20 && b == 10);

    object x = 100;
    object y = 200;
    Swap(ref x, ref y);
    Console.WriteLine((int)x == 200 && (int)y == 100);

    Point pointA = new Point(10, 20);
    Point pointB = new Point(30, 40);
    Swap(pointA, pointB);
    Console.WriteLine(pointA.x == 30);



    // int s = 0;
    // Sum(10, 20, ref s);
    // Console.WriteLine(s == 30);

    int sum;
    Sum(10, 20, out sum);
    Console.WriteLine(sum == 30);

  }

  public class Point {      // caution: public 
    public int x, y;
    public Point(int _x, int _y) {
      x = _x; 
      y = _y;
    }

    public override bool Equals(object obj) {
      Console.WriteLine("Equals()");
      if (obj.GetType() != this.GetType()) 
        return false;
      Point other = (Point) obj;
      return (this.x == other.x) && (this.y == other.y);
    }
    public override int GetHashCode() {
      return x ^ y;
    }
  }
}