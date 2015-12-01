using System;
using System.Text;

class Stack
{
	public int capacity;
	public char[] arr;
	public int top;
	public Stack(int i)
	{
		top=-1;
		capacity=i;
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

	public char pop()
	{
		if(isEmpty())
		{
			Console.WriteLine("Stack Empty");
			return char.MinValue;
		}
		else
		{
			return arr[top];
			//Console.WriteLine("Popped element is "+arr[top--]+" ");
		}
	}

	public char peek()
	{
		if(isEmpty())
		{
			Console.WriteLine("Stack Empty");
			return char.MinValue;
		}
		else
		{
			Console.WriteLine(arr[top]);
			return arr[top];
		}
	}

	public bool isOperand(char c)
	{	
		return (c>='a' && c<='z')||(c>='A' && c<='Z');

	}

	public int prec(char c)
	{
		switch(c)
		{
			case '+':
			case '-':
			return 1;
			case '*':
			case '/':
			return 2;
			case '^':
			return 3;
		}
		return -1;
	}
	public void infixtopostfix(string s1)
	{
		int i=s1.Length;
		StringBuilder s=new StringBuilder(s1);
		int j,k;
		for(j=0,k=-1;j<i;j++)
		{
			if(isOperand(s[j]))
			s[++k]=s[j];
			else
			if(s[j]=='(') this.push(s[j]);
			else
			if(s[j]==')')
			{
				while(!this.isEmpty() && this.peek()!='(')
					s[++k]=	this.pop();
				if(!this.isEmpty() && this.peek() !='(')
					return;
				else
					this.pop();
			}
			else
			{
				while(!this.isEmpty() && prec(s[j])<=prec(this.peek()))
					s[++k]=this.pop();
				this.push(s[j]);
			}
		}
		while(!this.isEmpty())
			s[++k]=this.pop();
			s1=s.ToString();
		Console.WriteLine(s1);
	}
}

class Program
{
	static void Main()
	{
		string s="a+b*(c^d-e)^(f+g*h)-i";
		Stack st=new Stack(s.Length);
		st.infixtopostfix(s);
	}
}