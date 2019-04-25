using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    print(SumRecursive(10) == 55);
    print(SumRecursive(0) == 0);

    // 0 1 2 3 4 5 6 7  8
    // 0 1 1 2 3 5 8 13 21 ...
    print(FiboRecursive(7) == 13);
    print(FiboDynamicProgramming(7) == 13);
    print(FiboIterative(7) == 13);
  }

  public static int SumRecursive(int n) {
    if (n < 2)
      return n;
    return SumRecursive(n-1) + n;
  }

  // O(2^n): Exponential time
  public static int FiboRecursive(int n) {
    if (n < 2)
      return n;
    return FiboRecursive(n-1) + FiboRecursive(n-2);
  }

  // O(n^2): Polynomial time(P)



  // O(n): Linear time
  // DynamicProgramming ~= Recursion + Memoization
  public static int FiboDynamicProgramming(int n) 
  { 
    int[] f = new int[n + 2];  // Memoization!
    int i; 
      
    f[0] = 0; 
    f[1] = 1; 
      
    for (i = 2; i <= n; i++) 
      f[i] = f[i - 1] + f[i - 2];   // f[i-2]: free of charge

    return f[n]; 
  } 


  public static int FiboIterative(int n) {
    if (n < 2)
      return n;
    
    int fibo=0, fibo1=0, fibo2=1;
    for( int i = 2; i <= n; i++) {
      fibo = fibo1 + fibo2;
      fibo1 = fibo2;
      fibo2 = fibo;
    }
    return fibo;
  }
  
  
}