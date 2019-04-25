using System;

class MainClass {
  public enum Color { Red, Green, Blue };

  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    // switch
    Random rnd = new Random();
    Color c = (Color) rnd.Next(0, 4); // 0 ~ 3 random value
    switch(c) {
      case Color.Red:
        print(c == Color.Red);
        break;
      case Color.Green:
        print(c == Color.Green);
        break;
      case Color.Blue:
        print(c == Color.Blue);
        break;
      default:
        print("Unknown Color!");
        break;
    }

    if (c == Color.Red)
        print(c == Color.Red);
    else if (c == Color.Green)
        print(c == Color.Green);
    else if (c == Color.Blue)
        print(c == Color.Blue);
    else
        print("Unknown Color!");  

    switch(c) {
      case Color.Red:
      case Color.Green:
      case Color.Blue:
        print(c);
        break;
      default:
        print("Unknown Color!");
        break;
    }

    int[] scores = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    print(SumIf(scores, v => v%2==0) == 30);
    print(SumIf(scores, v => v%2!=0) == 25);
    print(SumIf(scores, v => v > 6) == 34);
    print(SumIf(scores, v => true) == 55);

    print(SumIf2(scores, v => v%2==0) == 30);
    print(SumIf2(scores, v => true) == 55);
    
    int count = 1;
    print(++count == 2);
    count = 1;
    print(count++ == 1);

    int a = 9, b = 8;
    int carry = a+b > 10 ? 1 : 0;
    int remainder = a+b > 10 ? a+b - 10 : a+b;      // conditional operator
    print(carry == 1 && remainder == 7);    // short-circuit evaluation

  }

  public static int SumIf(int[] list, Func<int,bool> condition) {
    int i = 0;
    int sum = 0;
    while (i < list.Length) {
      if (!condition(list[i])) {
        i++;
        continue; 
      } 
      sum += list[i++];
    }
    return sum;
  }

  public static int SumIf2(int[] list, Func<int,bool> condition) {
    int i = 0;
    int sum = 0;
    do {
      if (condition(list[i])) {
        sum += list[i];
      } 
    } while(++i < list.Length);

    return sum;
  }  
}