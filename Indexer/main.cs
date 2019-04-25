using System;

class Student {
  int[] scores = new int[4];
  public int this[int i] {
    get { return scores[i]; }
    set { scores[i] = value; }
  }
}


class MainClass {
  public static void Main (string[] args) {
    Student s = new Student();
    s[0] = 1;
    s[1] = 2;
    s[2] = 3;
    s[3] = 4;
    for (int i=0; i<4; i++)
      Console.WriteLine(s[i]);
  }
}