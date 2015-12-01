using System;

class Program
{
	static int RecursiveCoinChange(int[] arr,int arraysize,int totalmoney)
	{
		if(totalmoney==0)return 1;
		if(totalmoney<0)return 0;
		if(arraysize<=0 && totalmoney>0)return 0;
		return RecursiveCoinChange(arr,arraysize-1,totalmoney)+RecursiveCoinChange(arr,arraysize,totalmoney-arr[arraysize-1]);
	}

	static int CoinChange(int[] arr,int arraysize,int totalmoney)
	{
		int[,] temp=new int[totalmoney+1,arraysize];
		int i,j,x,y;
		for(i=0;i<arraysize;i++)
		{
			temp[0,i]=1;
		}

		for(i=1;i<totalmoney+1;i++)
		{
			for(j=0;j<arraysize;j++)
			{
				x=(i-arr[j]>=0)?temp[i-arr[j],j]:0;
				y=(j>=1)?temp[i,j-1]:0;
				temp[i,j]=x+y;
			}
		}
		return temp[totalmoney,arraysize-1];

	}

	static int OptimizedCoinChange(int[] arr,int arraysize,int totalmoney)
	{
		int[] table=new int[totalmoney+1];
		table[0]=1;
		int i,j;
		for(i=1;i<=totalmoney;i++)
		{
			table[i]=0;
		}
		for(i=0;i<arraysize;i++)
		{
			for(j=arr[i];j<=totalmoney;j++)
			{
				table[j]+=table[j-arr[i]];
			}
		}
		return table[totalmoney];
	}

	static void Main()
	{
		int[] arr={1,2,3};
		int arraysize=arr.Length;
		int totalmoney=4;
		Console.WriteLine(OptimizedCoinChange(arr,arraysize,totalmoney));
		//Console.WriteLine(RecursiveCoinChange(arr,arraysize,totalmoney));
		//Console.WriteLine(CoinChange(arr,arraysize,totalmoney));
	}
}