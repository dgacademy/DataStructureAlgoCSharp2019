using System;

class MainClass {
  class Book {
    public string title;
    public string genre;

    public Book() {
      Console.WriteLine("Book ctor");
    }

    public virtual void Print() {
      Console.WriteLine("Title: " + title);
      Console.WriteLine("Genre: " + genre);
    }
  }

  class Novel : Book {
    public string writer;

    public Novel() {
      Console.WriteLine("Novel ctor");
    }

    public override void Print() {
      base.Print();
      Console.WriteLine("Writer: " + writer);
    }
  }

  class Magazine : Book {
    public int releaseDay;

    public Magazine() {
      Console.WriteLine("Magazine ctor");
    }

    public override void Print() {
      base.Print();
      Console.WriteLine("ReleaseDay: " + releaseDay);
    }    
  }

  public static void Main (string[] args) {
    // Action<object> print = Console.WriteLine;

    Novel nov = new Novel();
    nov.title = "The Hobbit"; nov.genre = "Fantasy";
    nov.writer = "J.R.R. Tolkein";
    nov.Print();
    Console.WriteLine();

    Magazine mag = new Magazine();
    mag.title = "Hello Computer Magazine"; mag.genre = "Computer";
    mag.releaseDay = 1;
    mag.Print();

    Book b = new Book();
    // mag = b;  // Error!
  }
}