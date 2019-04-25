using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    List<Student> students = new List<Student> {
      new Student() { Id=0, Name="ctkim", Height=175 },
      new Student() { Id=1, Name="Steve", Height=167 },
      new Student() { Id=2, Name="Brown", Height=180 },
      new Student() { Id=3, Name="Won",   Height=171 },
      new Student() { Id=4, Name="JJ",    Height=165 }  
    };

    List<Score> scores = new List<Score> {
      new Score() { StudentId=0, /* Name="ctkim", */ Subject="Math", Point=80 },
      new Score() { StudentId=1, /* Name="Steve", */ Subject="Math", Point=30 },
      new Score() { StudentId=2, /* Name="Brown", */ Subject="Math", Point=50 },
      new Score() { StudentId=3, /* Name="Won",   */ Subject="Math", Point=90 },
      new Score() { StudentId=4, /* Name="JJ",    */ Subject="Math", Point=60 },
      new Score() { StudentId=0, /* Name="ctkim", */ Subject="English", Point=100 },
      new Score() { StudentId=1, /* Name="Steve", */ Subject="English", Point=50 },
      new Score() { StudentId=2, /* Name="Brown", */ Subject="English", Point=90 },
      new Score() { StudentId=3, /* Name="Won",   */ Subject="English", Point=90 },
      new Score() { StudentId=4, /* Name="JJ",    */ Subject="English", Point=60 }      
    };

    // inner join: 한 쪽에 없는 것은 무시
    var ss1 = from s in students
              join score in scores on s.Id equals score.StudentId
              select new { Name=s.Name, Subject=score.Subject, Point=score.Point };
    print( ss1.Stringify() );
    print( ss1.Count() == 10 );
    print( ss1.Average( s=>s.Point) == 70 );

    var ss2 =
      from score in scores
      group score by score.Subject;

    // subjectGroup is an IGrouping<string, Score>
    // (key, list<Score>)
    foreach (var subjectGroup in ss2) {
      print(subjectGroup.Key);
      foreach (Score score in subjectGroup) {
          print($"    {score.Point}");
      }
    }

    // H/W: Get repeaters
    var ss3 = 
      from s in (
        from score in scores
        group score by score.StudentId into studentGroup
        select new {
          Id = studentGroup.Key,
          Name = (from s in students where studentGroup.Key == s.Id select s.Name).First(),
          Avg = (from score2 in studentGroup select score2.Point).Average(),
          Min = (from score2 in studentGroup select score2.Point).Min()
        }
      )
      where s.Avg < 80 || s.Min < 60
      orderby s.Name
      select s.Name;
    print(ss3.Stringify() == "Brown JJ Steve");

    var ss4 = 
      from s in (
        from score in (
          from s in students 
          join sc in scores on s.Id equals sc.StudentId 
          select new {
            StudentId= s.Id,
            Name = s.Name,
            Point = sc.Point
          })
        group score by score.StudentId into studentGroup
        select new {
          Id = studentGroup.Key,
          Name = studentGroup.First().Name,
          Avg = (from score2 in studentGroup select score2.Point).Average(),
          Min = (from score2 in studentGroup select score2.Point).Min()
        }
      )
      where s.Avg < 80 || s.Min < 60
      orderby s.Name
      select s.Name;
    print(ss4.Stringify() == ss3.Stringify());
  }
}

public class Student {
  public int Id { get; set; }
  public string Name { get; set; }
  public int Height { get; set; }
  
  public override string ToString() { return Name; }
}

public class Score {
  public int StudentId { get; set; }
  // public string Name { get; set; }
  public string Subject { get; set; }
  public int Point { get; set; }  
}


public static class Exclass {
  public static string Stringify<T>(this IEnumerable<T> list) { 
    return string.Join(" ", list);
  }  
}