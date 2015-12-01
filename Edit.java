import java.lang.*;
class Edit
{
	static int min(int x,int y,int z)
	{
		return Math.min(Math.min(x,y),z);
	}

	static int editdistance(String a,String b)
	{
		int m=a.length();
		int n=b.length();
		if(m==0)return n;
		if(n==0)return m;
		if(a.charAt(m-1)==b.charAt(n-1))
		return editdistance(a.substring(0,a.length()-1),b.substring(0,b.length()-1));
	
		return 1+ min(editdistance(a.substring(0,m-1),b.substring(0,n)),editdistance(a.substring(0,m),b.substring(0,n-1)),editdistance(a.substring(0,m-1),b.substring(0,n-1)));
	}

	static int editdistancetabular(String a, String b)
	{
		int m=a.length();
		int n=b.length();
		int[][] arr=new int[m+1][n+1];
		for(int i=0;i<=m;i++)
		{
			for(int j=0;j<=n;j++)
			{
				if(i==0)arr[i][j]=j;
				else if(j==0)arr[i][j]=i;
				else if(a.charAt(i-1)==b.charAt(j-1))
				{
					arr[i][j]=arr[i-1][j-1];
				}
				else
				{
					arr[i][j]=1+min(arr[i-1][j],arr[i][j-1],arr[i-1][j-1]);
				}
			}
		}
		return arr[m][n];
	}

	public static void main(String[] args) 
	{
		String str1 = "sunday";
    	String str2 = "saturday";
    	System.out.println(editdistancetabular(str1,str2));	
	}
}

