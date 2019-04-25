using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    var h = new MinHeap<int>();
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

    h.Remove(1);
    print( h.Stringify() == "0 2 1 7 5 3 8");

    print( h.Find(o=>o==2) == 2 );

    h.Insert(1);
    h.Remove(0); // or print( h.RemoveTop() == 0 );
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

    var todoList = new MinHeap<Todo>();
    todoList.Insert(new Todo(0, 10, "Game"));
    todoList.Insert(new Todo(1, 1, "H/W"));
    todoList.Insert(new Todo(2, 5, "Drinking"));
    todoList.Insert(new Todo(3, 0, "Walking"));
    todoList.Insert(new Todo(4, 7, "Sleep"));

    todoList.Remove( todoList.Find(o=>o.id==3) );
    // print( todoList.RemoveTop().ToString() == "0,Walking");
    print( todoList.RemoveTop().ToString() == "1,H/W");
    print( todoList.RemoveTop().ToString() == "5,Drinking");
    print( todoList.RemoveTop().ToString() == "7,Sleep");
    print( todoList.RemoveTop().ToString() == "10,Game");


    // Heap sort
    int[] list = { 7, 1, 3, 2, 5, 1, 8, 0 };
    HeapSort(list);
    print( list.Stringify() == "0 1 1 2 3 5 7 8" );
  }

  public static void HeapSort(int[] list) {
    MinHeap<int> h = new MinHeap<int>();

    for (int i = 0; i < list.Length; i++)
      h.Insert(list[i]);
    
    int j = 0;
    while (h.Count > 0) {
      list[j++] = h.RemoveTop();  
    }
  }
}

public class Todo : IComparable, IEquatable<Todo> {
  public int id;
  public int priority;
  public string desc;
  public Todo(int id, int priority, string desc) {
    this.id = id;
    this.priority = priority;
    this.desc = desc;
  }

  public int CompareTo(object other) {
    return priority.CompareTo(((Todo)other).priority);
  }

  public bool Equals(Todo t) {
    return id == t.id;
  }

  public override string ToString() {
    return priority.ToString() + "," + desc;
  }
}


public class MinHeap<T> where T: IComparable, IEquatable<T> {
  List<T> list;
  public int Count {
    get {
      return list.Count;
    }
  }
  public MinHeap() {
    list = new List<T>();
  }

  public void Insert(T v) {
    list.Add(v);
    HeapifyUp(list.Count-1);
  }

  public T RemoveTop() {
    if (list.Count > 0) {
      T v = list[0];              
      list[0] = list[list.Count-1];
      list.RemoveAt(list.Count-1);
      HeapifyDown(0);
      return v;
    } else {
      throw new InvalidOperationException("No data");
    }
  }

  public void Remove(T v) {
    if (list.Count > 0) {
      int index = list.FindIndex( o=>o.Equals(v) );
      if (index != -1) {
        list[index] = list[list.Count-1];
        list.RemoveAt(list.Count-1);
        HeapifyDown(index);
      }
    }
  }  
  
  public T Find(Predicate<T> f) {
    int i = list.FindIndex(f);
    if (i != -1)
      return list[i];
    else
      return default(T);
  }

  void HeapifyUp(int i) {
    if (i < 1)
      return;
    int p = Parent(i);
    //if (list[p] > list[i]) {
    if (list[p].CompareTo(list[i]) > 0) {
      list.Swap(p, i);
      HeapifyUp(p);
    }
  }

  void HeapifyDown(int p) {
    if (list.Count <= 1)
      return;
    int l = LChild(p);
    int r = RChild(p);
    if (IsLeaf(p))
      return;
    if (r > list.Count-1) {   // r does not exist(only l)
      // if (list[l] < list[p]) {
      if (list[l].CompareTo(list[p]) < 0) {  
        list.Swap(l, p);
        return;
      }
    } else {                  // l and r exist
      // if (list[l] <= list[r]) {
      if (list[l].CompareTo(list[r]) <= 0) {
        // if (list[l] < list[p]) {
        if (list[l].CompareTo(list[p]) < 0) {
          list.Swap(l, p);
          HeapifyDown(l);
        }
      } else {
        // if (list[r] < list[p]) {
        if (list[r].CompareTo(list[p]) < 0) {
          list.Swap(r, p);
          HeapifyDown(r);
        }
      }
    }
  }

  int Parent(int i)  { return (i-1)/2; }
  int LChild(int i) { return 2*i+1; }
  int RChild(int i) { return LChild(i)+1; }
  bool IsLeaf(int i) { return LChild(i) > list.Count-1; }

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