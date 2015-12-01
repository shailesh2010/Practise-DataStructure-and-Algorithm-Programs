using System;

public class Program
{
	public static void Main()
	{
		permutation("","abcd");
	}

	public static void permutation(String prefix,String str)
	{
		int n=str.Length;
		if(n==0)Console.WriteLine(prefix);
		else
		{
			for(int i=0;i<n;i++)
			{
				permutation(prefix+str[i],str.Substring(0,i)+str.Substring(i+1,n-i-1));
			}
		}
		
	}
}