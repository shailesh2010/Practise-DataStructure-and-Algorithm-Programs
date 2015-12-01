#include <stdio.h>

void printarray(int arr[],int n)
{
	for(int i=0;i<n;i++)
	{
		printf("%d \t",arr[i] );
	}
	printf("\n");
}



void insertionsort(int arr[],int n)
{
	for(int i=0;i<n;i++)
	{
		int key=arr[i];
		int j=i-1;
		while(j>=0 && arr[j]>key)
		{
			arr[j+1]=arr[j];
			j=j-1;
		}
		arr[j+1]=key;
	}
}

int main()
{
	int arr[]={32,11,25,6,77,2};
	int n=sizeof(arr)/sizeof(arr[0]);
	printarray(arr,n);
	insertionsort(arr,n);
	printarray(arr,n);
	return 0;
}