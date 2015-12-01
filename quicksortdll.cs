using System;

class Node
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

class LinkedList
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

	public void quicksort(Node l,Node r)
	{
		if(r!=null && l!=r && l!=r.next)
		{
			Node p=partition(l,r);
			quicksort(l,p.prev);
			quicksort(p.next,r);
		}
	}

	public Node partition(Node l,Node r)
	{
		int x=r.data;
		Node i=l.prev;
		Node j=null;
		for(j=l;j!=r;j=j.next)
		{
			if(j.data<x)
			{
				i=(i == null)? l :i.next;
				swap(i,j);
			}
		}
		i=(i == null)? l :i.next;
		swap(i,r);
		return i;
	}

	public void swap(Node a,Node b)
	{
		int temp=a.data;
		a.data=b.data;
		b.data=temp;
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
		l1.quicksort(l1.head,l1.tail);
		l1.print();
	}
}