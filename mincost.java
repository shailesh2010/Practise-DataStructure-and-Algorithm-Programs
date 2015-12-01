class mincost
{
	static int min(int x,int y,int z)
	{
		if(x<y)
		{
			if(x<z)return x;
			return z;
		}
		else
		{
			if(y<z)return y;
			return z;
		}
	}

	static int mincostpath(int[][] arr)
	{
		int[][] temp=new int[3][3];
		temp[0][0]=arr[0][0];
		for(int i=1;i<3;i++)
		{
			temp[i][0]=temp[i-1][0]+arr[i][0];
		}
		for(int j=1;j<3;j++)
		{
			temp[0][j]=temp[0][j-1]+arr[0][j];
		}
		for(int i=1;i<3;i++)
		{
			for(int j=1;j<3;j++)
			{
				temp[i][j]=arr[i][j]+min(arr[i-1][j],arr[i][j-1],arr[i-1][j-1]);
			}
		}
		return temp[2][2];
	}

	public static void main(String[] args)
	{
		int[][] arr=	{ {1, 2, 3},{4, 8, 2},{1, 5, 3} };
		System.out.println(mincostpath(arr));

	}
}