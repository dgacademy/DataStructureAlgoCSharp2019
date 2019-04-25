using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    print(BinarySearch(list, 0, 0, list.Length-1) == 0);
    print(BinarySearch(list, 7, 0, list.Length-1) == 7);
    print(BinarySearch(list, 3, 0, list.Length-1) == 3);
    list = new int[] { 8 };
    print(BinarySearch(list, 3, 0, list.Length-1) == -1);
    print(BinarySearch(list, 8, 0, list.Length-1) == 0);
  }

  public static int BinarySearch(int[] list, int value, int left, int right) {
    if (left > right)
      return -1;
    int mid = (left+right) / 2;
    if (list[mid] == value)
      return mid;
    if (list[mid] < value)
      return BinarySearch(list, value, mid+1, right);
    else
      return BinarySearch(list, value, left, mid-1);
  }
}


public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}