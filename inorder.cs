using System;
using System.Collections.Generic;

class Node
{
	public int data;
	public Node left;
	public Node right;
	public Node(int i)
	{
		data=i;
		left=null;
		right=null;
	}
}

class Program
{
	static void recursiveInorder(Node n)
	{
		if(n==null)return;
		recursiveInorder(n.left);
		Console.WriteLine(n.data);
		recursiveInorder(n.right);
	}

	static void iterativeInorder(Node n)
	{
		Node current=n;
		Stack<Node> s=new Stack<Node>();
		bool status=true;
		while(status)
		{
			if(current!=null)
			{
				s.Push(current);
				current=current.left;
			}
			else
			{
				if(s.Count>0)
				{
					current=s.Pop();
					Console.WriteLine(current.data);
					current=current.right;
				}
				else
				{
					status=false;
				}
			}
		
		}
		
		
	}

	static void Main()
	{
		Node root =new Node(1);
		root.left=new Node(2);
		root.right=new Node(3);
		root.left.left=new Node(4);
		root.left.right=new Node(5);
		//recursiveInorder(root);
		iterativeInorder(root);
	}
}