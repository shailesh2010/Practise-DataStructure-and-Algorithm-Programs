using System;

public class Node
{
	public int data;
	public Node next;
	public Node(int i)
	{
		data=i;
		next=null;
	}
}

public class LinkedList
{
	public Node head;

	public LinkedList()
	{
		head=null;
	}

	public void push(int i)
	{
		Node n=new Node(i);
		if(head==null)
		{
			head=n;
			n.next=n;
			return;
		}
		n.next=head;
		Node temp=head;
		while(temp.next!=head)
		{
			temp=temp.next;
		}
		temp.next=n;
		head=n;
	}

	public void splitLL(ref Node a,ref Node b)
	{
		if(head==null )
		{
			return;
		}
		Node ptr1=head;
		Node ptr2=head;
		while(ptr2.next!=head || ptr2.next.next!=head)
		{
			ptr1=ptr1.next;
			ptr2=ptr2.next.next;
		}
		if(ptr2.next.next==head)
		{
			ptr2=ptr2.next;
		}
		a=head;
		b=ptr1.next;
		ptr2.next=b;
		ptr1.next=a;
		printwithnode(a);
		printwithnode(b);
	}

	public void printwithnode(Node n)
	{
		if(n==null)return;
		Node current=n;
		Node temp=n;
		do
		{
			Console.WriteLine(current.data);
			current=current.next;
		}while(current!=temp);
	}

	public void print()
	{
		if(head==null)
		{
			return;
		}
		Node current=head;
		do
		{
			Console.WriteLine(current.data);
			current=current.next;
	
		}while(current!=head);
		
	}
}

public class Program
{
	public static void Main()
	{
		LinkedList l1=new LinkedList();
		l1.push(1);
		l1.push(2);
		l1.push(3);
		l1.push(4);
		l1.push(5);
		//l1.print();
		LinkedList l2=new LinkedList();
		LinkedList l3=new LinkedList();
		l1.splitLL(ref l2.head,ref l3.head);
		//l3.print();

	}
}

