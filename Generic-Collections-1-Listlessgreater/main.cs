// http://www.csharp-examples.net/list/
// https://msdn.microsoft.com/ko-kr/library/system.collections.generic(v=vs.110).aspx

using System;
using System.Collections.Generic;

public class MyComparer : IComparer<int>
{
    public int Compare(int x, int y) { return x.CompareTo(y); }
}

class MainClass {
  public static void Main (string[] args) {
    // System.Collections 문제: Boxing/Unboxing의 비효율성
    // Generic programming을 이용한 generic version이 나왔음
    // 앞으로 Generic collections 만 사용하면 된다!
    Action<object> print = Console.WriteLine;
    
    List<int> listA = new List<int>() { 8, 3, 2 };

    List<int> listB = new List<int>( listA );
    print( listB.Stringify() == "8 3 2" );
    
    listB = new List<int>() { 5, 7 };
    listA.AddRange(listB);
    print( listA.Stringify() == "8 3 2 5 7" );
    
    listA.Sort();
    print( listA.ToArray().Stringify() == "2 3 5 7 8" );
    List<int> sortedList = new List<int>( listA );
    print( sortedList.BinarySearch(3, new MyComparer()) == 1 );
    print( sortedList.BinarySearch(9, new MyComparer()) < 0);
    
    print( listA.Contains(3) == true );
    
    print( listA.Exists(x => x == 3) == true );
    
    listA = new List<int>() { 8, 3, 2 };
    listB = new List<int>() { 8, 3, 2 };
    print( listA.Equals(listB) == false );  // just reference
    
    print( listA.Exists(x => x == 3) == true );
    
    print( listA.Find(x => x > 2) == 8 );
    
    print( listA.FindAll(x => x > 2).Stringify() == "8 3" ) ;
    
    print( listA.FindIndex(x => x < 5) == 1 );
    
    print( listA.FindLast(x => x < 5) == 2 );
    
    print( listA.FindLastIndex(x => x < 5) == 2);
    
    listA = new List<int>() { 8, 3, 2, 4, 5 };
    print( listA.GetRange(1, 3).Stringify() == "3 2 4" );
    
    listA.Insert(1, 7);
    print( listA.Stringify() == "8 7 3 2 4 5" );
    
    print( listA.TrueForAll(x => x < 10) == true);
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}







