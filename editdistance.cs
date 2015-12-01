using System;

class Program
{
	static int min(int x,int y)
	{
		return x<y?x:y;
	}

	static int min(int x,int y,int z)
	{
		return min(min(x,y),z);
	}

	static int recursiveeditdistance(String s1,String s2,int m,int n)
	{
		if(m==0)
			return n;
		if(n==0)
			return m;
		if(s1[m-1]==s2[n-1])
			return recursiveeditdistance(s1,s2,m-1,n-1);
		return 1+ min(recursiveeditdistance(s1,s2,m-1,n), recursiveeditdistance(s1,s2,m,n-1), recursiveeditdistance(s1,s2,m-1,n-1));
	}

	static void editdistance(String s1, String s2)
	{
		int m=s1.Length;
		int n=s2.Length;
		int[,] arr=new int[m+1,n+1];
		for(int i=0;i<=m;i++)
		{
			for(int j=0;j<=n;j++)
			{
				if(i==0)arr[i,j]=j;
				if(j==0)arr[i,j]=i;
				if(s1[i-1]==s2[j-1])
				{
					arr[i,j]=arr[i-1,j-1];
				}
				else
				{
					arr[i,j]=1+min(arr[i-1,j],arr[i,j-1],arr[i-1,j-1]);
				}
			}
		}
		Console.WriteLine(arr[m,n]);
	}

	static void Main()
	{
		String s1="sunday";
		String s2="saturday";
		int m=s1.Length;
		int n=s2.Length;
		editdistance(s1,s2);

	}
}