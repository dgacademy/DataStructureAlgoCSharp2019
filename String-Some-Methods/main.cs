using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;
    
    string s;
    s = "ABC";
    print(s.Length == 3);
    
    s = string.Empty;
    print(s == "");
    
    s = "ABCDEF";
    print(s.IndexOf("CDE") == 2);
    print(s.IndexOf("ZZZ") == -1);
    
    s = "Mr Song";
    print(s.Replace("Mr", "Miss") == "Miss Song");

    int[] listA = {1, 3, 5, 7, 9};
    print(String.Join(" ", listA) == "1 3 5 7 9");
    print(Stringify(listA) == "1 3 5 7 9");

    s = "1000,2000,3000";
    string[] prices = s.Split(',');
    print(String.Join(" ", prices) == "1000 2000 3000");
    
    s = "1000, 2000, 3000";
    prices = s.Replace(" ", String.Empty).Split(',');
    print(String.Join(" ", prices) == "1000 2000 3000");
    
    s = "ABCDEF";
    print(s.Substring(1, 3) == "BCD");
    // print(s.Substring(7, 3));    // ArgumentOutOfRangeException !!!
  }

  public static string Stringify(int[] list) { 
      // string s = String.Empty;
      // for(int i = 0;i < list.Length; i++)
      //   s += i != list.Length-1 ? list[i].ToString() + " " : list[i].ToString();
      // return s;
      return String.Join(" ", list);
  }    
}


