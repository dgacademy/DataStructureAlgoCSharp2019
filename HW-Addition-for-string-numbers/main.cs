using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print(Add("999", "1") == "1000");
    print(Add("999", "0") == "999");
    print(Add("9", "1") == "10");
    print(Add("123", "12") == "135");
    print(Add("123", "10000") == "10123");
    print(Add("0", "0") == "0");
    print(Add("190000000000000000000008", 
              "990000000000000000009999") 
          == "1180000000000000000010007");
  }

  public static string Add(string s1, string s2) {
    if (s2.Length > s1.Length) {
      string temp = s2;
      s2 = s1;
      s1 = temp;
    }

    string result = "";
    int carry = 0;
    int remainder = 0;
    for(int i = s1.Length-1, j = s2.Length-1 ; i >= 0; i--, j--) {
      int sum = int.Parse(s1[i].ToString()) + (j >= 0 ? int.Parse(s2[j].ToString()) : 0) + carry;
      carry = sum >= 10 ? 1 : 0;
      remainder = sum >= 10 ? sum-10 : sum;
      result = remainder.ToString() + result;
    }
    result = (carry == 1 ? "1" : "") + result;
    
    return result;
  }
}