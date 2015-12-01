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
	static bool completeBinaryTree(Node r)
	{
		if(r==null)return true;
		Queue<Node> q=new Queue<Node>();
		q.Enqueue(r);
		bool status=false;
		while(q.Count !=0)
		{
			Node temp=q.Dequeue();
			if(temp.left !=null)
			{
				if(status==true)
				{
					return false;
				}
				q.Enqueue(temp.left);
			}
			else
			{
				status=true;
			}

			if(temp.right !=null)
			{
				if(status==true)
				{
					return false;
				}
				q.Enqueue(temp.right);
			}
			else
			{
				status=true;
			}

		}
		return true;

	}

	static int height(Node n)
	{
		if(n==null)return 0;
		int lh=height(n.left);
		int rh=height(n.right);
		if(lh<rh)
		{
			return rh+1;
		}
		return lh+1;
	}
	static void printGivenLevel(Node n, int level)
	{
		if(n==null)return;
		if(level==1)
		{
			Console.WriteLine(n.data); 
		}
		else if(level>1)
		{
			printGivenLevel(n.left,level-1);
			printGivenLevel(n.right,level-1);
		}
	}

	static void printTree(Node n)
	{
		if(n==null)return;
		int h=height(n);
		for(int i=1;i<=h;i++)
		{
			printGivenLevel(n,i);
		}
	}

	static void Main()
	{
		Node root=new Node(1);
		root.left=new Node(2);
		root.right=new Node(3);
		root.left.left=new Node(4);
		root.left.right=new Node(5);
		root.right.right=new Node(6);
		printTree(root);
		// if(completeBinaryTree(root))
		// {
		// 	Console.WriteLine("Complete ");
		// }
		// else
		// {
		// 	Console.WriteLine("Not Complete");
		// }
		
	}
}

