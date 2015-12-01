using System;

class Program
{
	static int RecursiveChainMultiplication(int[] arr,int i,int j)
	{
		if(i==j)return 0;
		int k;
		int min=int.MaxValue;
		int count;
		for(k=i;k<j;k++)
		{
			count=RecursiveChainMultiplication(arr,i,k)+RecursiveChainMultiplication(arr,k+1,j)+arr[i-1]*arr[k]*arr[j];
			if(count<min)
				min=count;
		}
		return min;

	}

	static void printoutput(int[,] arr,int i,int j)
	{
		Console.Write("(");
		printoutput(arr,i,arr[i,j]);
		printoutput(arr,arr[i,j]+1,j);
		Console.Write(")");

	}

	static void MatrixChainMultiplication(int[] arr,int size)
	{
		if(size==0)return;
		int[,] table=new int[size,size];
		int i,j,k,L,q;
		int[,] printtable=new int[size,size];
		for(i=1;i<size;i++)
		{
			table[i,i]=0;
		}
		for(L=2;L<size;L++)
		{
			for(i=1;i<=size-L;i++)
			{
				j=i+L-1;
				table[i,j]=int.MaxValue;
				for(k=i;k<=j-1;k++)
				{
					q=table[i,k]+table[k+1,j]+arr[i-1]*arr[k]*arr[j];
					if(q<table[i,j])
					{
						table[i,j]=q;
						printtable[i,j]=k;
					}
				}
			}
		}
		// Console.WriteLine(table[0,3]);
		 Console.WriteLine(table[1,size-1]);
		 printoutput(printtable,1,size-1);
		// Console.WriteLine(table[2,3]);
	}

	static void Main()
	{
		int[] arr={1,2,3,4};
		int arraylenth=arr.Length;
		MatrixChainMultiplication(arr,arraylenth);
		//Console.WriteLine(RecursiveChainMultiplication(arr,1,arraylenth-1));
	}
}