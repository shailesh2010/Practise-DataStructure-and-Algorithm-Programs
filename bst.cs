using System;

class Node
{
	public int data;
	public Node left;
	public Node right;
	public Node(int data)
	{
		this.data=data;
		left=null;
		right=null;
	}
}

class BinarySearchTree
{
	public Node root;
	public BinarySearchTree(int i)
	{
		root=new Node(i);
	}

	public Node Insert(Node n,int i)
	{
		if(n==null)return new Node(i);
		if(i<=n.data)
		{
			n.left=Insert(n.left,i);
		}
		else if(i>n.data)
		{
			n.right=Insert(n.right,i);
		}
		return n;
	}

	public void InOrder(Node root)
	{
		if(root==null)return;
		InOrder(root.left);
		Console.WriteLine(root.data);
		InOrder(root.right);
	}

	public bool Search(Node n,int i)
	{
		if(n==null)return false;
		if(i<n.data) Search(n.left,i);
		else if(i>n.data) Search(n.right,i);
		else if(i==n.data) return true;
	}

}


class Program
{
	

	static void Main()
	{
		BinarySearchTree b=new BinarySearchTree(30);
		//Node root=new Node(50);
		b.Insert(b.root,70);
		b.Insert(b.root,20);
		b.Insert(b.root,40);
		b.Insert(b.root,60);
		//b.InOrder(b.root);
		if(b.Search(b.root,5))
		{
			Console.WriteLine("found");
		} 
		else
		{
			Console.WriteLine("not found");
		}
	}
}