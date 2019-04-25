using System;

// public delegate TResult Func<in T, out TResult>(
// 	T arg
// );

class MainClass {
  static double divide(int x, int y) {
    return x/y;
  }

  public static void Main (string[] args) {
    Action act1 = () => Console.WriteLine("Action");
    act1();
    
    Action<int> act2 = (x) => Console.WriteLine(2 * x);
    act2(2);
    
    Action<double, double> act3 = (x, y) => Console.WriteLine(x / y);
    act3(10, 20);

    Func<int> fn1 = () => 10;
    Console.WriteLine(fn1() == 10);
    Func<int, int, double> fn3 = divide;// or (x, y) => x/y;
    Console.WriteLine(fn3(40, 20) == 2);

    Func<int, int, int, int, int, int, int, int, int, int, int, int, int> fn13;
    fn13 = (a, b, c, d, e, f, g, h, i, j, k, l) => a+b+c+d+e+f+g+h+i+j+k+l;
    Console.WriteLine(fn13(1,1,1,1,1,1,1,1,1,1,1,1) == 12);
  }
}