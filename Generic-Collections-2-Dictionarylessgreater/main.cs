using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Dictionary<string, string> ht = new Dictionary<string, string>();
    ht.Add("txt", "nodepad.exe");
    ht.Add("bmp", "paint.exe");
    ht.Add("dib", "paint.exe");
    // ht.Add("rtf", "wordpad.exe");
    ht["rtf"] = "wordpad.exe";
    Console.WriteLine (ht.Count == 4);

    // or foreach( KeyValuePair<string, string> kvp in ht)
    foreach( var kvp in ht)
      Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);

    try {
      ht.Add("txt", "winword.exe");
    } catch(Exception e) {
      Console.WriteLine("already exists: " + e.Message);
    }
    ht.Remove("bmp");
    Console.WriteLine(ht.ContainsKey("bmp") == false);

  }
}