using System;
using System.Collections.Generic;

class Node
{
	public int data;
	public Node next;
	public Node random;
	public Node(int i)
	{
		data=i;
		next=null;
		random=null;
	}
}

class LinkedList
{
	public Node head;
	public LinkedList(Node n)
	{
		head=n;
	}

	public void push(int i)
	{
		if(head==null)head=new Node(i);
		else
		{
			Node n=new Node(i);
			n.next=head;
			head=n;
		}
	}

	public void print()
	{
		Node temp = head;
        while (temp != null)
        {
            Node random = temp.random;
            int randomData = (random != null)? random.data: -1;
            Console.WriteLine("Data = " + temp.data + ", Random data = "+ randomData);
            temp = temp.next;
        }
	}

	public LinkedList clonell()
	{
		Node oriCurr=head;
		Node cloneCurr=null;
		Dictionary<Node,Node> d=new Dictionary<Node,Node>();
		while(oriCurr!=null)
		{
			cloneCurr=new Node(oriCurr.data);
			d.Add(oriCurr,cloneCurr);
			oriCurr=oriCurr.next;
		}
		oriCurr=head;
		while(oriCurr!=null)
		{
			cloneCurr=d[oriCurr];
			cloneCurr.next=d[oriCurr.next];
			cloneCurr.random=d[oriCurr.random];
			oriCurr=oriCurr.next;
		}
		return (new LinkedList(d[this.head]));
	}
}

class Clone
{
	static void Main()
	{
		LinkedList l1=new LinkedList(new Node(5));
		l1.push(4);
		l1.push(3);
		l1.push(2);
		l1.push(1);
		l1.head.random = l1.head.next.next;
        l1.head.next.random =l1.head.next.next.next;
        l1.head.next.next.random =l1.head.next.next.next.next;
        l1.head.next.next.next.random =l1.head.next.next.next.next.next;
        l1.head.next.next.next.next.random =l1.head.next;
        l1.print();
        LinkedList clone=l1.clonell();
        clone.print();
	}
}