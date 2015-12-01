class lis
{
	static int lismethod(int[] arr)
	{
		int n=arr.length;
		int[] temp=new int[n];
		for(int i=0;i<n;i++)
		{
			temp[i]=1;
		}
		for(int i=1;i<n;i++)
		{
			for(int j=0;j<i;j++)
			{
				if(arr[j] <arr[i] && temp[j]+1>temp[i])
					temp[i]=temp[j]+1;
			}
		}
		int max=0;
		for(int i=0;i<n;i++)
		{
			if(temp[i]>max)
				max=temp[i];
		}
		return max;
	}

	public static void main(String[] args) {
		int[] arr={10, 22, 9, 33, 21, 50, 41, 60};
		System.out.println(lismethod(arr));
	}
}