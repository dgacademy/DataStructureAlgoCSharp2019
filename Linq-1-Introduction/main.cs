// https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries
// https://msdn.microsoft.com/library/6sh2ey19.aspx

// LINQ: Language INtegrated Query
// 일종의 쿼리 표현식
// Query: 다양한 형태의 Data Source로부터 일관된 방식으로 데이터를 추출하는 표현식
// Data Source: DB, ADO.NET Data sets, .NET Collections
// IEnumerable<T> type은 모두 Linq 적용이 가능하다! == Queryable type
// Three parts: Data source, Query creation, Query execution

// Deferred excuction: foreach, ToArray(), Count() ... 호출 시에 실제로 실행된다.
// 컴파일러가 알아서 함수형식으로 변경 시킴
// IEnumerable Extension Method로 정의 되어 있음
// using System.Linq 네임스페이스를 가짐
// class extension으로 구현되었다.


using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    // 1. Data source
    int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    
    // 2. Query creation
    // Linq: Query syntex
    IEnumerable<int> evens =
      from n in numbers           // data source
      where n % 2 == 0            // filtering
      select n;                   // result type
    
    // 3. Query execution: Deferred execution
    foreach (int n in evens)
      print(n);

    // type of query variable 
    print(evens);   // System.Linq.Enumerable+WhereArrayIterator`1[System.Int32]

    print( evens.ToArray().Stringify() == "2 4 6 8 10" );
    print( evens.ToList().Stringify() == "2 4 6 8 10" );
    print(evens.Stringify() == "2 4 6 8 10");
    
    // Linq: Method syntex
    IEnumerable<int> evens2 = 
      numbers.Where(n => n%2 == 0).Select(n => n);        // List<T> 확인하기
    print(evens2.Stringify() == "2 4 6 8 10");
    print(evens2);

    IEnumerable<string> areas =
      from n in numbers
      where n <= 2
      select $"Area = {n * n * Math.PI:F2}";
    print(areas.Stringify());
    print(areas);


    List<Student> students = new List<Student> {
      new Student() { Name="ctkim", Height=175, Scores = new List<int>() { 100, 70, 90, 77, 88 } },
      new Student() { Name="Steve", Height=167, Scores = new List<int>() { 77, 60, 90, 77, 55 } },
      new Student() { Name="Brown", Height=180, Scores = new List<int>() { 30, 61, 91, 100, 57 } },
      new Student() { Name="Won",   Height=171, Scores = new List<int>() { 100, 100, 91, 100, 100 } },
      new Student() { Name="JJ",    Height=165, Scores = new List<int>() { 10, 100, 9, 100, 100 } }
    };

    print( students.Stringify() == "ctkim Steve Brown Won JJ" );

    // Height가 175 미만인 학생들 구하기
    // List 함수 이용
    List<Student> ss1 = students.FindAll( student => student.Height < 175 );
    print(ss1.Stringify() == "Steve Won JJ");
    
    
    // Linq 이용
    var ss2 = from student in students                    // students: must be IEnumerable<T> type
              where student.Height < 175                  // 조건
              select student;                             // ss2 type: IEnumerable<Student>
    print(ss2.Stringify() == "Steve Won JJ");
    
    var ss3 = from student in students
              where student.Height < 175
              orderby student.Height              // 오름차순 정렬: or orderby student.Height ascending
              select student;
    print(ss3.Stringify() == "JJ Steve Won");


    var ss4 = from student in students                        // var or IEnumerable<Student> 
              where student.Height < 175
              orderby student.Height descending           // 내림차순 정렬
              select student;                             // ss4 type: IEnumerable<Student>
    print(ss4.Stringify() == "Won Steve JJ");

    
    IEnumerable<string> ss5 = from student in students
              where student.Height < 175
              orderby student.Height descending           // 내림차순 정렬
              select student.Name;                        // ss5 type: IEnumerable<string>
    print(ss5.Stringify() == "Won Steve JJ");

    var ss6 = from student in students
              where student.Height < 175
              orderby student.Height
              select new { Name=student.Name, InchHeight=student.Height * 0.393 };
    foreach(var s in ss6)
      print(s.Name + " " + s.InchHeight);
      
    var ss6_ = students
      .Where( student => student.Height < 175 )
      .OrderBy( student => student.Height )
      .Select( student => new { Name=student.Name, InchHeight=student.Height*0.393 });
    foreach(var s in ss6_)
      Console.WriteLine(s.Name + " " + s.InchHeight);   

    print("\n");    
    
    // 익명 객체 생성
    var ct = new {Name="ctkim", Height=170};
    print(ct.Name);
    print(ct.GetType().ToString());

    // Compound From: just a nested foreach
    // https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/from-clause
    // 60점 미만 점수를 가진 사람의 (이름, 미만점수) 리스트
    var ss7 = from student in students
              from score in student.Scores
              where score < 60
              orderby score
              select new { student.Name, Lowest = score };
    foreach(var s in ss7)
      print(s.Name + " " + s.Lowest);
      
    // let
    var ss8 =
      from student in students
      let totalScore = student.Scores[0] + student.Scores[1] +
        student.Scores[2] + student.Scores[3] + student.Scores[4]
      select totalScore;
    print(ss8.Stringify() == "425 359 339 491 319");

    double averageScore = ss8.Average();
    print($"Class average score = {averageScore}");    


    // Compound From: just a nested foreach
    // https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/from-clause
    var ss9 = 
      from s in students
      from point in s.Scores
        where point < 50
        where point >= 0    // point < 50 && point >= 0
        select s.Name;
    print(ss9.Stringify() == "Brown JJ JJ");      
  }
}

public class Student {                      // must "public"
  public string Name { get; set; }
  public int Height { get; set; }
  public List<int> Scores { get; set; }
  
  public override string ToString() { return Name; }
}

public static class Exclass {
  public static string Stringify<T>(this IEnumerable<T> list) { 
    return string.Join(" ", list);
  }  
}
