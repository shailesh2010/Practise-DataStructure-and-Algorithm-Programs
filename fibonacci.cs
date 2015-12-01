using System;

class Program
{
	public int[] a=new int[5];
	int RecursiveFibonacci(int i)
	{
		if(i<=1)
			return i;
		return RecursiveFibonacci(i-1)+RecursiveFibonacci(i-2);
	}

	int MemorisedFibonacci(int i)
	{
		if(a[i]==int.MinValue)
		{
			if(i<=1)
			{
				a[i]=i;
			}
			else
			{
				a[i]=MemorisedFibonacci(i-1)+MemorisedFibonacci(i-2);
			}
		}
		return a[i];
	}
	void InitializeArray()
	{
		for(int i=0;i<5;i++)
		{
			a[i]=int.MinValue;
		}
	}

	int TabulatedFibonacci(int i)
	{
		if(i<=1)
			return i;
		a[0]=0;
		a[1]=1;
		for(int j=2;j<=i;j++)
		{
			a[j]=a[j-1]+a[j-2];
		}
		return a[i];
	}

	static void Main()
	{
		Program p=new Program();
		Console.WriteLine(p.TabulatedFibonacci(4));
		//p.MemorisedFibonacci(4);
		//p.InitializeArray();
		//Console.WriteLine(p.MemorisedFibonacci(4));
	}
}