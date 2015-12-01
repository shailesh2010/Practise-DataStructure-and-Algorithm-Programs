using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		int[] arr={100,80,60,70,60,75,85};
		int[] s1=new int[arr.Length];
		print(arr);
		spanStock(arr,s1);
		print(s1);
	}

	static void spanStock(int[] a, int[] b)
	{
		Stack<int> s=new Stack<int>();
		s.Push(0);
		b[0]=1;
		for(int i=1;i<a.Length;i++)
		{
			while(s.Count >0 && a[i] >a[s.Peek()])
				s.Pop();
			b[i]=(s.Count>0)?(i-s.Peek()):(i+1);
			s.Push(i);
		}
	}

	static void print(int[] arr)
	{
		for(int i=0;i<arr.Length;i++)
			Console.WriteLine(arr[i]);
	}
}