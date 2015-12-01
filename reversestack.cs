using System;

class Stack
{
	public int capacity;
	public int top;
	public char[] arr;
	public Stack(int i)
	{
		capacity=i;
		top=-1;
		arr=new char[i];
	}

	public bool isFull()
	{
		return top==capacity-1;
	}

	public bool isEmpty()
	{
		return top==-1;
	}

	public void push(char i)
	{
		if(isFull())
		{
			Console.WriteLine("Stack is full");
			return;
		}
		arr[++top]=i;
	}

	public char pop()
	{
		if(isEmpty())
		{
			Console.WriteLine("stack is empty");
			return char.MinValue;
		}
		return arr[top--];
	}

	public char peek()
	{
		if(isEmpty())
		{
			Console.WriteLine("stack is empty");
			return char.MinValue;
		}
		return arr[top];
	}

	public string reverse(string str)
	{
		char[] c=str.ToCharArray();
		int length=str.Length;
		foreach(char c1 in c)
		{
			push(c1);
		}
		for(int i=0;i<length;i++)
		{
			c[i]=pop();
		}
		string a=new string(c);
		return a;
	}

	public void stackReverse()
	{
		char temp;
		if(isEmpty())
		{
			return;
		}
		temp=pop();
		stackReverse();
		insertAgain(temp);
	}

	public void insertAgain(char a)
	{
		if(this.isEmpty())
		{
			push(a);
		}
		else
		{
			char temp=pop();
			insertAgain(a);
			push(temp);
		}
	}
}

class Program
{
	static void Main()
	{
		// Console.WriteLine("Enter string");
		// string s=Console.ReadLine();
		// Stack s1=new Stack(s.Length);
		// s=s1.reverse(s);
		// Console.WriteLine(s);
		Stack s=new Stack(5);
		s.push('a');
		s.push('b');
		s.push('c');
		s.push('d');
		s.push('e');
		Console.WriteLine(s.peek());
		s.stackReverse();
		Console.WriteLine(s.pop());
		Console.WriteLine(s.pop());
		Console.WriteLine(s.pop());
		Console.WriteLine(s.pop());
	}
}