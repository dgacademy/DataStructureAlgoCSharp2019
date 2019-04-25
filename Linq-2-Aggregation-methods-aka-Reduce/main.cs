using System;
using System.Linq;      // class extension


class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;
    int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

    print(numbers.Sum() == 55);
    print(numbers.Average() == 5.5);
    print(numbers.Max() == 10);
    print(numbers.Min() == 1);
    print(numbers.Count() == 10);
    print(numbers.First() == 1);
    print(numbers.Last() == 10);

    print(numbers.Aggregate(0, (memo, n) => memo + n) == 55); // sum
    print(numbers.Aggregate((memo, n) => memo + n) == 55);    // sum
    print(numbers.Aggregate((memo, n) => memo + 1) == 10);    // count
    
    print(numbers.Aggregate((memo, n) => n > memo ? n : memo) == 10);// max
    print(numbers.Aggregate(int.MaxValue, (memo, n) => n < memo ? n : memo) == 1);// max

    var str = new [] {"a", "b", "c", "d"};
    print(str.GetType().ToString());
    print(str.Aggregate( (memo, b) => memo + "," + b) == "a,b,c,d");
  }
}