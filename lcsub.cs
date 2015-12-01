using System;

class Program
{
	static int max(int a, int b)
	{
		return a>b?a:b;
	}

	// static int recursivelcs(String s1,String s2)
	// {
	// 	int l1=s1.Length;
	// 	int l2=s2.Length;
	// 	if(l1==0 || l2==0)
	// 		return 0;
	// 	if(s1[l1-1]==s2[l2-1])
	// 	 return 1+lcs( s1.Substring(0,l1-1) , s2.Substring(0,l2-1) );
	// 	else
	// 		return max( lcs(s1.Substring(0,l1-1) , s2), lcs(s1 , s2.Substring(0,l2-1)) );
	// }

	static void lcs(String s1,String s2)
	{
		int l1=s1.Length;
		int l2=s2.Length;
		int[,] arr=new int[l1+1,l2+1];
		for(int i=0;i<=l1;i++)
		{
			for(int j=0;j<=l2;j++)
			{
				if(i==0 || j==0)
				{
					arr[i,j]=0;
				}
				else if(s1[i-1]==s2[j-1])
				{
					arr[i,j]=arr[i-1,j-1]+1;
				}
				else
				{
					arr[i,j]=max(arr[i-1,j],arr[i,j-1]);
				}

			}
		}
		int maximum= arr[l1,l2];
		int a=l1,b=l2;
		String temp="";
		while(a>0 && b>0)
		{
			if(s1[a-1]==s2[b-1])
			{
				temp=s1[a-1]+temp;
				a--;
				b--;
			}
			else if(arr[a-1,b]>arr[a,b-1])
			{
				a--;
			}
			else
				b--;
		}
		Console.WriteLine(temp+ " no of elements "+maximum);
	}



	static void Main()
	{
		String s1="ABCDGH";
		String s2="AEDFHR";
		lcs(s1,s2);	
	}
}