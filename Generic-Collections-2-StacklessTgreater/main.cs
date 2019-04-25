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

    Stack<StudentScore> s = new Stack<StudentScore>();
    s.Push(new StudentScore { Name="JJ", Subject="English", Score=100 });
    s.Push(new StudentScore { Name="Won", Subject="Korean", Score=90 });
    s.Push(new StudentScore { Name="Steve", Subject="Math", Score=70 });
    print(s.Stringify() == "Steve Won JJ");   // top 부터
    print(s.Peek().ToString() == "Steve");
    print(s.Pop().ToString() == "Steve");
    print(s.Count == 2);
    
    StudentScore[] scores = s.ToArray();
    print(scores.Length == 2);
    print(scores.Stringify() == "Won JJ");

    Stack<StudentScore> s2 = new Stack<StudentScore>(scores);
    print(s2.Stringify() == "JJ Won");
  }
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

