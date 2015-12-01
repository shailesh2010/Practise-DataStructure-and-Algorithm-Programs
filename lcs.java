import java.lang.*;
class lcs
{
	static int lcsmethod(String a, String b)
	{
		if(a.length()==0 || b.length()==0)return 0;
		if(a.charAt(a.length()-1)==b.charAt(b.length()-1))
			return 1+ lcsmethod(a.substring(0,a.length()-1),b.substring(0,b.length()-1));
		else
			return Math.max(lcsmethod(a,b.substring(0,b.length()-1)),lcsmethod(a.substring(0,a.length()-1),b));
	}

	static int lcstabulation(String a,String b)
	{
		if(a.length()==0 || b.length()==0)
		{
			return 0;
		}
		int i,j;
		int[][] arr=new int[a.length()+1][b.length()+1];
		for(i=0;i<=a.length();i++)
		{
			for(j=0;j<=b.length();j++)
			{
				if(i==0 || j==0)
				{
					arr[i][j]=0;
				}
				else if(a.charAt(i-1)==b.charAt(j-1))
				{
					arr[i][j]=arr[i-1][j-1]+1;
				}
				else 
				{
					arr[i][j]=Math.max(arr[i-1][j],arr[i][j-1]);
				}
			}
		}
		i=a.length();
		j=b.length();
		int index=arr[a.length()][b.length()];
		char[] result=new char[index+1];
		result[index]='\0';
		while(i>0 && j>0)
		{
			if(a.charAt(i-1)==b.charAt(j-1))
			{
				result[index-1]=a.charAt(i-1);
				i--;
				j--;
				index--;
			}
			else if(arr[i-1][j]>arr[i][j-1])
			{
				i--;
			}
			else
			{
				j--;
			}
		}

		for(int k=0;k<result.length-1;k++)
		{
			System.out.println(result[k]);
		}
		return arr[a.length()][b.length()];
	}

	public static void main(String[] args) 
	{
		String a="AGGTAB";
		String b="GXTXAYB";
		System.out.println(lcstabulation(a,b));
	}
}