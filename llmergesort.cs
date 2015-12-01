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

	public Node recursiveSortedMerge(Node a,Node b)
	{
		if(a==null)
		{
			return b;
		}
		if(b==null)
		{
			return a;
		}
		Node n;
		if(a.data<=b.data)
		{
			n=a;
			n.next=	recursiveSortedMerge(a.next,b);
		}
		else
		{
			n=b;
			n.next=recursiveSortedMerge(a,b.next);
		}
		return n;
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

	public void mergesort(ref Node n)
	{
		Linkedlist a1=new Linkedlist();
		Linkedlist a2=new Linkedlist();
		if(n==null || n.next==null)
		{
			return;
		}
		//SplitLL(n,a1.head,a2.head);
		SplitLL(n,ref a1.head,ref a2.head);
		//printwithnode(a1.head);
		//printwithnode(a2.head);
		mergesort(ref a1.head);
		mergesort(ref a2.head);
		n=recursiveSortedMerge(a1.head,a2.head);
	}

	public void printwithnode(Node n)
	{
		Node current=n;
		while(current!=null)
		{
			Console.WriteLine(current.data);
			current=current.next;
		}
		Console.WriteLine("End ");  
	}

	public void SplitLL(Node a,ref Node b,ref Node c)
	{
		Node n1=a;
		Node n2=a.next;
		while(n2!=null && n2.next!=null )
		{
			n1=n1.next;
			n2=n2.next.next;
		}
		b=a;
		c=n1.next;
		n1.next=null;
		//printwithnode(b);
		//printwithnode(c);
		
	}
}


public class Program
{
	static void Main()
	{
		Linkedlist l1=new Linkedlist();
		l1.addLastWithTail(1);
		l1.addLastWithTail(9);
		l1.addLastWithTail(4);
		l1.addLastWithTail(2);
		//l1.addLastWithTail(3);
		//l1.addLastWithTail(5);
		l1.mergesort(ref l1.head);
		l1.printwithnode(l1.head);
	}
}