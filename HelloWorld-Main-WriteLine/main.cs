// // https://docs.microsoft.com/ko-kr/dotnet/api/system.console.writeline?view=netframework-4.7.2


using System;

class MainClass {
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");
    Console.WriteLine();
    // Console.WriteLine("\n");

    Console.WriteLine("Hello " + "World");
    string s = "Hello" + " " + "World";
    Console.WriteLine (s);    

    Console.WriteLine("Standard Numeric Format Specifiers");
    Console.WriteLine(
      "(C) Currency: . . . . . . . . {0:C}\n" +
      "(D) Decimal:. . . . . . . . . {0:D}\n" +
      "(E) Scientific: . . . . . . . {1:E}\n" +
      "(F) Fixed point:. . . . . . . {1:F}\n" +
      "(G) General:. . . . . . . . . {0:G}\n" +
      "    (default):. . . . . . . . {0} (default = 'G')\n" +
      "(N) Number: . . . . . . . . . {0:N}\n" +
      "(P) Percent:. . . . . . . . . {1:P}\n" +
      "(R) Round-trip: . . . . . . . {1:R}\n" +
      "(X) Hexadecimal:. . . . . . . {0:X}\n",
      -123, -123.45f); 
    
    string binary = Convert.ToString(5, 2);
    Console.WriteLine(binary == "101");
    string hex = Convert.ToString(15, 16);
    Console.WriteLine(hex == "f");    
  }
}


// https://docs.microsoft.com/ko-kr/dotnet/api/system.console.writeline?view=netframework-4.7.2


// using System;

// class MainClass {
//   int num;

//   public static void Main (string[] args) {
//     MainClass mc = new MainClass();
//     mc.num = 100;
//     Console.WriteLine(mc.num);
//   }
// }


