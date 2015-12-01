using System;

public class Node
{
	public int data;
	public Node next=null;
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
		n.next=head;
		head=n;
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
		Node current =head;
		while(current.next!=null)
		{
			current=current.next;
		}
		current.next=n;
	}

	public Node IterativeReverse()
	{
		Node prev=null,current=head,next_node;
		while(current!=null)
		{
			next_node=current.next;
			current.next=prev;
 			prev=current;
 			current=next_node;
		}
		head=prev;
		return head;

	}

	public void RecursiveReverse(Node n)
	{
		Node first;
		Node second;
		if(n==null)
		{
			return;
		}
		first=n;
		second=first.next;
		if(second==null)
		{
			head=first;
			return;
		}

		RecursiveReverse(second);

		first.next.next=first;
		first.next=null;
		
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
	public Node reverseBySize(Node n,int k)
	{
		Node current=n;
		Node prev=null;
		Node next_node=null;
		int count=1;
		while(current!=null && count<=k)
		{
			next_node=current.next;
			current.next=prev;
			prev=current; 
			current=next_node;
			count++;
		}
		if(next_node!=null)
		{
			n.next=reverseBySize( next_node,k);
		}
		return prev;
	}

	public Node reverseAlternateBySize(Node n,int k,bool b)
	{
		if(n==null)
		{
			return null;
		}
		Node current=n;
		Node prev=null;
		Node next_node=null;
		int count=1;
		while(current!=null && count<=k)
		{
			next_node=current.next;
			if(b==true)
			{
				current.next=prev;
			}
			prev=current;
			current=next_node;
			count++;

		}
		if(b==true)
		{
			n.next=reverseAlternateBySize(current,k,!b);
			return prev;
		}
		else
		{
			prev.next=reverseAlternateBySize(current,k,!b);
			return n;
		}
	}

	public Node reverse(Node n)
	{
		if(n==null|| n.next==null)
		{
			return null;
		}
		Node prev=null;
		Node current=n;
		Node next_node=n.next;
		while(current!=null)
		{
			next_node=current.next;
			current.next=prev;	
			prev=current;
			current=next_node;
		}
		return prev;
	}
	public void deleteNodesWithLessValue(Node n)
	{
		if(n==null || n.next==null)
		{
			return;
		}
		Node a=reverse(n);
		int max=a.data;
		Node prev=a;
		Node current=a.next;
		while(current !=null)
		{
			if(current.data<max)
			{
				prev.next=current.next;
				current.next=null;
				current=prev.next;
			}
			else
			{
				max=current.data;
				prev=current;
				current=current.next;
			}
			
		}
		n=reverse(a);
	}

	public void segregateEvenAndOdd(ref Node n)
	{
		if(n==null || n.next==null)
		{
			return;
		}
		Node current=n;
		Node tail=n;
		while(tail.next !=null)
		{
			tail=tail.next;
		}
		Node new_tail=tail;
		Node prev=null;
		while(current!=new_tail && current.data%2!=0)
		{
			new_tail.next=current;
			current=current.next;
			new_tail.next.next=null;
			new_tail=new_tail.next;
		
		}

		if(current.data%2==0)
		{
			n=current;
			while(current!=tail)
			{
				if(current.data%2==0)
				{
					prev=current;
					current=current.next;
				}
				else
				{
					prev.next=current.next;
					current.next=null;
					new_tail.next=current;
					current=prev.next;
				}
			}
					
		}
		prev=current;
		if(current.data%2!=0)
		{
			prev.next=current.next;
					current.next=null;
					new_tail.next=current;
					current=prev.next;
		}
			


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

}

public class Program
{
	static void Main()
	{
		Linkedlist l1=new Linkedlist();
		l1.AddFirst(3);
		l1.AddFirst(2);
		l1.AddFirst(6);
		l1.AddFirst(5);
		l1.AddFirst(11);
		l1.AddFirst(10);
		l1.AddFirst(15);
		l1.AddFirst(12);
		//l1.head= l1.reverseAlternateBySize(l1.head,3,true);
		//l1.deleteNodesWithLessValue(l1.head);
		l1.segregateEvenAndOdd(ref l1.head);
		l1.printwithnode(l1.head);
		//l1.printList();
		//l1.printList();
		// int size=l1.getIterativeCount();
		// Linkedlist l2= new Linkedlist();
		// l2.head=l1.IterativeReverse();
		// for(int i=0;i<size;i++)
		// {
		// 	Node head1=l1.head,head2=l2.head;
		// 	if(head1.data!=head2.data)
		// 	{
		// 		Console.WriteLine("Not Palindrome");
		// 		break;
		// 	}
		// 	head1=head1.next;
		// 	head2=head2.next;
		// }
		// l1.printList();
	}
}