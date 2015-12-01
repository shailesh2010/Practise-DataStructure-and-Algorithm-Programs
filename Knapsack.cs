using System;

class Program
{
	static int Max(int x,int y)
	{
		return x>y?x:y;
	}

	static int RecursiveKnapsack(int[] val,int[] weight,int n, int W)
	{
		if(W==0 || n==0)return 0;
		if(weight[n-1]>W)
			return RecursiveKnapsack(val,weight,n-1,W);
		return Max( val[n-1]+RecursiveKnapsack(val,weight,n-1,W-weight[n-1]), RecursiveKnapsack(val,weight,n-1,W) );
	}

	static void Knapsack(int[] val,int[] weight,int n, int W)
	{
		int i,w;
		int[,] arr=new int[n+1,W+1];
		for(i=0;i<=n;i++)
		{
			for(w=0;w<=W;w++)
			{
				if(i==0 || w==0)
				{
					arr[i,w]=0;
				}
				else if(weight[i-1]<=w)
				{
					arr[i,w]=Max(val[i-1]+arr[i-1,W-weight[i-1]], arr[i-1,w]);
				}
				else
				{
					arr[i,w]=arr[i-1,w];
				}
			}
		}
		Console.WriteLine(arr[n,W]);
	}

	static void Main()
	{
		int[] val={60, 100, 120};
		int[] weight={10, 20, 30};
		int n=val.Length;
		int W=50;
		Knapsack(val,weight,n,W);
		//Console.WriteLine( RecursiveKnapsack(val,weight,n,W) );
	}
}