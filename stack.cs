using System;
using System.Collections.Generic;

class Stack
{
	public int capacity;
	public int top;
	public int[] arr;
	public Stack(int i)
	{
		top=-1;
		capacity=i;
		arr=new int[i];
	}

	public bool isFull()
	{
		return top==capacity-1;
	}

	public bool isEmpty()
	{
		return top==-1;
	}

	public void push(int i)
	{
		if(this.isFull())
		{
			Console.WriteLine("Stack is full");
			return;
		}
		else
		{
			arr[++top]=i;
		}
	}

	public int pop()
	{
		if(isEmpty())
		{
			Console.WriteLine("Stack Empty");
			return int.MinValue;
		}
		else
		{
			return arr[top--];
			//Console.WriteLine("Popped element is "+arr[top--]+" ");
		}
	}

	public int peek()
	{
		if(isEmpty())
		{
			Console.WriteLine("Stack Empty");
			return int.MinValue;
		}
		else
		{
			return arr[top];
			//Console.WriteLine(arr[top]);
		}
	}

	public bool isDigit(char c)
	{
		return (c>='0' && c<='9');
	}

	public void evaluatepostfixexp(string s)
	{
		Stack stack=new Stack(s.Length);
		char[] carr=s.ToCharArray();
		foreach(char c in carr)
		{
			if(isDigit(c))
			{
				stack.push(c-'0');
				Console.WriteLine(stack.peek());
			}
			else
			{
				int a =stack.pop();
				int b=stack.pop();
				switch(c)
				{
					case '+':stack.push(a+b);break;
					case '-':stack.push(a-b);break;
					case '*':stack.push(a*b);break;
					case '/':stack.push(a/b);break;
				}
			}
		}
		Console.WriteLine(stack.peek());
	}
}

class Program
{
	static void Main()
	{
		Stack s=new Stack(1);
		s.evaluatepostfixexp("231*+9-");
		// Stack s=new Stack(5);
		// s.push(1);
		// s.push(2);
		// s.push(3);
		// s.push(4);
		// s.peek();
		// s.pop();
		// s.pop();
		// s.pop();
		// s.pop();
		// s.pop();
		// s.peek();

	}
}