using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print( LengthOf("") == 0 );
    print( LengthOf("Hello") == 5 );
    print( LengthOf("Hello Unity") == 11 );

    print( MaxOf(new int[] {}) == -1);
    print( MaxOf(new int[] {10, 20, 90, 1}) == 90);
    print( MaxOf(new int[] {100, 20, 90, 1}) == 100);

    print( MaxOf(new int[] {}) == -1);
    print( MaxOf2(new int[] {10, 20, 90, 1}, 0) == 90);
  }

  public static int LengthOf(string str) {
    if (str == String.Empty)
      return 0;
    return 1 + LengthOf(str.Substring(1));
  }

  public static int MaxOf(int[] list) {
    if (list.Length <= 1)
      return list.Length == 0 ? -1 : list[0];
    int[] newList = new int[list.Length-1];
    Array.Copy(list, newList, list.Length-1);
    return Math.Max(MaxOf(newList), list[list.Length-1]);
  }

  public static int MaxOf2(int[] list, int begin) {
    if (begin >= list.Length-1)
      return list.Length == 0 ? -1 : list[list.Length-1];
    return Math.Max(list[begin], MaxOf2(list, ++begin));
  }  
}

