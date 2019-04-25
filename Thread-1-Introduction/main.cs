// https://magi82.github.io/process-thread/

// Thread Programming
// Process: 실행 파일이 실행이 되어 메모리에 적재된 인스턴스를 의미, ex) notepad.exe의 객체
//  실행 중인 프로그램
// Thread: LWP, Light Weight Process, Process 내에서 실행 중인 흐름의 단위
// 즉 Process는 하나 이상의 Thread로 구성된다. Main thread 외 다수
// 지금까지는 하나의 process에 하나의 thread(Main thread)만 가지도록 작성했다.
// 하나의 thread만으로 할 수 있는 일은 한정적이다. 큰 파일을 복사나 다운로드의 경우는 다른 thread 필요하다. UX 의미에서 불편하다.
// 동시에 여러 thread를 이용해서 프로그래밍을 하면  Multi-thread programming 이라 한다.
// 장점: 반응성, 자원 공유, 경제성(light)
// 단점: Debugging



using System;
using System.Threading;
using System.Threading.Tasks;


class MainClass {
  public static void Main (string[] args) {
    
    Console.WriteLine("Thread Id:" + Thread.CurrentThread.ManagedThreadId );

  }
}


