// Swap
// 1. double형 Swap(double a, double b)를 작성하세요.
// 2. int[]형 Swap(int[] arrayA, int[] arrayB)를 deep copy 하게 작성하세요. 배열 사이즈가 서로 다른 경우 호출자에게 알려주세요.
// 3. Book(멤버가 Title, Price)형 Swap(Book a, Book b)를 작성하세요.
// 4. 하나의 int[]를 주어졌을 때 min, max 값을 서로 swap 시키는 SwapMinMax(int[] array)를 작성하세요.



































































using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    double a = 10.0, b = 20.0;
    Swap(ref a, ref b);
    print( a == 20.0 && b == 10.0 );
    
    int[] arrayA = { 1, 2, 3, 4, 5 };
    int[] arrayB = { 10, 20, 30, 40, 50 };
    print( Swap(arrayA, arrayB) == true );
    print( Stringify(arrayA) == "10 20 30 40 50" );
    print( Stringify(arrayB) == "1 2 3 4 5" );
    
    int[] arrayC = { 1, 2, 3, 4};           // Notice! array length
    int[] arrayD = { 10, 20, 30, 40, 50 };
    print( Swap(arrayC, arrayD) == false );
    print( Stringify(arrayC) == "1 2 3 4" );
    print( Stringify(arrayD) == "10 20 30 40 50" );

    int[] arrayE = { };
    int[] arrayF = { };
    print( Swap(arrayE, arrayF) == false );
    
    Book bookA = new Book() { Title="Onepiece", Price=7000 };
    Book bookB = new Book() { Title="Airgear", Price=5000 };
    Swap(bookA, bookB);
    print( bookA.Title == "Airgear" && bookB.Title == "Onepiece" );
    
    int[] arrayG = { 7, 2, 100, 4, 1 };
    SwapMinMax(arrayG);
    print( Stringify(arrayG) == "7 2 1 4 100" );

    int[] arrayH = { 1, 2, 3, 4, 5 };
    SwapMinMax(arrayH);
    print( Stringify(arrayH) == "5 2 3 4 1" );    
  }

  public static string Stringify(int[] list) { 
      string s = String.Empty;
      for(int i = 0;i < list.Length; i++)
        s += i != list.Length-1 ? list[i].ToString() + " " : list[i].ToString();
      return s;
      // or return String.Join(" ", list);
  }

  public static void Swap(ref double a, ref double b) {
    double temp = a;
    a = b;
    b = temp;
  }
  public static void Swap(ref int a, ref int b) {
    int temp = a;
    a = b;
    b = temp;
  }  
  
  public static bool Swap(int[] a, int[] b) {
    if (a.Length == b.Length && a.Length > 0) {
      for( int i=0; i < a.Length; i++) {
        Swap(ref a[i], ref b[i]);
      }
      return true;
    } else 
      return false;
  }
  
  public static void Swap(Book a, Book b) {
    string tempTitle = a.Title;
    a.Title = b.Title;
    b.Title = tempTitle;
    
    int tempPrice = a.Price;
    a.Price = b.Price;
    b.Price = tempPrice;
  }
  
  public static void SwapMinMax(int[] array) {
    if (array.Length == 0 )
      return;

    int minIndex = 0;
    int maxIndex = 0;

    for (int i = 1; i < array.Length; i++) {
      if (array[i] > array[maxIndex])
        maxIndex = i;
      if (array[i] < array[minIndex])
        minIndex = i;
    }
    Swap(ref array[minIndex], ref array[maxIndex]);
    // int temp = array[minIndex];
    // array[minIndex] = array[maxIndex];
    // array[maxIndex] = temp;
  }

  public class Book {
    public string Title { get; set; }
    public int Price { get; set; }
  }
}



// using System;
// using System.Collections.Generic;

// class MainClass {
//   public static void Main (string[] args) {
//     Action<object> print = Console.WriteLine;

//     double a = 10.0, b = 20.0;
//     Swap(ref a, ref b);
//     print( a == 20.0 && b == 10.0 );
    
//     int[] arrayA = { 1, 2, 3, 4, 5 };
//     int[] arrayB = { 10, 20, 30, 40, 50 };
//     print( Swap(arrayA, arrayB) == true );
//     print( arrayA.Stringify() == "10 20 30 40 50" );
//     print( arrayB.Stringify() == "1 2 3 4 5" );
    
//     int[] arrayC = { 1, 2, 3, 4};           // Notice! array length
//     int[] arrayD = { 10, 20, 30, 40, 50 };
//     print( Swap(arrayC, arrayD) == false );
//     print( arrayC.Stringify() == "1 2 3 4" );
//     print( arrayD.Stringify() == "10 20 30 40 50" );
    
//     Book bookA = new Book() { Title = "Onepiece", Price=7000 };
//     Book bookB = new Book() { Title = "Airgear", Price=5000 };
//     Swap(bookA, bookB);
//     print( bookA.Title == "Airgear" && bookB.Title == "Onepiece" );
    
//     int[] arrayE = { 7, 2, 100, 4, 1 };
//     SwapMinMax(arrayE);
//     print( arrayE.Stringify() == "7 2 1 4 100" );
//   }

//   public static string Stringify(int[] list) { 
//       string s = String.Empty;
//       for(int i = 0;i < list.Length; i++)
//         s += i != list.Length-1 ? list[i] + " " : list[i].ToString();
//       return s;
//   }

//   public static void Swap(ref double a, ref double b) {
//     double temp = a;
//     a = b;
//     b = temp;
//   }
  
//   public static bool Swap(int[] a, int[] b) {
//     if (a.Length == b.Length && a.Length > 0) {
//       for( int i=0; i < a.Length; i++) {
//         int temp = a[i];
//         a[i] = b[i];
//         b[i] = temp;
//       }
//       return true;
//     } else 
//       return false;
//   }
  
//   public static void Swap(Book a, Book b) {
//     string tempTitle = a.Title;
//     a.Title = b.Title;
//     b.Title = tempTitle;
    
//     int tempPrice = a.Price;
//     a.Price = b.Price;
//     b.Price = tempPrice;
//   }
  
//   public static void SwapMinMax(int[] array) {
//     int minIndex = 0;
//     int maxIndex = 0;

//     for (int i = 1; i < array.Length; i++) {
//       if (array[i] > array[maxIndex])
//         maxIndex = i;
//       if (array[i] < array[minIndex])
//         minIndex = i;
//     }
//     int temp = array[minIndex];
//     array[minIndex] = array[maxIndex];
//     array[maxIndex] = temp;
//   }

//   public class Book {
//     public string Title { get; set; }
//     public int Price { get; set; }
//   }
// }

// public static class Exclass {
//   public static string Stringify<T>(this IEnumerable<T> list) { 
//       return string.Join(" ", list);
//   }
// }
