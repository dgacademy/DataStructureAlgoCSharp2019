using System;
using static System.Math;
using static System.Console;    // only static member
using Project = Outer.B.Car;    // using alising

namespace Outer {
  namespace A {
    class Car {
      public string name = "Car in namespace A";
    }
  }

  namespace B {
    class Car {
      public string name = "Car in namespace B";
    }
  }  
}


class MainClass {
  public static void Main (string[] args) {
    Outer.A.Car a = new Outer.A.Car();
    WriteLine(a.name == "Car in namespace A");

    Project b = new Outer.B.Car();    // alising
    WriteLine(b.name == "Car in namespace B");

    WriteLine(PI);      // Math.PI
  }
}