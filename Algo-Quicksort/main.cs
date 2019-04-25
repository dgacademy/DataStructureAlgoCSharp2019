using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;
    
    int[] list; 
    list = new int[] {1};
    Quicksort(list, 0, list.Length-1);
    print(list.Stringify() == "1");

    list = new int[] {1, 2};
    Quicksort(list, 0, list.Length-1);
    print(list.Stringify() == "1 2");

    list = new int[] {2, 1};
    Quicksort(list, 0, list.Length-1);
    print(list.Stringify() == "1 2");

    list = new int[] {1, 2};
    print(Partition(list, 0, list.Length-1) == 0);

    list = new int[] {2, 1};
    print(Partition(list, 0, list.Length-1) == 1);

    list = new int[] {2, 1, 3};
    print(Partition(list, 0, list.Length-1) == 1);    

    list = new int[] {3, 2, 1};
    Quicksort(list, 0, list.Length-1);
    print(list.Stringify() == "1 2 3");        

    list = new int[] {5, 2, 7, 4, 5};
    Quicksort(list, 0, list.Length-1);
    print(list.Stringify() == "2 4 5 5 7");

    list = new int[] {5, 3, 8, 4, 9, 1, 6, 2, 7};
    Quicksort(list, 0, list.Length-1);
    print(list.Stringify() == "1 2 3 4 5 6 7 8 9");

    list = new int[] {5, 5, 5, 3, 3, 3, 2, 2, 1};
    Quicksort(list, 0, list.Length-1);
    print(list.Stringify() == "1 2 2 3 3 3 5 5 5");

    list = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
    Quicksort(list, 0, list.Length-1);
    print(list.Stringify() == "1 2 3 4 5 6 7 8 9");

    list = new int[] {9, 8, 7, 6, 5, 4, 3, 2, 1};
    Quicksort(list, 0, list.Length-1);
    print(list.Stringify() == "1 2 3 4 5 6 7 8 9");    
  }

  public static void Quicksort(int[] list, int left, int right) {
    if (left < right) {
      int p = Partition(list, left, right);
      // Console.WriteLine(list.Stringify() + ":   " + p);
      Quicksort(list, left, p-1);
      Quicksort(list, p+1, right);
    }
  }
  public static int Partition(int[] list, int left, int right) {
    int pivot = list[left];
    int i = left+1, j = right;

    // if (i == right) {
    //   if (list[right] < pivot) {
    //     Swap(ref list[left], ref list[right]);
    //     return right;
    //   } else 
    //     return left;
    // } 

    do {
      for(; i <= right; i++) {
        if (list[i] > pivot)
          break;
      }
      for(; j >= left+1; j--) {
        if (list[j] < pivot)
          break;
      }
      if ( i < j ) {
        Swap(ref list[i], ref list[j]);
      }
    } while(i < j);

    Swap(ref list[left], ref list[j]);
    return j;
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