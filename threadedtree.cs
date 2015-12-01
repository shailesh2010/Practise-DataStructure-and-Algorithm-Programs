using System;
class Node
{
	public int data;
	public Node left;
	public Node right;
	public bool rightThread;
	public Node(int i, bool b,Node n)
	{
		data=i;
		left=null;
		right=n;
		rightThread=b;
	}
}

class Program
{
	static Node leftMost(Node n)
	{
		if(n==null)return null;
		Node current=n;
		while(current.left!=null)
			current=current.left;
		return current;
	}

	static void inorder(Node n)
	{
		if(n==null)return;
		Node current=leftMost(n);
		while(current!=null)
		{
			Console.WriteLine(current.data);
			if(current.rightThread)
			{
				current=current.right;
			}
			else
			{
				current=leftMost(current.right);
			}
		}
	}

	static int treeSize(Node n)
	{
		if(n==null) return 0;
		return treeSize(n.left) + 1+ treeSize(n.right);
	}

	static void Main()
	{
		Node root=new Node(6,false,null);
		root.left=new Node(3,true,root);
		root.right=new Node(8,false,null);
		root.left.left=new Node(1,true,root.left);
		root.right.left=new Node(7,true,root.right);
		root.right.right=new Node(11,false,null);
		root.right.right.left=new Node(9,true,root.right.right);
		//inorder(root);
		Console.WriteLine(treeSize(root));
	}
}