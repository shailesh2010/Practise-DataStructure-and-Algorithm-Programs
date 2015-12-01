using System;

class Program
{
	static int RecursiveBinomialCoefficient(int n,int k)
	{
		if(k==0 || k==n)return 1;
		return RecursiveBinomialCoefficient(n-1,k-1) + RecursiveBinomialCoefficient(n-1,k);
	}

	static int min(int x,int y)
	{
		return x<y?x:y;
	}

	static void BinomialCoefficient(int n,int k)
	{
		int[,] arr=new int[n+1,k+1];
		int i,j;
		for(i=0;i<=n;i++)
		{
			for(j=0;j<=k;j++)
			{
				arr[i,j]=0;
			}
		}

		for(i=0;i<=n;i++)
		{
			for(j=0;j<=min(i,k);j++)
			{
				if(j==0 || j==i)arr[i,j]=1;
				else
					arr[i,j]=arr[i-1,j-1]+arr[i-1,j];
			}
		}
		Console.WriteLine(arr[n,k]);
	}

	static void Main()
	{
		int n=5;
		int k=2;
		BinomialCoefficient(n,k);
		//Console.WriteLine(RecursiveBinomialCoefficient(n,k));
	}
}