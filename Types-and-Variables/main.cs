// https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables


using System;

class MainClass {
  enum Animal { MOUSE=-100, CAT, BIRD, DOG=10, LION };

  public static void Main (string[] args) {
    // Value types
    //  signed integral: sbyte(1), short(2), int(4), long(8)
    //  unsigned integral: byte, ushort, uint, ulong
    //  unicode characters: char(2)
    //  floating point: float(4), double(8)
    //  high-precision decimal: decimal(16)
    //  boolean: bool(1)
    //  enum E {...}
    //  struct S {...} - no heap allocation
    //  null

    Console.WriteLine("\t\tValue types: ");
    int intA;
    intA = 100;
    Console.WriteLine(intA == 100);
    Console.WriteLine(sizeof(int) == 4);
    byte byteA;
    byteA = 100;
    Console.WriteLine(byteA == 100);
    Console.WriteLine(sizeof(byte) == 1);
    char charA = 'A';    
    Console.WriteLine(charA == 'A' && charA == 65);
    Console.WriteLine(sizeof(char) == 2);
    float floatA = 0.1f;
    Console.WriteLine(floatA == 0.1f);
    Console.WriteLine(floatA != 0.1);
    double doubleA = 0.1;
    Console.WriteLine(doubleA == 0.1);
    Console.WriteLine(0.1f != 0.1);
    Console.WriteLine((double)0.1f != 0.1);
    var someA = 0.1;
    Console.WriteLine(someA.GetType().ToString() == "System.Double");   // Double precision
    Console.WriteLine(floatA.GetType().ToString() == "System.Single");  // Single precision
    Console.WriteLine(intA.GetType().ToString() == "System.Int32");
    Console.WriteLine(byteA.GetType().ToString() == "System.Byte");
    sbyte sbyteA = 100;
    Console.WriteLine(sbyteA.GetType().ToString() == "System.SByte");
    decimal decimalA = 1000000000000000000000.123m;
    Console.WriteLine(decimalA.GetType().ToString() == "System.Decimal");
    Console.WriteLine(decimalA == 1000000000000000000000.123m);
    bool boolA = true;
    Console.WriteLine(boolA == true);
    Console.WriteLine(boolA != false);
    Console.WriteLine(sizeof(bool) == 1);

    // enum Animal { MOUSE=-100, CAT, BIRD, DOG=10, LION };
    Animal enumA = Animal.DOG;
    Console.WriteLine(enumA);
    Console.WriteLine(enumA == Animal.DOG);
    Console.WriteLine((int)enumA == 10);
    Console.WriteLine((int)Animal.CAT == -99);
    Console.WriteLine((int)Animal.LION == 11);
    Console.WriteLine(enumA.GetType().ToString() == "MainClass+Animal");
    Console.WriteLine(sizeof(Animal) == 4);
    Console.WriteLine(enumA.GetType().IsValueType == true);
 
    // Reference types
    // object
    // string
    // class C {...}
    // interface I {...}
    // int[] and int[,]
    // delegate int D(...)

    Console.WriteLine("\t\tReference types: ");
    // https://docs.microsoft.com/ko-kr/dotnet/api/system.object?view=netframework-4.7.2
    object obj1 = 10;       // boxing
    object obj2 = 10;
    int int3 = (int)obj1;    // unboxing
    Console.WriteLine(int3 == 10);

    Console.WriteLine(obj1.GetType().IsValueType == true);
    Console.WriteLine((obj1 == obj2) == false);    // compare just references
    Console.WriteLine(Object.ReferenceEquals(obj1, obj2) == false);
    Console.WriteLine(Object.Equals(obj1, obj2) == true);

    string str1 = "Game";
    string str2 = "Game";
    string str3 = "Academy";
    // https://docs.microsoft.com/en-us/dotnet/api/system.string.op_equality?view=netframework-4.7.2
    Console.WriteLine(str1 == str2);
    Console.WriteLine(str1 + str3 == "GameAcademy");
    Console.WriteLine(str1.GetType().IsValueType == false);
    object objStr = "Daegu";
    Console.WriteLine(objStr.GetType().IsValueType == false);

    Point pointA = new Point(10, 20);
    Point pointB = new Point(30, 40);
    Console.WriteLine(pointA != pointB);
    Point pointC;
    pointC = pointA;
    Console.WriteLine(pointA == pointC);
    Console.WriteLine(pointA.GetType().IsValueType == false);    
    Console.WriteLine(Object.Equals(pointA, pointC) == true);   // The Equals() is not called! Why? the same object.
    Console.WriteLine(Object.Equals(pointA, pointB) == false);
    Point pointD = new Point(10, 20);
    Console.WriteLine(Object.Equals(pointA, pointD) == true);
    Console.WriteLine(pointA.Equals(pointD) == true);         // Same as above

    int[] arrayA = new int[2] { 1, 2 };
    int[] arrayB = new int[2] { 1, 2 };
    Console.WriteLine(arrayA != arrayB);
    Console.WriteLine(arrayA.GetType().IsValueType == false);
    Console.WriteLine(Object.Equals(arrayA, arrayB) == false);
    Console.WriteLine(Object.ReferenceEquals(arrayA, arrayB) == false);

    Console.WriteLine("\t\tConstant: ");
    const int mapSizeX = 100;
    // mapSizeX = 100;    // Syntax error!

  }

  class Point {
    public int x, y;

    public Point(int x, int y) {
      this.x = x;
      this.y = y;
    }

    public override bool Equals(object obj) 
    {
      Console.WriteLine("In Equals()");
      // If this and obj do not refer to the same type, then they are not equal.
      if (obj.GetType() != this.GetType()) return false;

      // Return true if  x and y fields match.
      Point other = (Point) obj;
      return (this.x == other.x) && (this.y == other.y);
    }
    public override int GetHashCode() 
    {
      return x ^ y;
    } 
  }
}