// Thread states in C#
// http://www.albahari.com/threading/part2.aspx


using System;
using System.Threading;
// using System.Threading.Tasks;


class MainClass {
  public static void Todo() {
    for (int i=0; i < 5; i++) {
      Thread.Sleep(500);  
      
      Console.WriteLine("in Todo(): " + Thread.CurrentThread.ManagedThreadId);
    }
  }
  
  public static void Main (string[] args) {
    
    //public delegate void ThreadStart()
    // ThreadStart: delegate

    // 1:
    Thread t = new Thread(Todo);
    
    // 2:
    // Thread t = new Thread(() => {
    //   for (int i=0; i < 5; i++) {
    //     Thread.Sleep(500);  
        
    //     Console.WriteLine("in Todo(): " + Thread.CurrentThread.ManagedThreadId);
    //   }
    // });

    // 3:
    // ThreadStart ts = new ThreadStart(Todo);
    // Thread t = new Thread(ts);

    Console.WriteLine("befor running, Thread state: " + t.ThreadState);
    Thread.Sleep(500);
    t.Start();
    Console.WriteLine("after running, Thread state: " + t.ThreadState);
    
    t.Join();   // t가 종료되기까지 대기한다.
    Console.WriteLine("after join, Thread state: " + t.ThreadState);

    // t.Join() 없다면 Main() 종료 이후 다른 thread가 종료될 때까지 대기 상태가 된다.
    // Your Main() method is called by the .NET framework, and when the method returns, there is additional code executed by the framework before the main thread (and hence the process) exits. Specifically, one of the things the framework does as part of the post-Main code is wait for all foreground threads to exit.
  }
}




// Task version

// using System;
// using System.Threading;
// using System.Threading.Tasks;


// class MainClass {
//   public static void Main (string[] args) {
//     Task task = Task.Run( () => {
//       for (int i=0; i < 5; i++) {
//         Thread.Sleep(500);  
//         Console.WriteLine("in Todo(): " + Thread.CurrentThread.ManagedThreadId);
//       }
//     } );
    
//     Console.WriteLine("in Main: " + Thread.CurrentThread.ManagedThreadId);
    
//     task.Wait();
    
//     Console.WriteLine("after Waiting");
//   }
// }