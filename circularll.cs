using System;

class Node
{
	public int data;
	public Node next;
	public Node(int i)
	{
		data=i;
		next=null;
	}
}

class Linkedlist
{
	public Node head;
	public Linkedlist()
	{
		head=null;
	}
	public void addNode(int i)
	{
		Node n=new Node(i);
		n.next=head;
		Node current=head;
		if(head!=null)
		{
			while(current.next!=head)
			{
				current=current.next;
			}
			current.next=n;
		}
		else
		{
			n.next=n;
		}
		head=n;
		
	}

	public void print()
	{
		Node current=head;
		if(head==null)
		{
			return;
		}
		do
		{
			Console.WriteLine(current.data);
			current=current.next;
		}while(current!=head);
	}
}

class Program
{
	public static void Main(string[] args)
	{
		Linkedlist l1=new Linkedlist();
		l1.addNode(1);
		l1.addNode(2);
		l1.addNode(3);
		l1.addNode(4);
		l1.addNode(5);
		l1.print();
	}
}