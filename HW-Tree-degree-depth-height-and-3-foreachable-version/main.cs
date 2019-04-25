// Tree definition & Term: https://jiwondh.github.io/2017/10/15/tree/

// H/W
// Node depth, Tree degree, Tree height
// Tree, foreachable

using System;
using System.Collections;
using System.Collections.Generic;

class TreeNode {
  public string Name { get; set; }
  public List<TreeNode>   children;
  public TreeNode parent;
  
  public TreeNode(string name) {
    Name = name;
    children = new List<TreeNode>();
    parent = null;
  }
  public void AddChild(TreeNode c) {
    children.Add(c);
    c.parent = this;
  }

  public int Degree {
    get {
      return children.Count;
    }
  }

  public bool isLeaf {
    get {
      return Degree == 0;
    }
  }
  public override string ToString() {
    return Name;
  }
}

class Tree : IEnumerable {
  public TreeNode Root { get; set; }

  public string IterativeDFS(TreeNode node, Action<TreeNode> callback) {
    string s = string.Empty;
    Stack<TreeNode> stack = new Stack<TreeNode>();
    stack.Push(node);

    while(stack.Count > 0) {
      TreeNode n = stack.Pop();
      s += n.Name + " ";
      callback(n);

      for (int i = n.children.Count-1; i >= 0;  i--)
        stack.Push( n.children[i] );
    }
    return s;
  }

  public string RecursiveDFS(TreeNode node, Action<TreeNode> callback) {
    string s = node.Name + " ";
    foreach(var n in node.children)
      s += RecursiveDFS(n, callback);
    return s;
  }

  public string IterativeBFS(TreeNode node, Action<TreeNode> callback) {
    string s = string.Empty;
    Queue<TreeNode> q = new Queue<TreeNode>();
    q.Enqueue(node);
    
    while(q.Count > 0) {
      TreeNode n = q.Dequeue();
      s += n.Name + " ";
      callback(n);

      foreach(var c in n.children)
        q.Enqueue(c);
    }
    return s;
  }

  public int DepthOfNode(TreeNode node) {
    int count = 0;
    TreeNode current = node;
    while (current.parent != null) {
      count++;
      current = current.parent;
    }
    return count;
  }

  public int Degree {
    get {
      int maxDegree = 0;
      IterativeBFS(Root, node => { 
        if (node.Degree > maxDegree)
          maxDegree = node.Degree;
      });
      return maxDegree;
    }
  }

  public int Height {    // O(n*logn)
    get {
      int maxDepth = 0;
      IterativeBFS(Root, node => { 
        if (node.isLeaf) {
          int d = DepthOfNode(node);
          if (d > maxDepth)
            maxDepth = d;
        }
      });
      return maxDepth;
    }
  }

  // public int HeightFast { // O(n)
  //   get {
  //     int maxDepth = 0;
  //     IterativeBFS(Root, node => { 
  //       if (node.depth > maxDepth)
  //         maxDepth = node.depth;
  //     });
  //     return maxDepth;
  //   }
  // }

  public int HeightFast { // O(n)
    get {
      int maxDepth = 0;
      Stack<TreeNode> stack = new Stack<TreeNode>();
      stack.Push(Root);
      while(stack.Count > 0) {
        if (stack.Count > maxDepth)
          maxDepth = stack.Count-1;
        TreeNode n = stack.Pop();
        for (int i = n.children.Count-1; i >= 0; i--)
          stack.Push( n.children[i] );
      }
      return maxDepth;
    }
  }    

  public IEnumerator GetEnumerator() {
    // Three foreachable methods:
    // 1: using List<> Enumerator
    // var list = new List<TreeNode>();
    // IterativeDFS( Root, node=>list.Add(node) );  // or IterativeBFS( Root, node=>list.Add(node) );
    // return list.GetEnumerator();
    
    // 2: using manual Enumerator
    return new TreeNodeEnumerator(this);
  }
    // 3: using yield return
  public IEnumerable<TreeNode> EnumDFS(TreeNode node) { // Notice: not IEnumerator<>, but IEnumer**able**<>
    var stack = new Stack<TreeNode>();
    stack.Push(node);
    while(stack.Count > 0) {
      TreeNode n = stack.Pop();
      yield return n;
      for (int i = n.children.Count-1; i >= 0;  i--)
        stack.Push( n.children[i] );
    }
  }

  class TreeNodeEnumerator : IEnumerator {
    Tree tree;
    List<TreeNode> list;
    int position = -1;
    
    public TreeNodeEnumerator(Tree _tree) {
      tree = _tree;
      list = new List<TreeNode>();
      tree.IterativeDFS( tree.Root, node=>list.Add(node) ); // or tree.IterativeBFS( tree.Root, node=>list.Add(node) );
    }

    public bool MoveNext() {
      if (position < list.Count-1) {
        position++;
        return true;
      } else {
        return false;
      }
    }

    public object Current {
      get {
        return list[position];
      }
    }

    public void Reset() {
      position = -1;
    }
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

    print("\t\tH/W");
    print(tree.DepthOfNode(root) == 0);
    print(tree.DepthOfNode(h) == 3);

    print(root.Degree == 3);
    print(tree.Degree == 3);

    print(tree.Height == 3);
    print(tree.HeightFast == 3);

    string str = "";
    foreach(var n in tree) {
      str += n + " ";
    }
    print( str == "root a d e b f g h i c " );

    str = "";
    foreach(var n in tree.EnumDFS(tree.Root))
      str += n + " ";
    print( str == "root a d e b f g h i c " );
  }
}