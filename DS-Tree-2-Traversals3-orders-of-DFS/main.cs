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

  public override string ToString() {
    return Name;
  }

  public TreeNode LeftChild() {
    if (children.Count >= 1)
      return children[0];
    return null;
  }
  public TreeNode RightChild() {
    if (children.Count >= 2)
      return children[1];
    return null;
  }  
}

class Tree {
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

  public string Inorder(TreeNode node, Action<TreeNode> callback) {
    string s = "";
    if (node.LeftChild() != null)
      s += Inorder(node.LeftChild(), callback);
    
    s += node + " ";
    callback(node);
    
    if (node.RightChild() != null)
      s += Inorder(node.RightChild(), callback);

    return s;
  }

  public string Preorder(TreeNode node, Action<TreeNode> callback) {
    string s = "";
    s += node + " ";
    callback(node);
    
    if (node.LeftChild() != null)
      s += Preorder(node.LeftChild(), callback);
    if (node.RightChild() != null)
      s += Preorder(node.RightChild(), callback);
    
    return s;
  }

  public string Postorder(TreeNode node, Action<TreeNode> callback) {
    string s = "";
    if (node.LeftChild() != null)
      s += Postorder(node.LeftChild(), callback);
    if (node.RightChild() != null)
      s += Postorder(node.RightChild(), callback);
    
    s += node + " ";
    callback(node);

    return s;
  }    
}

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

//           a
//          /  \
//         b    c
//       /  \  
//      d    e  

    Tree binaryTree = new Tree();
    TreeNode root = new TreeNode("a");
    TreeNode b = new TreeNode("b");
    TreeNode c = new TreeNode("c");
    TreeNode d = new TreeNode("d");
    TreeNode e = new TreeNode("e");
    binaryTree.Root = root;

    root.AddChild(b); root.AddChild(c);
    b.AddChild(d); b.AddChild(e);

    print(binaryTree.Inorder(root, print) == "d b e a c ");
    print("\n");

    print(binaryTree.Preorder(root, print) == "a b d e c ");
    print(binaryTree.Preorder(root, n=>{}) == binaryTree.IterativeDFS(root, n=>{}));    
    print("\n");
    
    print( binaryTree.Postorder(root, print) == "d e b c a ");
  }
}