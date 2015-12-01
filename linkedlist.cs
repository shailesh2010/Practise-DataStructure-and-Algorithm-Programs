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
	public void AddFirst(int i)
	{
		Node n=new Node();
		n.data=i;
		if(head==null)
		{
			head=n;
			return;
		}
		n.next=head;
		head=n;
	}
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
	
	public void AddLast(int i)
	{
		Node n=new Node();
		n.data=i;
		if(head==null)
		{
			head=n;
			return;
		}
		Node current=head;
		while(current.next !=null)
		{
			current=current.next;
		}
		current.next=n;
	}

	public void insertAfter(Node n,int i)
	{
		Node current=head;
		while(current !=n)
		{
			current=current.next;
		}
		Node new_node=new Node();
		new_node.data=i;
		new_node.next=current.next;
		current.next=new_node;
	}

	public int getIterativeCount()
	{
		Node current=head;
		int count=0;
		while(current!=null)
		{
			count++;
			current=current.next;
		}
		return count; 
	}

	public int getRecursiveCount(Node n)
	{
		if(n==null)
		{
			return 0;
		}
		return 1+getRecursiveCount(n.next);
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

	public void deleteLinkedList()
	{
		Node current=head;
		while(current!=null)
		{
			current=head.next;
			head.next=null;
			head=current;
		}
		Console.WriteLine("LL deleted");
	}

	public void insertBefore(Node n,int i)
	{
		Node p1=head;
		Node p2=null;
		while(p1 !=n)
		{
			p2=p1;
			p1=p1.next;
		}
		Node new_node=new Node();
		new_node.data=i;
		new_node.next=p2.next;
		p2.next=new_node;

	}

	public bool isPalindrome(ref Node left,Node right)
	{
		if(right==null)
		{
			return true;
		}
		bool b= isPalindrome(ref left,right.next);
		if(b==false)
		{
			return false;
		}
		bool b1=(left.data==right.data);
		left=left.next;
		return b1;
	}

	public bool isPalindromeMain(Node head)
	{
		return isPalindrome(ref head,head);
	}

	public void alternateSplit(Node head,Linkedlist a,Linkedlist b)
	{
		Node current=head;
		while(current !=null)
		{
			a.AddFirst(current.data);
			current=current.next;
			if(current!=null)
			{
				b.AddFirst(current.data);
				current=current.next;
			}
		}
	}


	public void sortedMerge(Node a,Node b)
	{
		Node current1=a;
		Node current2=b;
		Linkedlist l3=new Linkedlist();
		if(a==null)
		{
			l3.head=b;
			return;
		}
		if(b==null)
		{
			l3.head=a;
			return;
		}
		while(current1!=null &&current2!=null)
		{
			if(current1.data<=current2.data)
			{
				l3.addLastWithTail(current1.data);
				current1=current1.next;
			}
			else
			{
				l3.addLastWithTail(current2.data);
				current2=current2.next; 
			}
		}
		if(current1==null)
		{
			l3.tail.next=current2;
		}
		if(current2==null)
		{
			l3.tail.next=current1;
		}
		l3.printList();
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
		Node n=new Node();
		if(a.data<=b.data)
		{
			n.data=a.data;
			n.next=	recursiveSortedMerge(a.next,b);
		}
		else
		{
			n.data=b.data;
			n.next=recursiveSortedMerge(a,b.next);
		}
		return n;
	}

	public bool iterativeAreIdentical(Node a,Node b)
	{
		while(true)
		{
			if(a==null && b==null)
			{
				return true;
			}
			if(a==null && b!=null)
			{
				return false;
			}
			if(a!=null && b==null)
			{
				return false;
			}
			if(a.data!=b.data)
			{
				return false;
			}
			a=a.next;
			b=b.next;
		}
		
	}
	public bool recursiveAreIdentical(Node a,Node b)
	{
		if(a==null && b==null)
			{
				return true;
			}
			if(a==null && b!=null)
			{
				return false;
			}
			if(a!=null && b==null)
			{
				return false;
			}
			if(a.data!=b.data)
			{
				return false;
			}
			return recursiveAreIdentical(a.next,b.next);
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
		Linkedlist l2=new Linkedlist();
		l2.addLastWithTail(1);
		l2.addLastWithTail(5);
		l2.addLastWithTail(7);
		l2.addLastWithTail(11);
		if(l1.recursiveAreIdentical(l1.head,l2.head))
		{
			Console.WriteLine("Identical");
		}
		else
		{
			Console.WriteLine("not");
		}
		//Linkedlist l3=new Linkedlist();
		//l3.sortedMerge(l1.head,l2.head);
		//l3.head= l3.recursiveSortedMerge(l1.head,l2.head);
		//Linkedlist l3=new Linkedlist();
		//l1.alternateSplit(l1.head,l2,l3);
		//l3.printList();
		//Console.WriteLine("next");
		//l3.printList();
		//l1.AddLast(1);
		//l1.AddLast(2);
		//l1.AddLast(3);
		//l1.AddLast(4);
		//l1.insertAfter(l1.head.next.next,8);
		//l1.insertBefore(l1.head.next,9);
		//l1.printList();
		//Console.WriteLine("Number of elements are {0}",l1.getIterativeCount());
		//Console.WriteLine("Number of elements are {0}",l1.getRecursiveCount(l1.head));
		//l1.deleteLinkedList();
		//Console.WriteLine("Number of elements are {0}",l1.getIterativeCount());
		//if(l1.isPalindromeMain(l1.head))
		//{
			//Console.WriteLine("LL is palindrome");
		//}
		//else
		//{
		//	Console.WriteLine("Not");
		//}
		//l1.printList();
	}
}