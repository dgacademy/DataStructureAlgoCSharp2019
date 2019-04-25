// grouping
// https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/concepts/linq/walkthrough-writing-queries-linq


using System;
using System.Collections.Generic;
using System.Linq;

public class Student {
  public int Id { get; set; }
  public string Name { get; set; }
  public int Height { get; set; }
  
  public override string ToString() { return Name; }
}

public class Score {
  public int StudentId { get; set; }
  public string Name { get; set; }
  public string Subject { get; set; }
  public int Point { get; set; }  
}

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    List<Student> list = new List<Student> {
      new Student() { Id=0, Name="ctkim", Height=175 },
      new Student() { Id=1, Name="Steve", Height=167 },
      new Student() { Id=2, Name="Brown", Height=180 },
      new Student() { Id=3, Name="Won",   Height=171 },
      new Student() { Id=4, Name="JJ",    Height=165 }
    };
    
    List<Score> scores = new List<Score> {
      new Score() { StudentId=0, /* Name="ctkim", */ Subject="Math", Point=70 },
      new Score() { StudentId=4, /* Name="JJ",    */ Subject="Math", Point=60 },
      new Score() { StudentId=3, /* Name="Won",   */ Subject="Math", Point=90 },
      new Score() { StudentId=2, /* Name="Brown", */ Subject="Math", Point=10 },
      new Score() { StudentId=1, /* Name="Steve", */ Subject="Math", Point=30 },
      new Score() { StudentId=0, /* Name="ctkim", */ Subject="English", Point=70 },
      new Score() { StudentId=4, /* Name="JJ",    */ Subject="English", Point=60 },
      new Score() { StudentId=3, /* Name="Won",   */ Subject="English", Point=90 },
      new Score() { StudentId=2, /* Name="Brown", */ Subject="English", Point=10 },
      new Score() { StudentId=1, /* Name="Steve", */ Subject="English", Point=30 }
    };
    print( list.Stringify() == "ctkim Steve Brown Won JJ" );

    var ss1 = from s in list
              join score in scores on s.Id equals score.StudentId
              select new { Name=s.Name, Subject=score.Subject, Point=score.Point };
    // print(ss1);
    print( ss1.Stringify() );   // anonymous object는 ToString()을 만들어 줌
    print( ss1.Count() == 10 );
    print( ss1.Average( s => s.Point) == 52 );

    var ss2 =
      from score in scores
      group score by score.Subject;

    // subjectGroup is an IGrouping<string, Customer>
    // (key, list<Score>)
    foreach (var subjectGroup in ss2) {
      print(subjectGroup.Key);
      foreach (Score score in subjectGroup) {
          print($"    {score.Point}");
      }
    }        

  }
}


public static class Exclass {
  public static string Stringify<T>(this IEnumerable<T> list) { 
    return string.Join(" ", list);
  }  
}
