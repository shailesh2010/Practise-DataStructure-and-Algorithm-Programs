using System;
using System.Collections.Generic;
class Program
{

	static void FindPair(int[] arr,int i)
	{
		int[] a1=arr;

		Array.Sort(a1);
		int j=0,k=arr.Length-1;
		while(j<k)
		{
			if(a1[j]+a1[k]==i)
			{
				Console.WriteLine("pairs are {0}  {1} ",a1[j],a1[k]);
				break;
			}
			else if(a1[j]+a1[k]<i)j++;
			else k--;
		}
	}

	static void FindHashPair(int[] arr, int i)
	{
		Dictionary<int,bool> d=new Dictionary<int,bool>();
		foreach(int j in arr)
		{
			if(d.ContainsKey(j))
			{
				Console.WriteLine("{0} {1}",j,i-j);
				break;
			}
			else
			{
				d[i-j]=true;
			}
		}
	}

	static int GetOddOccurence(int[] arr)
	{
		int res=0;
		foreach(int i in arr)
		{
			res=res^i;
		}
		return res;
	}

	static int MaximumContiguousSubArray(int[] arr)
	{
		int curr_max=arr[0];
		int max_so_far=arr[0];
		for(int i=1;i<arr.Length;i++)
		{
			curr_max=Math.Max(arr[i],curr_max+arr[i]);
			max_so_far=Math.Max(curr_max,max_so_far);
		}
		return max_so_far;
	}

	static int PivotedElementSearch(int[] arr,int i)
	{
		int pivot=FindPivot(arr,0,arr.Length-1);
		if(i==arr[pivot])return i;
		if(arr[0]<i)
		{
			return BinarySearch(arr,i,0,pivot-1) ;
		}
		else
			return BinarySearch(arr,i,pivot+1,arr.Length-1);
	}

	static int FindPivot(int[] arr,int low, int high)
	{
		if(low>high)return int.MinValue;
		if(low==high)return low;
		int mid=(low+high)/2;
		if(mid<high &&arr[mid]>arr[mid+1])
			return mid;
		if(mid>low && arr[mid]<arr[mid-1])
			return mid-1;
		 if(arr[low]>=arr[mid])
			return FindPivot(arr,low,mid-1);
		else
			return FindPivot(arr,mid+1,high);
	}

	static int BinarySearch(int[] arr,int i,int low,int high)
	{
		if(low>high)return int.MinValue;
		int mid=(low+high)/2;
		if(arr[mid]==i)
			return mid;
		if(i<arr[mid])
			return BinarySearch(arr,i,low,mid-1);
		else return BinarySearch(arr,i,mid+1,high);
	}

	static int GetMedian(int[] a,int[] b)
	{
		int i=0;int j=0;
		int m1=int.MinValue;
		int m2=int.MinValue;
		int count=a.Length;
		for(int k=0;k<=count;k++)
		{
			if(i==count)
			{
				m1=m2;
				m2=b[0];
				break;
			}
			else if(j==count)
			{
				m1=m2;
				m2=a[0];
				break;
			}
			else if(a[i]<b[j])
			{
				m1=m2;
				m2=a[i];
				i++;
			}
			else
			{
				m1=m2;
				m2=b[j];
				j++;
			}
		}
		return (m1+m2)/2;
	}

	static int Method2GetMedian(int[] a,int[] b,int starta,int enda,int startb,int endb,int n)
	{
		if(n==0)return int.MinValue;
		if(n==1)return (a[starta]+b[startb])/2;
		if(n==2)return (Math.Max(a[starta],b[startb])+Math.Min(a[enda],b[endb]))/2;
		int m1,m2;
		m1=Median(a,starta,enda);
		m2=Median(b,starta,enda);
		if(m1==m2)return m1;
		else if(m1<m2)
		{
			if(n%2==0)
				return Method2GetMedian(a,b,starta,starta+n/2,startb+(n/2-1),endb,n/2+1);
			else
				return Method2GetMedian(a,b,starta,starta+n/2,startb+n/2,endb,n/2);
		}
		else
		{
			if(n%2==0)
				return Method2GetMedian(a,b,starta+n/2,enda,startb,startb+(n/2-1),n/2+1);
			else
				return Method2GetMedian(a,b,starta+n/2,enda,startb,startb+(n/2),n/2);
		}
	}

	static int Median(int[] a,int start,int end)
	{
		int n=start+end+1;
		if(n%2==0)return (a[n/2-1]+a[n/2])/2;
		else
			return (a[n/2])/2;
	}

	static void Rotate(int[] arr,int d)
	{
		int i,temp,j,k;
		for(i=0;i<GCD(arr.Length,d);i++)
		{
			temp=arr[i];
			j=i;
			while(true)
			{
				k=j+d;
				if(k>=arr.Length)
					k=k-arr.Length;
				if(k==i)break;
				arr[j]=arr[k];
				j=k;
			}
			arr[j]=temp;
		}
	}

	static int GCD(int a, int b)
	{
		if(b==0)return a;
		return GCD(b,a%b);
	}

	static void BlockRotate(int[] arr,int d)
	{
		int i=d;
		int j=arr.Length-i;
		while(i!=j)
		{
			if(i<j)
			{
				swap(arr,d-i,d+j-i,i);
				j=j-i;
			}
			else
			{
				swap(arr,d-i,d,j);
				i=i-j;
			}
		}
		swap(arr,d-i,d,i);
	}

	static void swap(int[] arr,int si,int fi,int d)
	{
		int temp;
		for(int i=0;i<d;i++)
		{
			temp=arr[si+i];
			arr[si+i]=arr[fi+i];
			arr[fi+i]=temp;
		}
	}

	static int FindMaxSum(int[] arr)
	{
		int inc=arr[0];
		int exc=0;
		int exc_new;
		for(int i=1;i<n;i++)
		{	
			exc_new=Math.Max(inc,exc);
			inc=exc+arr[i];
			exc=exc_new;
		}
		return Math.Max(inc,exc);
	}

	static void Main()
	{
		int[] arr=new int[]{1, 2,3,4,5,6};
		int[] arr1=new int[]{2, 13, 17, 30, 45};
		Rotate(arr,2);
		
		//Console.WriteLine(Method2GetMedian(arr,arr1,0,arr.Length,0,arr1.Length, arr.Length));
		//Console.WriteLine(GetMedian(arr,arr1));
		//Console.WriteLine(PivotedElementSearch(arr,2));
		//Console.WriteLine(MaximumContiguousSubArray(arr));
		//FindPair(arr,0);
		//FindHashPair(arr,0);
	}
}