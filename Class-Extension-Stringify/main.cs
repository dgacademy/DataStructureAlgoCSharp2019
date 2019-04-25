using System;
using System.Collections.Generic;

public static class ClassExtension {

  // public static string Stringify<T>(this List<T> list) {
    // return String.Join(" ", list);
  // }

  // public static string Stringify(this int[] list) {
    // return String.Join(" ", list);
  // }

  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
  
}

class Student {
    public string name;
    public int[] scores;
    
    public override string ToString() { return name; }
}

class MainClass {
  public static void Main (string[] args) {
    List<int> list = new List<int>() { 8, 3, 2 };
    Console.WriteLine(list.Stringify() == "8 3 2");
    
    int[] array = list.ToArray();
    Console.WriteLine(array.Stringify() == "8 3 2");

    Console.WriteLine( "lec".Stringify() == "l e c");
    Console.WriteLine( (new char[] { 'l', 'e', 'c'}).Stringify() == "l e c");
    Console.WriteLine( (new int[] { 1 }).Stringify() == "1");
    
    List<Student> students = new List<Student>() {
      new Student() { name="ctkim", scores = new int[] { 100, 70, 90, 77, 88 } },
      new Student() { name="Steve", scores = new int[] { 77, 60, 90, 77, 55 } },
      new Student() { name="Brown", scores = new int[] { 30, 61, 91, 100, 57 } },
      new Student() { name="Won", scores = new int[] { 100, 100, 91, 100, 100 } },
      new Student() { name="JJ", scores = new int[] { 10, 100, 91, 100, 100 } }
    };
    Console.WriteLine( students.Stringify() == "ctkim Steve Brown Won JJ");
 }
}

