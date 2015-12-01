using System;
using System.Collections.Generic;

class Program
{
	static void maxMultipleof3(int[] arr)
	{
		if(arr==null)return;
		Array.Sort(arr);
		Queue<int> q0=new Queue<int>();
		Queue<int> q1=new Queue<int>();
		Queue<int> q2=new Queue<int>();
		int sum=0;
		for(int i=0;i<arr.Length;i++)
		{	
			sum+=arr[i];
			if(arr[i]%3==0)
				q0.Enqueue(arr[i]);
			else if(arr[i]%3==1)
				q1.Enqueue(arr[i]);
			else if(arr[i]%3==2)
				q2.Enqueue(arr[i]);
		}
		
		if(sum%3==1)
		{
			if(q1.Count>0)
			{
				q1.Dequeue();
			}
			else 
			{
				if(q2.Count>0)
					q2.Dequeue();
				else
				{
					Console.WriteLine("Not possible");
					return;
				}
				if(q2.Count>0)
					q2.Dequeue();
				else
				{
					Console.WriteLine("Not possible");
					return;
				}

			}
		}
		else if(sum%3==2)
		{
			if(q2.Count>0)
			{
				q2.Dequeue();
			}
			else 
			{
				if(q1.Count>0)
					q1.Dequeue();
				else
				{
					Console.WriteLine("Not possible");
					return;
				}
				
				if(q1.Count>0)
					q1.Dequeue();
				else
				{
					Console.WriteLine("Not possible");
					return;
				}
			}
		}

		Array.Clear(arr,0,arr.Length);
		int queuesize=q0.Count+q1.Count+q2.Count;
		join(arr,q0,q1,q2);
		Array.Sort(arr);
		Array.Reverse(arr);
		for(int c=0;c<queuesize;c++)
		{
			Console.WriteLine(arr[c]);
		}
	}

	static void join(int[] arr, Queue<int> q0,Queue<int> q1,Queue<int> q2)
	{
		int i=0;
		while(q0.Count>0)
		{
			arr[i]=q0.Dequeue();
			i++;
		}
		while(q1.Count>0)
		{
			arr[i]=q1.Dequeue();
			i++;
		}
		while(q2.Count>0)
		{
			arr[i]=q2.Dequeue();
			i++;
		}
	}

	// static void print(int[] arr)
	// {
	// 	foreach(int i in arr)
	// 	{
	// 		Console.WriteLine(arr[i]);
	// 	}
	// }

	static void Main()
	{
		int[] arr={8, 1, 7, 6, 0};
		maxMultipleof3(arr);
		//print(arr);

	}
}