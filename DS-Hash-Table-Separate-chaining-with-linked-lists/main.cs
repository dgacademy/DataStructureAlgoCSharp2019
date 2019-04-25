using System;

class MainClass {
  public static void Main (string[] args) {
    HashTable ht = new HashTable(10);   // 1: Singly linked list, 2>: Tree
    ht.Add("John Smith", "521-1234");
    Console.WriteLine(ht.Stringify() == "John Smith/");
    ht.Add("Lisa Smith", "521-8976");
    ht.Add("Sam Doe",    "521-5030");
    ht.Add("Sandra Dee", "521-9655");
    ht.Add("Ted Baker",  "418-4165");
    Console.WriteLine(ht.Stringify() == "John Smith/Lisa Smith/Sandra Dee/Sam Doe/Ted Baker/");
    Console.WriteLine(ht.Count == 5);

    Console.WriteLine(ht.Add("Sam Doe", "521-5030") == false);
    Console.WriteLine((string)ht["Lisa Smith"] == "521-8976");
    Console.WriteLine((string)ht["Sandra Dee"] == "521-9655");
    Console.WriteLine(ht["ctkim"] == null);
    ht["ctkim"] = "5358";
    Console.WriteLine(ht.Stringify() == "John Smith/Lisa Smith/Sandra Dee/ctkim/Sam Doe/Ted Baker/");
    Console.WriteLine(ht.Count == 6);
    
    Console.WriteLine(ht.ContainsKey("ctkim") == true);
    Console.WriteLine(ht.ContainsKey("something") == false);

    Console.WriteLine(ht.Remove("ctkim") == true);
    Console.WriteLine(ht.Remove("something") == false);
    Console.WriteLine(ht.Count == 5);

    Console.WriteLine(ht.Remove("Lisa Smith") == true);
    Console.WriteLine(ht.Stringify() == "John Smith/Sandra Dee/Sam Doe/Ted Baker/");
    Console.WriteLine(ht.Count == 4);

    Console.WriteLine(ht.Remove("John Smith") == true);
    Console.WriteLine(ht.Stringify() == "Sandra Dee/Sam Doe/Ted Baker/");
    Console.WriteLine(ht.Count == 3);    

    Console.WriteLine(ht.Remove("Sandra Dee") == true);
    Console.WriteLine(ht.Remove("Sam Doe") == true);
    Console.WriteLine(ht.Remove("Ted Baker") == true);
    Console.WriteLine(ht.Count == 0);

    Console.WriteLine(ht.HashFuncInJava("John Smith"));
  }
}

public class HashTable {
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
  public object this[string key]
  {
    get {
      int index = HashFunc(key) % buckets.Length;
      if (buckets[index] != null) {
        Node current = buckets[index];
        while(current != null) {
          if (current.key == key) {
            return current.value;
          }
          current = current.next;
        }
      }
      return null;
    }

    set { 
      Add(key, value); 
    }
  }

  public HashTable(int size) {
    buckets = new Node[size];
  }

  public int HashFunc(string key) {
    return key.Length;    // poor hash function :)

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

  public bool Add(string key, object value){
    int index = HashFunc(key) % buckets.Length;
    if (buckets[index] == null) {
      buckets[index] = new Node(key, value);
      return true;
    } else {
      Console.WriteLine("Collision!");
      Node current = buckets[index];
      while(current != null) {
        if (current.key == key) {
          Console.WriteLine("already exist!");
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

  public bool Remove(string key) {
    int index = HashFunc(key) % buckets.Length;
    if (buckets[index] != null) {
      Node current = buckets[index];
      Node prev = null;
      while(true) {
        if (current.key == key) {
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

  public bool ContainsKey(string key) {
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
          s += current.key + "/";
          current = current.next;
        }
      }
    }
    return s;
  }

  private class Node {
    public string key;
    public object value;
    public Node next;

    public Node(string key, object value) {
      this.key = key;
      this.value = value;
      this.next = null;
    }
  }

}

