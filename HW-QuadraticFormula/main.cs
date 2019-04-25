using System;

class MainClass {
  public static void Main (string[] args) {    
    double D;
    double[] roots;

    QuadraticFormula(1, 2, 1, out D, out roots);
    Console.WriteLine(D == 0);
    Console.WriteLine(1 * roots[0] * roots[0] + 2 * roots[0] + 1 == 0);
    
    QuadraticFormula(1, 4, -21, out D, out roots);
    Console.WriteLine(D > 0);
    Console.WriteLine(1 * roots[0] * roots[0] + 4 * roots[0] + -21 == 0);
    Console.WriteLine(1 * roots[1] * roots[1] + 4 * roots[1] + -21 == 0);

    QuadraticFormula(1, 1, 1, out D, out roots);
    Console.WriteLine(D < 0);
    Console.WriteLine(roots == null);
  }

  public static void QuadraticFormula(double a, double b, double c, out double D, out double[] roots) {
    D = b * b - 4 * a * c;
    if (D == 0) {
        roots = new double[1];
        roots[0] = (-b + Math.Sqrt(D)) / (2*a);
        Console.WriteLine("1: " + roots[0]);
    } else {
      if (D > 0) {
        roots = new double[2];
        roots[0] = (-b + Math.Sqrt(D)) / (2*a);
        roots[1] = (-b - Math.Sqrt(D)) / (2*a);
        Console.WriteLine("2: " + roots[0] + ", " + roots[1]);
      } else {
        roots = null;   // notice!
        Console.WriteLine("None");
      }
    }    
  }
}