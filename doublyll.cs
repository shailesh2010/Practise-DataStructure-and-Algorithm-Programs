using System;

public class Node
{
	 public int data;
	 public Node next;
	 public Node prev;
	 public Node(int i)
	{
		data=i;
		next=null;
		prev=null;
	}
}

public class LinkedList
{
	public Node head;
	public Node tail;
	public LinkedList()
	{
		head=null;
		tail=null;
	}

	public void addFirst(int i)
	{
		Node n=new Node(i);
		if(head==null)
		{
			head=n;
			tail=n;
			return;
		}
		n.next=head;
		head.prev=n;
		head=n;
	}

	public void addLast(int i)
	{
		Node n=new Node(i);
		if(tail==null)
		{
			head=n;
			tail=n;
			return;
		}
		tail.next=n;
		n.prev=tail;
		tail=n;
	}

	public void addAfter(Node n,int i)
	{
		if(head==null || n==null)
		{
			return;
		}
		Node current=head;
		Node new_node=new Node(i);
		while(current!=n)
		{
			current=current.next;
		}
		if(current==null)
		{
			Console.WriteLine("given  node not existed");
			return;
		}
		new_node.next=current.next;
		current.next.prev=new_node;
		new_node.prev=current;
		current.next=new_node;
	}

	public void deleteNode(Node n)
	{
		if(head==null || n==null)return;
		if(head==n)
		{
			head=head.next;
			head.prev.next=null;
			head.prev=null;
		}
		if(n.next!=null)
		{
			n.next.prev=n.prev;
		}
		if(n.prev!=null)
		{
			n.prev.next=n.next;
		}
		n.next=null;
		n.prev=null;

	}

	public void reverse()
	{
		if(head==null)
		{
			return;
		}
		Node temp=null;
		Node current=head;
		while(current!=null)
		{
			temp=current.prev;
			current.prev=current.next;
			current.next=temp;
			current=current.prev;
		}
		if(temp!=null)
		{
			head=temp.prev;
		}
	}

	public void print()
	{
		if(head==null)
		{
			return;
		}
		Node current=head;
		while(current!=null)
		{
			Console.WriteLine(current.data);
			current=current.next;
		}
	}
}

public class Program
{
	static void Main()
	{
		LinkedList l1=new LinkedList();
		l1.addFirst(1);
		l1.addFirst(2);
		l1.addFirst(3);
		l1.addFirst(4);
		l1.addLast(5);
		l1.addLast(6);
		l1.addAfter(l1.head,7);
		l1.deleteNode(l1.head.next);
		l1.reverse();
		l1.print();
	}
}