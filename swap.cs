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

	public void swapKthNode(int i)
	{
		if(head==null)return;
		int count=1;
		Node current=head;
		while(current!=null)
		{
			current=current.next;
			count++;
		}
		count=count-1;
		if(i>count)return;
		if(count==2*i-1)return;
		Node xprev=null;
		Node yprev=null;
		Node x=head;
		Node y=head;
		for(int k=1;k<i;k++)
		{
			xprev=x;
			x=x.next;
		}
		for(int k=1;k<count-i+1;k++)
		{
			yprev=y;
			y=y.next;
		}
		if(xprev!=null)
		{
			xprev.next=y;
		}
		if(yprev!=null)
		{
			yprev.next=x;
		}
		Node temp=x.next;
		x.next=y.next;
		y.next=temp;

		if(i==1)head=y;
		if(i==count)head=x;
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
		l1.addFirst(5);
		l1.addFirst(6);
		l1.print();
		l1.swapKthNode(1);
		l1.print();
	}
}