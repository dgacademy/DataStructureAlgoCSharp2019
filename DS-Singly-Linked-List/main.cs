// https://en.wikipedia.org/wiki/Linked_list

using System;

class Node {
  public string data;
  public Node next;
}

class LinkedList {
  Node head, tail;

  public int Count { 
    get {
      Node current = head;
      int count = 0;
      while(current != null) {
        current = current.next;
        count++;
      }
      return count;      
    }
  }

  public LinkedList() {
    head = tail = null;
  }

  public void AddLast(string obj) {
    Node newNode = new Node();
    newNode.data = obj;
    newNode.next = null;
    if (head == null) {
      head = tail = newNode;
    }
    else {
      tail.next = newNode;
      tail = newNode;
    }
  }
  public string RemoveFirst() {
    if (head == null)
      return string.Empty;
    else {
      string v = head.data;
      head = head.next;
      return v;
    }
  }

  public string Stringfy() {
    Node current = head;
    string s = string.Empty;
    while(current != null) {
      s += current.data;
      current = current.next;
    }
    return s;
  }
}

class MainClass {
  public static void Main (string[] args) {
    LinkedList list  = new LinkedList();
    list.AddLast("one");
    Console.WriteLine(list.Stringfy() == "one");
    list.AddLast("two");
    Console.WriteLine(list.Stringfy() == "onetwo");
    list.AddLast("three");
    Console.WriteLine(list.Stringfy() == "onetwothree");
    Console.WriteLine(list.Count == 3);

    Console.WriteLine(list.RemoveFirst() == "one");
    Console.WriteLine(list.Stringfy() == "twothree");
    list.RemoveFirst();
    list.RemoveFirst();
    Console.WriteLine(list.Stringfy() == string.Empty);
    Console.WriteLine(list.Count == 0);
  }
}

// Doubly Linked list
// AddLast(), AddFirst(), RemoveFirst(), RemoveLast(), ReverseStringify()
