// interface: abstract base class가 유사 
// 대표적인 예: IEnumerable<T>

using System;
using System.Collections.Generic;

interface IEquatable {
  bool Equals(Car obj);     // public + abstract
}

interface IStringifable {
  string Stringify();
}

interface ICloneable : IEquatable, IStringifable {
  Car Clone();
}

class Car : ICloneable {  //or class Car : IEquatable, IStringifable, ICloneable {
  public string Make { get; set; }
  public string Model { get; set; }
  public string Year { get; set; }

  public bool Equals(Car car) {
    if (Make == car.Make && Model == car.Model && Year == car.Year)
      return true;
    else
      return false;
  }

  public string Stringify() {
    return Make + ", " + Model + ", " + Year;
  }

  public Car Clone() {
    Car car = new Car();
    car.Make = Make;
    car.Model = Model;
    car.Year = Year;
    return car;
  }
}

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Car car = new Car();
    car.Make = "BMW";
    car.Model = "Mini";
    car.Year = "2018";

    Car car2 = new Car();
    car2.Make = "BMW";
    car2.Model = "Mini";
    car2.Year = "2018";    

    print(car.Equals(car2) == true);
    print(car.Stringify() == "BMW, Mini, 2018");
    Car clone = car.Clone();
    print(clone.Equals(car) == true);
    clone.Make = "Tesla";
    print(car.Make == "BMW");
    print(clone.Make == "Tesla");

    print(car is int == false);
    print(car is Cake == false);
    print(car is Car == true);
    print(car is IEquatable == true);
    print(car is ICloneable == true);
    print(car is object == true);

    ICloneable ic = car as ICloneable;
    print(ic != null);
    print(ic.GetType().Name == "Car");

    IStringifable istr = new Car();
    print(istr.Equals(car2) == false);
  }

  class Cake {
  }

}


public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}