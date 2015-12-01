using System;

class Program
{
	static int Min(int x,int y)
	{
		return x<y?x:y;
	}

	static int Min(int x,int y, int z)
	{
		return Min(Min(x,y),z);
	}

	static int RecursiveMinCostPath(int[,] arr,int m,int n)
	{
		if(m<0 || n<0)
			return int.MaxValue;
		if(m==0 && n==0)
			return arr[0,0];
		else 
			return arr[m,n]+Min(RecursiveMinCostPath(arr,m-1,n), RecursiveMinCostPath(arr,m,n-1), RecursiveMinCostPath(arr,m-1,n-1));
	}

	static void MinCostPath(int[,] arr,int m,int n)
	{
		if(m==0 && n==0)return;
		int i,j;
		int[,] temp=new int[m,n];
		temp[0,0]=arr[0,0];
		for(i=1;i<m;i++)
		{
			temp[i,0]=arr[i,0]+temp[i-1,0];
		}
		for(j=1;j<n;j++)
		{
			temp[0,j]=arr[0,j]+temp[0,j-1];
		}
		for(i=1;i<m;i++)
		{
			for(j=1;j<n;j++)
			{
				temp[i,j]=arr[i,j]+Min(temp[i-1,j],temp[i,j-1],temp[i-1,j-1]);
			}
		}
		Console.WriteLine(temp[m-1,n-1]);
	
	}


	static void Main()
	{
		int [,] arr= new int[3,3]{
			{1,2,3},{4,8,2},{1,5,3}
		};
		MinCostPath(arr,3,3);
		//Console.WriteLine(RecursiveMinCostPath(arr,2,2));
	}
}