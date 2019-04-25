using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Book b = new Book();
    b.SetTitle("LOR");
    print(b.GetTitle() == "LOR");

    Book2 b2 = new Book2();
    b2.Title = "Hobbit";
    print(b2.Title == "Hobbit");
    b2.Title = "";
    print(b2.Title == "None");

    Book3 b3 = new Book3();
    b3.Title = "Bible";
    print(b3.Title == "Bible");

    Book4 b4 = new Book4 { // object initializer
      Title = "TLOR", 
      Price = 30000 
    };
    print(b4.Price == 30000);
  }

  class Book4 {
    public string Title { get; set; }
    public int Price { get; set; }
    
  }

  class Book3 {
    public string Title { get; set; }
    // public string Title { get; private set; }
  }

  class Book2 {
    string title;
    public string Title {
      get {
        return title;
      }
      set {
        Console.WriteLine("setter");
        if (value == "")
          title = "None";
        else 
          title = value;
      }
    }
  }  

  class Book {
    string title;
    public string GetTitle() { return title; }
    public void SetTitle(string title) { 
      this.title = title; 
    }
  }


}