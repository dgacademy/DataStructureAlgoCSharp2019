// 평균이 80 이상 && 최저 점수 60 이상인 학생 추출




using System;
using System.Collections.Generic;
using System.Linq;

public class Student {                      // must "public"
  public string Name { get; set; }
  public int Height { get; set; }
  public List<int> Scores { get; set; }
  
  public override string ToString() { return Name; }
}

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    List<Student> students = new List<Student> {
      new Student() { Name="ctkim", Height=175, Scores = new List<int>() { 100, 70, 90, 77, 88 } },
      new Student() { Name="Steve", Height=167, Scores = new List<int>() { 77, 60, 90, 77, 55 } },
      new Student() { Name="Brown", Height=180, Scores = new List<int>() { 30, 61, 91, 100, 57 } },
      new Student() { Name="Won",   Height=171, Scores = new List<int>() { 100, 100, 59, 100, 100 } },
      new Student() { Name="JJ",    Height=165, Scores = new List<int>() { 10, 100, 9, 100, 100 } }
    };

    var r1 = students.FindAll(student => student.Scores.Average() > 80);
    print(r1.Stringify() == "ctkim Won");
    
    var r2 = students.FindAll(student => student.Scores.Average() > 80 && student.Scores.TrueForAll(score => score > 60));
    print(r2.Stringify() == "ctkim");    
    
    var r3 = students
      .Where( student => student.Scores.Average() > 80 && student.Scores.Min() > 60)
      .Select( student => student );
    print(r3.Stringify() == "ctkim");
    
    var r4 = from student in students
             where student.Scores.Average() > 80 && student.Scores.Min() > 60
             select student;
    print(r4.Stringify() == "ctkim");         

    // Compound From: just a nested foreach
    var r5 = 
      from s in students
      from point in s.Scores
        where point < 50
        select s.Name;
    print(r5.Stringify() == "Brown JJ JJ");
  }
}


public static class Exclass {
  public static string Stringify<T>(this IEnumerable<T> list) { 
    return string.Join(" ", list);
  }  
}
