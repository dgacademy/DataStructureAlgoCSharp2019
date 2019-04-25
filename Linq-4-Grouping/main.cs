// Linq query overview https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations

// Linq Grouping
// https://docs.microsoft.com/ko-kr/dotnet/csharp/linq/group-query-results

using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;
    
    List<Customer> customers = new List<Customer> {
      new Customer() { Name="ctkim", Height=175, City="New York" },
      new Customer() { Name="Steve", Height=167, City="Seoul" },
      new Customer() { Name="Brown", Height=180, City="Hanoi" },
      new Customer() { Name="Won",   Height=171, City="London" },
      new Customer() { Name="JJ",    Height=165, City="New York" }
    };

    // queryCustomersByCity is an IEnumerable<IGrouping<string, Customer>>
    var queryCustomersByCity =
      from cust in customers
      group cust by cust.City;

    // customerGroup is an IGrouping<string, Customer>
    // (key, list<Customers>)
    foreach (var customerGroup in queryCustomersByCity) {
      print(customerGroup.Key);
      foreach (Customer customer in customerGroup) {
          print($"    {customer.Name}");
      }
    }
    print("\n");

    var custQuery =
      from cust in customers
      group cust by cust.City into custGroup
      where custGroup.Count() >= 2
      orderby custGroup.Key
      select custGroup;
    foreach (var q in custQuery) {
      print(q.Key);
      foreach (Customer customer in q) {
          print($"    {customer.Name}");
      }
    }    
  }
}

public class Customer {
  public string Name { get; set; }
  public int Height { get; set; }
  public string City { get; set; }
  
  public override string ToString() { return Name; }
}

public static class Exclass {
  public static string Stringify<T>(this IEnumerable<T> list) { 
    return string.Join(" ", list);
  }  
}