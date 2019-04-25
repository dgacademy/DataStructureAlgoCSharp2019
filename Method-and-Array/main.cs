using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Console.WriteLine(Plus(10, 10) == 20);

    // Array 1D
    int[] scores = new int[] { 2, 4, 5, 3, 6, 8, 1, 7};

    print(Sum(scores) == 36);
    print(Avg(scores)== 4.5);
    print(Max(scores) == 8);
    print(Min(scores) == 1);

    // Array 2D
    int [,] list2d = {
      {10, 20},
      {30, 40},
      {50, 60}
    };
    print(list2d[2,0] == 50);

    // Array 3D
    int [,,] list3d = {
      {
        {10, 20},
        {30, 40},
        {50, 60}
      },
      {
        {70, 80},
        {90, 100},
        {110, 120}        
      }
    };
    
    int sum = 0;
    for (int i = 0; i < list3d.GetLength(0); i++) {
      for (int j = 0; j < list3d.GetLength(1); j++) {
        for (int k = 0; k < list3d.GetLength(2); k++)
          sum += list3d[i,j,k];
      }      
    }
    print(sum == 10+20+30+40+50+60+70+80+90+100+110+120); // 780

    // Jagged Array(aka 가변배열)
    int[][] image = new int[][] {
      new int[] {0, 0, 0, 0, 0, 0, 0},
      new int[] {0, 0, 1, 1, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 0, 1, 0, 0},
      new int[] {0, 0, 1, 1, 1, 0, 0},
      new int[] {0, 0, 0, 0, 0, 0, 0}
    };
    print(image[1][2] == 1);
  }

  public static int Plus(int a, int b) {
    return a+b;
  }

  public int Add(int a, int b) {
    return a+b;
  }

  public static int Sum(int[] list) {
    int s = 0;
    foreach(int n in list) {
      s += n;
    }
    return s;
  }

  public static double Avg(int[] list) {
    return Sum(list) / (double)list.Length;
  }

  public static int Min(int[] list) {
    int min = list[0];
    for (int i=1; i < list.Length; i++)
      if (list[i] < min)
        min = list[i];
    return min;
  }
  
  public static int Max(int[] list) {
    int max = list[0];
    for (int i=1; i < list.Length; i++)
      if (list[i] > max)
        max = list[i];
    return max;
  }  

}