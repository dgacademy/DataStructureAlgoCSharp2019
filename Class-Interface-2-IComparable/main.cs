// interface: abstract base class가 유사 
// 대표적인 예: IEnumerable<T>

using System;
using System.Collections.Generic;

class Car : IComparable {
  public string Make { get; set; }
  public string Model { get; set; }
  public string Year { get; set; }

  public int CompareTo(object obj) {
    // return this.Year.CompareTo((obj as Car).Year);
    return (obj as Car).Year.CompareTo(this.Year);
  }

  public override string ToString() {
    return Make+Year;
  }
}

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Car car = new Car();
    car.Make = "Volvo";
    car.Model = "V";
    car.Year = "2008";

    Car car2 = new Car();
    car2.Make = "Tesla";
    car2.Model = "S";
    car2.Year = "2019";        

    Car car3 = new Car();
    car3.Make = "BMW";
    car3.Model = "Mini";
    car3.Year = "2012";

    IComparable[] cars = {car, car2, car3};
    Array.Sort(cars);
    // print(cars.Stringify() == "Volvo2008 BMW2012 Tesla2019");
    print(cars.Stringify() == "Tesla2019 BMW2012 Volvo2008");
  }
}


public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}