// https://stackoverflow.com/questions/13049/whats-the-difference-between-struct-and-class-in-net/13275
// 1. heap 영역
// 2. copy

using System;

struct SCake {
  public string name;
  public int price;
}

class Cake {
  public string name;
  public int price;

  
  public Cake Clone() {
    Cake newCake = new Cake();
    newCake.name = name;
    newCake.price = price;
    return newCake;
  }
}

class MainClass {
  public static void Main (string[] args) {
    SCake cake = new SCake();
    cake.name = "Blueberry";
    cake.price = 30000;
    
    SCake b = cake;
    Console.WriteLine(b.name == "Blueberry");
    Console.WriteLine(b.price == 30000);
    
    b.price = 10000;
    Console.WriteLine(b.price == 10000);
    Console.WriteLine(cake.price == 30000);   // copy 되었음
    
    Cake cake2 = new Cake();
    cake2.name = "Blueberry";
    cake2.price = 30000;    

    Cake newCake;
    newCake = cake2;
    newCake.name = "Santa";
    Console.WriteLine(cake2.name == "Santa");
    
    Cake newCake2 = newCake.Clone();
    newCake2.price = 7;
    Console.WriteLine(newCake.price == 30000);
    
    string str = "ctkim";
    string str2 = str;

    // https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/string
    Console.WriteLine(str == str2);   // compare contents
    Console.WriteLine((object)str == (object)str2);

    str = "OK";
    Console.WriteLine(str == "OK");
    Console.WriteLine(str2 == "ctkim");
    Console.WriteLine((object)str != (object)str2);

    
  }
}