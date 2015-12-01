using System;

class Queue
{
	public int capacity;
	public int size;
	public int rear;
	public int front;
	int[] arr;
	public Queue(int i)
	{
		capacity=i;
		size=0;
		rear=-1;
		front=0;
		arr=new int[capacity];
	}

	public bool isFull()
	{
		return capacity==size;
	}

	public bool isEmpty()
	{
		return size==0;
	}

	public void enQueue(int i)
	{	
		if(isFull())
		{
			Console.WriteLine("queue is full");
			return;
		}
		rear=(rear+1)%capacity;
		arr[rear]=i;
		size++;
	}

	public int deQueue()
	{
		if(isEmpty())
		{
			Console.WriteLine("queue is empty");
			return int.MinValue;
		}
		int item=arr[front];
		front=(front+1)%capacity;
		size--;
		return item;
	}

	public int getFront()
	{
		if(isEmpty())
		{
			Console.WriteLine("queue is empty");
			return int.MinValue;
		}
		return arr[front];
	}

	public int getRear()
	{
		if(isEmpty())
		{
			Console.WriteLine("queue is empty");
			return int.MinValue;
		}
		return arr[rear];
	}

}

class Program
{
	static void Main()
	{
		Queue q1=new Queue(4);
		q1.enQueue(1);
		q1.enQueue(2);
		q1.enQueue(3);
		q1.enQueue(4);
		Console.WriteLine(q1.getFront());
		Console.WriteLine(q1.getRear());
		q1.deQueue();
		Console.WriteLine(q1.getFront());
		Console.WriteLine(q1.getRear());
	}
}