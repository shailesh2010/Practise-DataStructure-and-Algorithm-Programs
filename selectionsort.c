#include <stdio.h>

void printarray(int arr[],int n)
{
	for(int i=0;i<n;i++)
	{
		printf("%d \t",arr[i] );
	}
	printf("\n");
}


void swap(int *i,int *min)
{
	int temp=*i;
	*i=*min;
	*min=temp;
}


void selectionsort(int arr[],int n)
{
	for (int i=0;i<n;i++)
	{
		int min_index=i;
		for(int j=i+1;j<n;j++)
		{
			if(arr[j]<arr[min_index])
				min_index=j;
		}
		swap(&arr[i],&arr[min_index]);
	}
}
int main()
{
	int arr[]={34,11,25,6,77,2};
	int n=sizeof(arr)/sizeof(arr[0]);
	printarray(arr,n);
	selectionsort(arr,n);
	printarray(arr,n);
	return 0;
}




