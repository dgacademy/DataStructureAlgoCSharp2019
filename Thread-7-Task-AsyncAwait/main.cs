// https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/concepts/async/
// 일반 함수를 Async 하게 처리 가능하게 만든 한정자
// Method 나 Task/Task<>를 async로 한정하면 비동기 코드가 만들어진다.


using System;
using System.Threading;
using System.Threading.Tasks;

class MainClass {
  public static async void Chain() {
    int a = await Task<int>.Run( () => {     // Func<string> delegate임
      Thread.Sleep(100);
      Console.WriteLine("1 Task Chain({0})", Thread.CurrentThread.ManagedThreadId);
      return 100;
    });
    
    int b = await Task<int>.Run( () => {
      Console.WriteLine();
      Thread.Sleep(200);
      Console.WriteLine("2 Task Chain({0})", Thread.CurrentThread.ManagedThreadId);
      return 200 + a;
    });
    
    int result = await Task<int>.Run( () => {
      Console.WriteLine();
      Thread.Sleep(100);
      Console.WriteLine("3 Task Chain({0})", Thread.CurrentThread.ManagedThreadId);
      return 300 + b;
    });
    Console.WriteLine(result.ToString());
  }
  
  public static void Main (string[] args) {
    Chain();
    Console.ReadLine();
  }
}