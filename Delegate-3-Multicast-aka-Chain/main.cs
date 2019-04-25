using System;

delegate int Callback(int a, int b);

class MainClass {
  static int Sum(int i, int j) {
    Console.WriteLine("Sum");
    return i + j;
  }
  static int Multiply(int i, int j) {
    Console.WriteLine("Multiply");
    return i * j;
  }
  static int Power(int i, int j) {
    Console.WriteLine("Power");
    return (int)Math.Pow((double)i, (double)j);
  }

  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Callback cb;
    cb = Sum;
    print(cb(1, 2) == 3);

    cb = delegate (int i, int j) { return i + j; }; // 익명함수
    print(cb(1, 2) == 3);

    cb = (int i, int j) => { return i+j; };   // 람다식
    print(cb(1, 2) == 3);

    cb = (i, j) => i+j;                       // 람다식
    print(cb(1, 2) == 3);

    // print( ((i, j) => i+j)(10,20) == 30);   // Error

    print("\tChain");
    cb = Sum;
    cb += Multiply;
    cb += Power;
    print( cb(3, 2) == 9);
    cb -= Power;
    print( cb(3, 2) == 6);
    cb -= Multiply;
    print( cb(3, 2) == 5);
  }
}