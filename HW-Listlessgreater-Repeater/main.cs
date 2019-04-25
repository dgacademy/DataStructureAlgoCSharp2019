using System;
using System.Collections.Generic;
using System.Linq;

// 숙제
// public class Student {
//   public string Name { get; set; }
//   public List<int> Scores { get; set; }
// }
// 점수 중에 60점 미만이 하나라도 있으면 낙제생 리스트(이름) 넣기
// 낙제생이 아닌 사람들 리스트(이름) 구하기
// Console.WriteLine(nonRepeaters.Stringify() == "ctkim Won");
// Console.WriteLine(repeaters.Stringify() == "Steve Brown");


class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    List<Student> list = new List<Student> {
      new Student() { Name="ctkim", Scores = new List<int>() { 100, 70, 90, 77, 88 } },
      new Student() { Name="Steve", Scores = new List<int>() { 77, 60, 90, 77, 55 } },
      new Student() { Name="Brown", Scores = new List<int>() { 30, 61, 91, 100, 57 } },
      new Student() { Name="Won",   Scores = new List<int>() { 100, 100, 91, 100, 100 } },
      new Student() { Name="JJ",    Scores = new List<int>() { 10, 100, 91, 100, 100 } }
    };

    print( list.Stringify() == "ctkim Steve Brown Won JJ" );

    List<Student> nonRepeaters = 
      list.FindAll(student => student.Scores.TrueForAll(score => score >= 60));
    print(nonRepeaters.Stringify() == "ctkim Won");

    List<Student> repeaters = 
      list.FindAll(student => !student.Scores.TrueForAll(score => score >= 60));
    print(repeaters.Stringify() == "Steve Brown JJ");
    print("\n");




















    

    List<StudentScore> scores = new List<StudentScore> {
      new StudentScore() { Name="ctkim", Subject="English", Score=100 },
      new StudentScore() { Name="ctkim", Subject="Science", Score=90 },
      new StudentScore() { Name="ctkim", Subject="Korean", Score=97 },
      new StudentScore() { Name="ctkim", Subject="Math", Score=89 },
      new StudentScore() { Name="Steve", Subject="English", Score=10 },
      new StudentScore() { Name="Steve", Subject="Science", Score=20 },
      new StudentScore() { Name="Steve", Subject="Korean", Score=90 },
      new StudentScore() { Name="Steve", Subject="Math", Score=40 },
      new StudentScore() { Name="Won", Subject="English", Score=70 },
      new StudentScore() { Name="Won", Subject="Science", Score=80 },
      new StudentScore() { Name="Won", Subject="Korean", Score=90 },
      new StudentScore() { Name="Won", Subject="Math", Score=70 },
      new StudentScore() { Name="JJ", Subject="English", Score=60 },
      new StudentScore() { Name="JJ", Subject="Science", Score=70 },
      new StudentScore() { Name="JJ", Subject="Korean", Score=50 },
      new StudentScore() { Name="JJ", Subject="Math", Score=30 }
    };
    
    // https://docs.microsoft.com/ko-kr/dotnet/csharp/linq/group-query-results
    var nr = from score in scores
             where score.Score < 60
             group score by score.Name;
    List<string> nrlist = new List<string>();
    foreach (var g in nr) {
      nrlist.Add(g.Key);
    }
    print(nrlist.Stringify() == "Steve JJ");
  }
}

public class Student {                      // must "public"
  public string Name { get; set; }
  public List<int> Scores { get; set; }
  
  public override string ToString() { return Name; }
}

public class StudentScore {
  public string Name { get; set; }
  public string Subject { get; set; }
  public int Score { get; set; }
  
  public override string ToString() { return Name; }
}


public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}

