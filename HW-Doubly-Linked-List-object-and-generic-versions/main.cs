// Double linked list
// 1. 기존의 linked list를 double linked list로 변경하세요.
// 2. 관련 함수 모두 수정하세요: AddLast(), AddFirst(), RemoveFirst()
// 3. RemoveLast() 추가로 구현하세요! 제거된 값을 돌려줘야 합니다.
// 4. 기존의 Count 속성을 제거하세요. 노드를 모두 순회해서 갯수를 알아내는 Count() 만드세요.

// foreachable

using System;
using System.Collections;
using System.Collections.Generic;

class LinkedList<T> : IEnumerable where T: IEquatable<T> {
  public class Node {
    public T data;
    public Node next;
    public Node prev;

    public override string ToString() {
      return data.ToString();
    }
  }

  Node head;
  Node tail;
  
  List<Node> list;

  public LinkedList() {
    head = tail = null;
  }
  public void AddLast(T obj) {
    Node newNode = new Node();
    newNode.data = obj;
    
    if (head == null) {
      head = tail = newNode;
      newNode.prev = newNode.next = null;
    } else {
      tail.next = newNode;
      newNode.prev = tail;
      tail = newNode;
    }
  }
  
  public void AddFirst(T obj) {
    Node newNode = new Node();
    newNode.data = obj;

    if (head == null) {
      head = tail = newNode;
      newNode.prev = newNode.next = null;
    } else {
      head.prev = newNode;
      newNode.next = head;
      head = newNode;
    }
  }
  
  public T RemoveFirst() {
    if (head == null)
      return default(T);
    else {
      T v = head.data;
      if (head == tail) {
        head = tail = null; 
      } else {
        head = head.next;
        head.prev = null;        
      }
      return v;
    }
  }
  
  public T RemoveLast() {
    if (tail == null)
      return default(T);
    else {
      T v = tail.data;
      if (head == tail) {
        head = tail = null;
      } else {
        tail = tail.prev;
        tail.next = null;        
      }
      return v;
    }
  }  
  
  public Node Search(T obj) {
    Node current = head;
    while(current != null) {
      if (current.data.Equals(obj))
        return current;
      current = current.next;
    }
    return null;
  }

  public int Count() {
    Node current = head;
    int count = 0;
    while(current != null) {
      current = current.next;
      count++;
    }
    return count;
  }
  
  public string Stringify() {
    Node current = head;
    string s = string.Empty;
    while(current != null) {
      s += current.data.ToString();
      current = current.next;
    }
    return s;
  }
  
  public string ReverseStringify() {
    Node current = tail;
    string s = string.Empty;
    while(current != null) {
      s += current.data.ToString();
      current = current.prev;
    }
    return s;
  }

  public IEnumerator GetEnumerator() {
    list = new List<Node>();
    Node current = head;
    while(current != null) {
      list.Add(current);
      current = current.next;
    }
    return list.GetEnumerator();
  }
}

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    var list = new LinkedList<string>();
    
    print(list.RemoveFirst() == null);
    list.AddLast("one");
    list.AddLast("two");
    print(list.Stringify() == "onetwo");
    list.AddLast("three");
    print(list.Stringify() == "onetwothree");
    print(list.ReverseStringify() == "threetwoone");

    print(list.Search("two").data == "two");
    print(list.Search("something") == null);

    print((string)list.RemoveFirst() == "one");
    print(list.Stringify() == "twothree");

    list.AddFirst("zero");
    print(list.Stringify() == "zerotwothree");
    print(list.Count() == 3);
    
    print((string)list.RemoveLast() == "three");
    print(list.Stringify() == "zerotwo");
    
    list.RemoveFirst();
    list.RemoveFirst();
    print(list.Stringify() == string.Empty);
    
    print(list.RemoveFirst() == null);
    print(list.RemoveLast() == null);
    print(list.Count() == 0);


    var list2 = new LinkedList<Dummy>();
    print(list2.RemoveFirst() == null);
    list2.AddLast( new Dummy(100) );
    list2.AddLast( new Dummy(101) );
    list2.AddLast( new Dummy(102) );
    print(list2.Stringify() == "100101102");

    string str = "";
    foreach (var node in list2) {
      str += node + " ";
    }
    print(str == "100 101 102 ");
    
  }

  
  class Dummy : IEquatable<Dummy> {
    public int Id { get; set; }
    public Dummy(int id) {
      this.Id = id;
    }
    public override string ToString() {
      return Id.ToString();
    }
    public bool Equals(Dummy other) {
      return Id == other.Id;
    }
  }  
}
























































