using System;

class StackNode
{
	public int data;
	public StackNode next;
	public StackNode(int i)
	{
		data=i;
		next=null;
	}
}
class Stack
{
	public StackNode head;
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
		StackNode n=new StackNode(i);
		if(head==null)
		{
			head=n;
			return;
		}
		n.next=head;
		head=n;
	}

	public int pop()
	{
		if(head==null)
		{
			return int.MinValue;
		}
		StackNode temp=head;
		head=head.next;
		return temp.data;
	}
}

class Queue
{
	Stack s1;
	//Stack s2;
	public Queue()
	{
		s1=new Stack();
		//s2=new Stack();
	}

	public void enQueue(int i)
	{
		s1.push(i);
	}

	public int deQueue()
	{	
		// if(s1.head==null && s2.head==null)
		// {
		// 	return int.MinValue;
		// }

		// if(s2.head!=null)
		// {
		// 	return s2.pop();
		// }
		// else
		// {
		// 	while(s1.head!=null)
		// 	{
		// 		s2.push(s1.pop());
		// 	}
		// 	return s2.pop();
		// }

		if(s1.head==null)
		{
			return int.MinValue;
		}
		if(s1.head.next==null)
		{
			return s1.pop();
		}
		int x,res;
		x=s1.pop();
		res=deQueue();
		s1.push(x);
		return res;
	}
}

class Program
{
	static void Main()
	{
		Queue q1=new Queue();
		q1.enQueue(1);
		q1.enQueue(2);
		q1.enQueue(3);
		q1.enQueue(4);
		Console.WriteLine(q1.deQueue());
		Console.WriteLine(q1.deQueue());
		
	}
}