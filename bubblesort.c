#include <stdio.h>
#include <stdbool.h>

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


void bubblesort(int arr[],int n)
{
	bool b=false;
	for(int i=0;i<n;i++)
	{
		for(int j=0;j<n;j++)
		{
			if(arr[j]>arr[j+1])
			{
				swap(&arr[j],&arr[j+1]);
				b=true;
			}
		}
		if(b==false)
			break;
	}
}

int main()
{
	int arr[]={3,11,25,6,77,2};
	int n=sizeof(arr)/sizeof(arr[0]);
	printarray(arr,n);
	bubblesort(arr,n);
	printarray(arr,n);
	return 0;
}