using System;

class Calc {
  public float Divide(int x, int y) {
    float z = 0;
    int[] arr = new int[10];
    try {
      z = x / y;
      // int b = arr[100];
      return z;
    } catch(Exception e) {
      Console.WriteLine(e.Message);
    } finally {
      Console.WriteLine("Finally");
    }
    
    return 0;
  }
}

class MainClass {
  public static void Main (string[] args) {
    Calc c = new Calc();
    Console.WriteLine(c.Divide(10, 1) == 10);
    // c.Divide(10, 0);
  }
}




// using System;

// class Calc {
//   public float Divide(int x, int y) {
//     float z = 0;
//     try {
//       z = x / y;
//       return z;
//     } catch(Exception e) {
//       Console.WriteLine("Divide(): " + e.Message);
//       throw e;
//     } finally {
//       Console.WriteLine("Finally");
//     }
//   }
// }

// class MainClass {
//   public static void Main (string[] args) {
//     Calc c = new Calc();

//     try {
//       Console.WriteLine(c.Divide(10, 1) == 10);
//       c.Divide(10, 0);
//     } catch(Exception e) {
//       Console.WriteLine("Main(): " + e.Message);
//     }
//   }
// }