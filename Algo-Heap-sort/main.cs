using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    MinHeap h = new MinHeap();
    h.Insert(7);
    print( h.Stringify() == "7");
    h.Insert(1);
    print( h.Stringify() == "1 7");    
    h.Insert(3);
    h.Insert(2);
    h.Insert(5);
    h.Insert(1);
    h.Insert(8);
    print( h.Stringify() == "1 2 1 7 5 3 8");
    h.Insert(0);
    print( h.Stringify() == "0 1 1 2 5 3 8 7");

    print( h.RemoveTop() == 0 );
    print( h.Stringify() == "1 2 1 7 5 3 8");
    print( h.RemoveTop() == 1 );
    print( h.Stringify() == "1 2 3 7 5 8");
    print( h.RemoveTop() == 1 );
    print( h.Stringify() == "2 5 3 7 8");
    print( h.RemoveTop() == 2 );
    print( h.Stringify() == "3 5 8 7");
    print( h.RemoveTop() == 3 );
    print( h.Stringify() == "5 7 8");
    print( h.RemoveTop() == 5 );
    print( h.Stringify() == "7 8");
    print( h.RemoveTop() == 7 );
    print( h.Stringify() == "8");
    print( h.RemoveTop() == 8 );
    print( h.Stringify() == "");    
    try {
      print( h.RemoveTop() );
    }catch {
    }

    // Heap sort
    int[] list = { 7, 1, 3, 2, 5, 1, 8, 0 };
    HeapSort(list);
    print( list.Stringify() == "0 1 1 2 3 5 7 8" );
  }

  public static void HeapSort(int[] list) {
    var h = new MinHeap();

    for (int i = 0; i < list.Length; i++)
      h.Insert(list[i]);
    
    int j = 0;
    while (h.Count > 0) {
      list[j++] = h.RemoveTop();  
    }
  }
}


public class MinHeap {
  List<int> list;
  public int Count {
    get {
      return list.Count;
    }
  }
  public MinHeap() {
    list = new List<int>();
  }

  public void Insert(int v) {
    list.Add(v);
    int i = list.Count-1;
    if (i < 1)
      return;
    HeapifyUp(i);
  }

  public int RemoveTop() {
    if (list.Count > 0) {
      int v = list[0];              
      list[0] = list[list.Count-1];
      list.RemoveAt(list.Count-1);
      HeapifyDown(0);
      return v;
    } else {
      throw new InvalidOperationException("No data");
    }
  }
  
  void HeapifyUp(int i) {
    int p = Parent(i);
    if (p >= 0 && list[p] > list[i]) {
      list.Swap(p, i);
      HeapifyUp(p);
    }
  }

  void HeapifyDown(int p) {
    if (list.Count <= 1)
      return;
    int l = LChild(p);
    int r = RChild(p);
    if (l > list.Count-1 && r > list.Count-1)   // p is leaf
      return;
    if (r > list.Count-1) {   // r is not exist(only l)
      if (list[l] < list[p]) {
        list.Swap(l, p);
        return;
      }
    } else {                  // l and r are exist
      if (list[l] <= list[r]) {
        if (list[l] < list[p]) {
          list.Swap(l, p);
          HeapifyDown(l);
        }
      } else {
        if (list[r] < list[p]) {
          list.Swap(r, p);
          HeapifyDown(r);
        }
      }
    }
  }

  int Parent(int i)  { return (i-1)/2; }
  int LChild(int i) { return 2*(i+1)-1; }
  int RChild(int i) { return LChild(i)+1; }

  public string Stringify() {
    return list.Stringify();
  }

}



public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }

  // https://stackoverflow.com/questions/2094239/swap-two-items-in-listt
  public static IList<T> Swap<T>(this IList<T> list, int i, int j) {
    T temp = list[i];
    list[i] = list[j];
    list[j] = temp;
    return list;
  }  
}