using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    var ht = new HashTable<string, string>(10);   // 1: Singly linked list, 2>: Tree
    ht.Add("John Smith", "521-1234");
    print(ht.Stringify() == "John Smith/");
    ht.Add("Lisa Smith", "521-8976");
    ht.Add("Sam Doe",    "521-5030");
    ht.Add("Sandra Dee", "521-9655");
    ht.Add("Ted Baker",  "418-4165");
    print(ht.Stringify() == "John Smith/Lisa Smith/Sandra Dee/Sam Doe/Ted Baker/");
    print(ht.Count == 5);

    print(ht.Add("Sam Doe", "521-5030") == false);
    print(ht["Lisa Smith"] == "521-8976");
    print(ht["Sandra Dee"] == "521-9655");
    print(ht["ctkim"] == null);
    ht["ctkim"] = "5358";
    print(ht.Stringify() == "John Smith/Lisa Smith/Sandra Dee/ctkim/Sam Doe/Ted Baker/");
    print(ht.Count == 6);
    
    print("\t\tKey");
    print(ht.ContainsKey("ctkim") == true);
    print(ht.ContainsKey("something") == false);

    print(ht.Remove("ctkim") == true);
    print(ht.Remove("something") == false);
    print(ht.Count == 5);

    print(ht.Remove("Lisa Smith") == true);
    print(ht.Stringify() == "John Smith/Sandra Dee/Sam Doe/Ted Baker/");
    print(ht.Count == 4);

    print(ht.Remove("John Smith") == true);
    print(ht.Stringify() == "Sandra Dee/Sam Doe/Ted Baker/");
    print(ht.Count == 3);    

    print(ht.Remove("Sandra Dee") == true);
    print(ht.Remove("Sam Doe") == true);
    print(ht.Remove("Ted Baker") == true);
    print(ht.Count == 0);

    print(ht.HashFuncInJava("John Smith"));

    var ht2 = new HashTable<StudentID, Student>(10);
    ht2.Add(new StudentID(100), new Student("Smith"));
    ht2.Add(new StudentID(101), new Student("Dee"));
    ht2.Add(new StudentID(1002), new Student("Baker"));
    ht2.Add(new StudentID(10), new Student("ctkim"));
    print(ht2.Stringify() == "10/100/101/1002/");
    ht2[new StudentID(103)] = new Student("kim");
    print(ht2.Stringify() == "10/100/101/103/1002/");
    Student student = ht2[new StudentID(1002)];
    print(student.ToString() == "Baker");
  }
  
  class StudentID {
    int id;
    public StudentID(int id) { this.id = id; }
    public override string ToString() { return id.ToString(); }
    public override bool Equals(object other) {
      return this.id == ((StudentID)other).id;
    }
    public override int GetHashCode() {
      return id;
    }
  }
  class Student {
    string name;
    public Student(string name) { this.name = name; }
    public override string ToString() { return name; }
  }  
}

public class HashTable<TKey, TValue> {
  class Node {
    public TKey key;
    public TValue value;
    public Node next;

    public Node(TKey key, TValue value) {
      this.key = key;
      this.value = value;
      this.next = null;
    }
  }

  Node[] buckets;

  public int Count {
    get { 
      int count = 0;
      for (int i = 0; i < buckets.Length; i++) {
        if (buckets[i] != null) {
          Node current = buckets[i];
          while(current != null) {
            count++;
            current = current.next;
          }
        }
      }
      return count;
    }
  }

  // Indexer
  public TValue this[TKey key]
  {
    get {
      int index = HashFunc(key) % buckets.Length;
      if (buckets[index] != null) {
        Node current = buckets[index];
        while(current != null) {
          if (current.key.Equals(key)) {
            return current.value;
          }
          current = current.next;
        }
      }
      return default(TValue);
    }

    set { 
      Add(key, value); 
    }
  }

  public HashTable(int size) {
    buckets = new Node[size];
  }

  public int HashFunc(TKey key) {
    return key.ToString().Length;    // poor hash function :)

    // int hash = 0;
    // for (int i = 0; i < key.Length; i++) 
    //   hash = (31 * hash) + key[i];
    // return Math.Abs(hash);
  }

  public int HashFuncInJava(string key) {
    int hash = 0;
    int skip = Math.Max(1, key.Length / 8);
    for (int i = 0; i < key.Length; i+= skip) 
      hash = key[i] + (37 * hash);
    return hash;
  }

  public bool Add(TKey key, TValue value){
    int index = HashFunc(key) % buckets.Length;
    if (buckets[index] == null) {
      buckets[index] = new Node(key, value);
      return true;
    } else {
      Console.WriteLine("Collision!");
      Node current = buckets[index];
      while(current != null) {
        if (current.key.Equals(key)) {
          Console.WriteLine("already exists!");
          return false;
        }
        if (current.next == null)
          break;
        current = current.next;
      }
      Node newNode = new Node(key, value);
      current.next = newNode;
      return true;
    }
  }

  public bool Remove(TKey key) {
    int index = HashFunc(key) % buckets.Length;
    if (buckets[index] != null) {
      Node current = buckets[index];
      Node prev = null;
      while(true) {
        if (current.key.Equals(key)) {
          if (prev == null) {   // in case of the first node
            buckets[index] = current.next;
          } else {
            prev.next = current.next;
          }
          return true;
        }
        if (current.next == null)
          break;
        prev = current;
        current = current.next;
      }
    }
    return false;
  }

  public bool ContainsKey(TKey key) {
    if (this[key] != null)    
      return true;
    else
      return false;
  }

  public string Stringify() {
    string s = string.Empty;
    for (int i = 0; i < buckets.Length; i++) {
      if (buckets[i] != null) {
        Node current = buckets[i];
        while(current != null) {
          s += current.key.ToString() + "/";
          current = current.next;
        }
      }
    }
    return s;
  }
}

