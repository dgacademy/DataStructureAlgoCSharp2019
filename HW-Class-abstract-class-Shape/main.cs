// property 도 overriding 가능

using System;
using System.Collections.Generic;

public class TestClass
{
  public static void Main()
  {
    Shape[] shapes = {
      new Square(5, "Square #1"),
      new Circle(3, "Circle #1"),
      new Rectangle( 4, 5, "Rectangle #1")
    };

    double[] areas = new double[shapes.Length];
    for (int i = 0; i < shapes.Length; i++) {
      System.Console.WriteLine(shapes[i]);
      areas[i] = shapes[i].Area;
    }
    Console.WriteLine(areas.Stringify() == "25 28.2743338823081 20");
  }
}


public abstract class Shape
{
  private string name;

  public Shape(string s) {
    // calling the set accessor of the Id property.
    Id = s;
  }

  public string Id {
    get {
      return name;
    }
    set {
      name = value;
    }
  }

  // Area is a read-only property - only a get accessor is needed:
  public abstract double Area { get; }

  public override string ToString()
  {
    return $"{Id} Area = {Area:F2}";
  }
}

public class Square : Shape
{
  private int side;

  public Square(int side, string id) : base(id) {
    this.side = side;
  }

  public override double Area {
    get {
      // Given the side, return the area of a square:
      return side * side;
    }
  }
}

public class Circle : Shape
{
  private int radius;

  public Circle(int radius, string id) : base(id) {
    this.radius = radius;
  }

  public override double Area {
    get {
      // Given the radius, return the area of a circle:
      return radius * radius * Math.PI;   // double PI = 3.14159265358979;
    }
  }
}

public class Rectangle : Shape
{
  private int width;
  private int height;

  public Rectangle(int width, int height, string id) : base(id) {
    this.width = width;
    this.height = height;
  }

  public override double Area {
    get {
      // Given the width and height, return the area of a rectangle:
      return width * height;
    }
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}