// Tree definition & Term: https://jiwondh.github.io/2017/10/15/tree/


using System;
using System.Collections.Generic;

class TreeNode {
  public string Name { get; set; }
  public List<TreeNode>   children;
  public TreeNode(string name) {
    Name = name;
    children = new List<TreeNode>();
  }
  public void AddChild(TreeNode node) {
    children.Add(node);
  }
}

class Tree {
  public TreeNode Root { get; set; }

  public string IterativeDFS(TreeNode node, Action<string> callback) {
    string s = string.Empty;
    Stack<TreeNode> stack = new Stack<TreeNode>();
    stack.Push(node);

    while(stack.Count > 0) {
      TreeNode n = stack.Pop();
      s += n.Name + " ";
      callback(n.Name);

      for (int i = n.children.Count-1; i >= 0;  i--)
        stack.Push( n.children[i] );
    }
    return s;
  }

  public string RecursiveDFS(TreeNode node, Action<string> callback) {
    string s = node.Name + " ";
    foreach(var n in node.children)
      s += RecursiveDFS(n, callback);
    return s;
  }

  public string IterativeBFS(TreeNode node, Action<string> callback) {
    string s = string.Empty;
    Queue<TreeNode> q = new Queue<TreeNode>();
    q.Enqueue(node);
    
    while(q.Count > 0) {
      TreeNode n = q.Dequeue();
      s += n.Name + " ";
      callback(n.Name);

      foreach(var c in n.children)
        q.Enqueue(c);
    }
    return s;
  }
}

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Tree tree = new Tree();
    TreeNode root = new TreeNode("root");
    TreeNode a = new TreeNode("a");
    TreeNode b = new TreeNode("b");
    TreeNode c = new TreeNode("c");
    TreeNode d = new TreeNode("d");
    TreeNode e = new TreeNode("e");
    TreeNode f = new TreeNode("f");
    TreeNode g = new TreeNode("g");
    TreeNode h = new TreeNode("h");
    TreeNode i = new TreeNode("i");
    tree.Root = root;
//             root
//           /   |   \
//         a     b    c
//       /  \   / \
//      d    e f   g 
//                / \
//               h   i
    root.AddChild(a); root.AddChild(b); root.AddChild(c);
    a.AddChild(d); a.AddChild(e);
    b.AddChild(f); b.AddChild(g);
    g.AddChild(h); g.AddChild(i);

    print(tree.IterativeDFS(d, s => {} ) == "d ");
    print(tree.IterativeDFS(a, s => {} ) == "a d e ");
    print(tree.IterativeDFS(root, print ) == "root a d e b f g h i c ");
    
    print(tree.RecursiveDFS(d, s => {} ) == "d ");
    print(tree.RecursiveDFS(a, s => {} ) == "a d e ");
    print(tree.RecursiveDFS(root, print ) == "root a d e b f g h i c "); 
    print(tree.IterativeBFS(root, s => {} ) == "root a b c d e f g h i "); 

  }
}