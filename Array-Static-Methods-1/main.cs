using System;

class MainClass {  
  // delegate int Comp(int x, int y);
  public static int Comp(int x, int y) { return x.CompareTo(y); }

  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] scores = new int[] { 2, 4, 5, 3, 6, 8, 1, 7 };    // base class: Array
    
    print(scores.GetType().ToString() == "System.Int32[]");
    print(scores.GetType().BaseType.ToString() == "System.Array");
    
    print(Stringify(new int[] {2}) == "2");
    print(Stringify(new int[] {2, 3}) == "2 3");
    print(Stringify(new int[] {}) == string.Empty);
    print(Stringify(scores) == "2 4 5 3 6 8 1 7");
    
    
    // https://msdn.microsoft.com/ko-kr/library/zecdkyw2(v=vs.110).aspx
    Array.ForEach(scores, v => { Console.Write(v*2 + " "); });
    
    // Sorting: 오름차순(Ascending order)
    print("\n");
    print("\t\tSorting");
    Array.Sort( scores );
    print(Stringify(scores) == "1 2 3 4 5 6 7 8");
    
    // public static int Comp(int x, int y) { return x.CompareTo(y); }
    Array.Sort( scores, Comp);
    print(Stringify(scores) == "1 2 3 4 5 6 7 8");
    
    Array.Sort( scores, delegate (int x, int y) { return x.CompareTo(y); });
    print(Stringify(scores) == "1 2 3 4 5 6 7 8");    
    
    Array.Sort( scores, (x, y) => x.CompareTo(y) );
    print(Stringify(scores) == "1 2 3 4 5 6 7 8");

    Array.Sort( scores, (x, y) => x - y );
    print(Stringify(scores) == "1 2 3 4 5 6 7 8");    
    
    print(1.CompareTo(2) < 0);
    print(2.CompareTo(1) > 0);
    print(1.CompareTo(1) == 0);

    // Sorting: 내림차순(Descending order)
    Array.Sort( scores, (x, y) => y.CompareTo(x) );
    print(Stringify(scores) == "8 7 6 5 4 3 2 1");
    
    Array.Sort( scores, (x, y) => y - x ); // x < y:음수, x == y:0, x > y:양수
    print(Stringify(scores) == "8 7 6 5 4 3 2 1");
    
    //Sorting
    // https://support.microsoft.com/ko-kr/help/320727/how-to-use-the-icomparable-and-icomparer-interfaces-in-visual-c
    // http://www.csharp-examples.net/sort-array/
    
  }

  public static string Stringify(int[] list) { 
      string s = String.Empty;
      for(int i = 0;i < list.Length; i++)
        s += i != list.Length-1 ? list[i].ToString() + " " : list[i].ToString();
      return s;
  }  
}