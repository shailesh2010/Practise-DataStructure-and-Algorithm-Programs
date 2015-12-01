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

class Stack
{
	public Node head;
	public Stack()
	{
		head=null;
	}

	public bool isEmpty()
	{
		return head==null;
	}

	public void push(int i)
	{
		Node n=new Node(i);
		if(isEmpty())
		{
		 	head=n;
		 	return;
		}
		n.next=head;
		head=n;
	}

	public void pop()
	{
		if(isEmpty())
		{
			Console.WriteLine("Stack is empty");
			return;
		}
		Console.WriteLine("Popped element is "+head.data);
		head=head.next;
	}

	public void peek()
	{
		Console.WriteLine(head.data);
	}
}

class Program
{
	static void Main()
	{
		Stack s=new Stack();
		s.push(1);
		s.push(2);
		s.push(3);
		s.pop();
		s.pop();
		s.pop();
		s.pop();
	}
	
}