using System;

public class Node
{
	public	int data;
	public Node right=null;
	public Node down=null;
}

public class Linkedlist
{
	public Node head=null;

	public void AddFirst(int i)
	{
		Node n=new Node();
		n.data=i;
		if(head==null)
		{
			head=n;
			return;
		}
	}

	public void addNodeDown(Node n,int i)
	{
		Node a=new Node();
		a.data=i;
		if(n==null)
		{
			head=a;
			return;
		}
		n.down=a;
	}

	public void addNodeRight(Node n,int i)
	{
		Node a=new Node();
		a.data=i;
		if(n==null)
		{
			head=a;
			return;
		}
		n.right=a;
	}


	public void printlist()
	{
		if(head==null)
		{
			Console.WriteLine("No element found");
			return;
		}
		Node current=head;
		Node next=head.right;
		while(current!=null || next!=null)
		{
			Console.WriteLine(current.data+"\t");
			current=current.down;
			if(current==null && next==null)
			{
				return;
				

			}
			else if(current==null && next!=null)
			{
				current=next;
				next=next.right;
			}
		}
	}

	public Node merge(Node a,Node b)
	{
		if(a==null)
		{
			return b;
		}
		if(b==null)
		{
			return a;
		}
		Node res=null;
		if(a.data<b.data)
		{
			res=a;
			res.down=  merge(a.down,b);
		}
		else
		{
			res=b;
			res.down= merge(a,b.down);
		}
		return res;
	}

	public Node flattenFunction(Node n)
	{
		if(n==null || n.right==null)
		{
			return n;
		}
		return merge(n,flattenFunction(n.right));
	}

	public void print()
	{
		Node current=head;
		while(current!=null)
		{
			Console.WriteLine(current.data);
			current=current.down;
		}
	}
}


public class program
{
	static void Main()
	{
		Linkedlist l1=new Linkedlist();
		l1.AddFirst(5);
		l1.addNodeDown(l1.head,7);
		l1.addNodeDown(l1.head.down,8);
		l1.addNodeDown(l1.head.down.down,30);
		l1.addNodeRight(l1.head,10);
		l1.addNodeRight(l1.head.right,19);
		l1.addNodeDown(l1.head.right.right,22);
		l1.addNodeDown(l1.head.right.right.down,50);
		l1.addNodeDown(l1.head.right,20);
		l1.head= l1.flattenFunction(l1.head);
		l1.print();
		//l1.printlist();
	}
	
}