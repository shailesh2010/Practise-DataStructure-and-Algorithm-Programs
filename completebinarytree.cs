using System;
using System.Collections.Generic;
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

class Program
{
	static Queue<Node> q=new Queue<Node>();
	static void insert(Node n,int i)
	{
		Node temp=new Node(i);
		if(n==null)
		{
			n=temp;
		}
		else
		{
			Node a=q.Peek();
			if(a.left==null)
			{
				a.left=temp;
			}
			else if(a.right==null)
			{
				a.right=temp;
			}
			if(a.left!=null && a.right!=null)
			{
				q.Dequeue();
			}
		}
		
		q.Enqueue(temp);
	}

	static void InOrder(Node n)
	{
		if(n==null)return;
		InOrder(n.left);
		Console.WriteLine(n.data);
		InOrder(n.right);
	}

	static void IterativePostOrder(Node n)
	{
		if(n==null)return;
		if(n.left==null && n.right==null)
		{
			Console.WriteLine(n.data);
			return;
		}
		Stack<Node> s=new Stack<Node>();
		Node temp=root;
		do
		{
			while(temp)
			{
				if(temp.right!=null)
				{
					s.Push(temp.right);
				}
				s.Push(temp);
				temp=temp.left;
			}
			temp=s.Pop();
			if(temp.right!=null && temp.right ==s.Peek())
			{
				s.Pop();
				s.Push(temp);
				temp=temp.right;

			}
			else
			{
				Console.WriteLine(a.data);
				temp=null;
			}

		}while(s.Count>0)
		

	}

	static void Main()
	{
		Node root=null;
		//Node root=new Node(1);q.Enqueue(root);
		insert(root,1);
		insert(root,2);
		insert(root,3);
		insert(root,4);
		insert(root,5);
		insert(root,6);	
		InOrder(root);
	}
}