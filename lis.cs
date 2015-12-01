using System;

class Program
{

	static int lis(int[] arr,int n,int max)
	{
		if(n==1)return 1;
		int res;
		int max_ending_here=1;
		for(int i=0;i<n-1;i++)
		{
			res=lis(arr,i+1,max);
			if(arr[i]<arr[n-1]  && res+1>max_ending_here)
			{
				max_ending_here=res+1;
			}

		}

		if(max<max_ending_here)
				max=max_ending_here;
		return max_ending_here;
	}


	static int recursivelis(int[] arr)
	{
		int n=arr.Length;
		int[] temp=new int[n];
		for(int i=1;i<n;i++)
		{
			for(int j=0;j<i;j++)
			{
				if(arr[j]<arr[i]  && temp[j]+1>temp[i])
				{
					temp[i]=temp[j]+1;
				}
			}
		}
	}

	static void Main()
	{
		int[] arr={10,22,9,33,21,50,41,60,80};
		Console.WriteLine(lis(arr,arr.Length,1));
	}
}