using System;
using System.Collections;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    ArrayList list = new ArrayList();
    list.Add(100);
    print((int)list[0] == 100);
    list.Add(200);
    print(list.Count == 2);
    // list.Insert(5, 300);       // System.ArgumentOutOfRangeException !!!
    list.Insert(2, 300);
    print((int)list[2] == 300);

    list.Remove(100);
    print(list.Count == 2);
    print((int)list[0] == 200);
    print((int)list[1] == 300);

    foreach(var v in list)
      print(v);
    
    print(list.Contains(200) == true);
    print(list.Contains(700) == false);
  }
}