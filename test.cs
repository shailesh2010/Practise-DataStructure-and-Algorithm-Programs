using System;

public class Node
{
	public int data;
	public Node next=null;
}

public class Linkedlist
{
	public Node head=null;
	public Node tail=null;
	public void addLastWithTail(int i)
	{
		Node n=new Node();
		n.data=i;
		if(head==null)
		{
			head=n;
			tail=n;
			return;
		}
		tail.next=n;
		tail=n;
	}

	public void changenext(ref Node n)
	{
		Node a=n.next;
		n.next=null;
		n=a;
	}

	public void printList()
	{
		Node current=head;
		while(current!=null)
		{
			Console.WriteLine(current.data+"\t");
			current=current.next;
		}
	}
}

public class Program
{
	static void Main()
	{
		Linkedlist l1=new Linkedlist();
		l1.addLastWithTail(1);
		l1.addLastWithTail(5);
		l1.addLastWithTail(7);
		l1.addLastWithTail(9);
		l1.changenext(ref l1.head);
		l1.printList();
	}
}
