using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    string[] names = new string[] { "c", "b", "a", "d" };
    
    print(names.GetType().ToString() == "System.String[]");
    print(names.GetType().BaseType.ToString() == "System.Array");
    
    print(Stringify(new string[] {"a"}) == "a");
    print(Stringify(new string[] {}) == string.Empty);
    print(Stringify(names) == "c b a d");

    // Sorting: 오름차순(Ascending order)
    print("\tSorting");
    Array.Sort( names );
    Array.Sort( names, (x, y) => x.CompareTo(y) );
    print(Stringify(names) == "a b c d");    
    print('a'.CompareTo('b') < 0);  // x-y = 97-98 < 0
    print('b'.CompareTo('a') > 0);  // x-y = 98-97 > 0
    print('a'.CompareTo('a') == 0); // x-y = 97-97 = 0
    // f(x, y) = x.CompareTo(y) = x-y  : if x and y are numbers
    Array.Sort(names, (x,y) => char.Parse(x)-char.Parse(y));
    print(Stringify(names) == "a b c d");
    Array.Sort(names, (x,y) => char.Parse(y)-char.Parse(x));
    print(Stringify(names) == "d c b a");

    // Sorting: 내림차순(Descending order)
    Array.Sort( names, (x, y) => y.CompareTo(x) );
    print(Stringify(names) == "d c b a");
    // Array.Sort( names, (x, y) => y - x ); // x < y:음수, x == y:0, x > y:양수
    // print(Stringify(names) == "8 7 6 5 4 3 2 1");
    
    //Sorting
    // https://support.microsoft.com/ko-kr/help/320727/how-to-use-the-icomparable-and-icomparer-interfaces-in-visual-c
    // http://www.csharp-examples.net/sort-array/
    
    User[] users = new User[3] {  new User("Betty", 23),  // name, age
                                  new User("Susan", 20),
                                  new User("Lisa", 25) };    
    Array.Sort( users, (user1, user2) => user1.Age.CompareTo(user2.Age) ); // or (user1.Age - user2.Age)
    foreach (User user in users) 
      Console.Write(user.Name + user.Age + " ");
    Console.WriteLine();

    Array.Sort( users, (user1, user2) => user1.Name.CompareTo(user2.Name) );
    foreach (User user in users) 
      Console.Write(user.Name + user.Age + " ");
    Console.WriteLine();    
  }
  
  class User {
    public string Name { get; set; }
    public int Age { get; set; }
    public User(string name, int age) {
      Name = name; Age = age;
    }
  }
  
  public static string Stringify(string[] list) { 
      string s = String.Empty;
      for(int i = 0;i < list.Length; i++)
        s += i != list.Length-1 ? list[i] + " " : list[i];
      return s;
  }
}