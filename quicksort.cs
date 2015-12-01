using System;

class quicksort
{
	static void Main(string[] args)
	{
		int[] arr={22,4,17,2,98,54};
		int n=arr.Length;
		quicksort q=new quicksort();
		q.PrintArray(arr,n);
		q.Quicksort(arr,0,n-1);
		q.PrintArray(arr,n);
	}

	void PrintArray(int[] arr,int n)
	{
		for(int i=0;i<n;i++)
		{
			Console.Write(arr[i]+"\t");
		}
		Console.WriteLine("\n");
	}

	void Quicksort(int[] arr,int l,int r)
	{
		if(l<r)
		{
			int p=partition(arr,l,r);
			if(p>1)
			Quicksort(arr,l,p-1);
			if(p+1<r)
			Quicksort(arr,p+1,r);
		}
	}

	int partition(int[] arr,int l,int r)
	{
		int x=arr[l];
		while(true)
		{
			while(arr[l]<x)
				l++;
			while(arr[r]>x)
				r--;
			if(l<r)
			{
				int temp=arr[l];
				arr[r]=arr[l];
				arr[r]=temp;
			}
			else
			{
				return r;
			}
		}
	}

	
}


