using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] list = new int[] {55, 7, 78, 12, 42};
    BubbleSort(list);
    print(list.Stringify() == "7 12 42 55 78");

    list = new int[] {5, 4, 3, 2, 1};
    BubbleSort(list);
    print(list.Stringify() == "1 2 3 4 5");    
  }

  public static void BubbleSort(int[] list) {
    for (int i = 0; i < list.Length-1; i++) {
      for (int j = 0; j < list.Length-1-i; j++) {
        if (list[j] > list[j+1]) {
          Swap(ref list[j], ref list[j+1]);
        }
      }
    }
  }
  public static void Swap(ref int a, ref int b) {
    int temp = a;
    a = b;
    b = temp;
  }  
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}