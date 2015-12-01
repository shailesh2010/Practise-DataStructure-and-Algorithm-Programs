#include <stdio.h>

void printarray(int arr[],int n)
{
	for(int i=0;i<n;i++)
	{
		printf("%d \t",arr[i] );
	}
	printf("\n");
}

void merge(int arr[],int l, int m , int r)
{
	int i,j,k;
	int n1,n2;
	n1=m-l+1;
	n2=r-m;
	int L1[n1],L2[n2];
	for(i=0;i<n1;i++)
	{
		L1[i]=arr[l+i];
	}
	for(j=0;j<n2;j++)
	{
		L2[j]=arr[m+j+1];
	}

	i=0;j=0;k=l;
	while(i<n1 && j<n2)
	{
		if(L1[i]<=L2[j])
		{
			arr[k]=L1[i];
			i++;
		}
		else
		{
			arr[k]=L2[j];
			j++;
		}

		k++;
	}

	while(i<n1)
	{
		arr[k]=L1[i];
			i++;
			k++;
	}

	while(j<n2)
	{
		arr[k]=L2[j];
			j++;
			k++;
	}
}

void mergesort(int arr[], int l, int r)
{
	if(l<r)
	{
		int m=l+(r-l)/2;
		mergesort(arr,l,m);
		mergesort(arr,m+1,r);
		merge(arr,l,m,r);
	}
}

int main()
{
	int arr[]={32,11,25,6,77,2};
	int n=sizeof(arr)/sizeof(arr[0]);
	printarray(arr,n);
	mergesort(arr,0,n-1);
	printarray(arr,n);
	return 0;
}