// using System;

// class Node {
//   public object data;
//   public Node next;
//   public Node prev;
// }

// class LinkedList {
//   Node head;
//   Node tail;
  
//   public LinkedList() {
//     head = tail = null;
//   }
//   public void AddLast(object obj) {
//     Node newNode = new Node();
//     newNode.data = obj;
    
//     if (head == null) {
//       head = tail = newNode;
//       newNode.prev = newNode.next = null;
//     } else {
//       tail.next = newNode;
//       newNode.prev = tail;
//       tail = newNode;
//     }
//   }
  
//   public void AddFirst(object obj) {
//     Node newNode = new Node();
//     newNode.data = obj;

//     if (head == null) {
//       head = tail = newNode;
//       newNode.prev = newNode.next = null;
//     } else {
//       head.prev = newNode;
//       newNode.next = head;
//       head = newNode;
//     }
//   }
  
//   public object RemoveFirst() {
//     if (head == null)
//       return null;
//     else {
//       object v = head.data;
//       if (head == tail) {
//         head = tail = null; 
//       } else {
//         head = head.next;
//         head.prev = null;        
//       }
//       return v;
//     }
//   }
  
//   public object RemoveLast() {
//     if (tail == null)
//       return null;
//     else {
//       object v = tail.data;
//       if (head == tail) {
//         head = tail = null;
//       } else {
//         tail = tail.prev;
//         tail.next = null;        
//       }
//       return v;
//     }
//   }  
  
//   public int Count() {
//     Node current = head;
//     int count = 0;
//     while(current != null) {
//       current = current.next;
//       count++;
//     }
//     return count;
//   }
  
//   public string Stringify() {
//     Node current = head;
//     string s = string.Empty;
//     while(current != null) {
//       s += current.data.ToString();
//       current = current.next;
//     }
//     return s;
//   }
  
//   public string ReverseStringify() {
//     Node current = tail;
//     string s = string.Empty;
//     while(current != null) {
//       s += current.data.ToString();
//       current = current.prev;
//     }
//     return s;
//   }
// }

// class MainClass {
//   public static void Main (string[] args) {
//     LinkedList list = new LinkedList();
    
//     Console.WriteLine(list.RemoveFirst() == null);
//     list.AddLast("one");
//     list.AddLast("two");
//     Console.WriteLine(list.Stringify() == "onetwo");
//     list.AddLast("three");
//     Console.WriteLine(list.Stringify() == "onetwothree");
//     Console.WriteLine(list.ReverseStringify() == "threetwoone");

//     Console.WriteLine((string)list.RemoveFirst() == "one");
//     Console.WriteLine(list.Stringify() == "twothree");

//     list.AddFirst("zero");
//     Console.WriteLine(list.Stringify() == "zerotwothree");
//     Console.WriteLine(list.Count() == 3);
    
//     Console.WriteLine((string)list.RemoveLast() == "three");
//     Console.WriteLine(list.Stringify() == "zerotwo");
    
//     list.RemoveFirst();
//     list.RemoveFirst();
//     Console.WriteLine(list.Stringify() == string.Empty);
    
//     Console.WriteLine(list.RemoveFirst() == null);
//     Console.WriteLine(list.RemoveLast() == null);
//     Console.WriteLine(list.Count() == 0);
    
//   }
// }
