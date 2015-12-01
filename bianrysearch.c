#include <stdio.h>
void main()
{
	int arr[]={2,4,5,6,7,8,9};
	int n=sizeof(arr)/sizeof(arr[0]);
	printf("Enter number to search");
	int a;
	scanf("%d",&a);
	int result= iterative_binarysearch(arr,0,n,a);
	if(result==-1)
	{
		printf("Number not present");
	}
	else
	{
		printf("number present at %d",result);
	}
}

int recursive_binarysearch(int arr[],int l, int r, int key)
{
	if(l<=r)
	{
		int mid=(l+r)/2;
		if(arr[mid]==key)
			return mid;
		else if(arr[mid]>key)
			return recursive_binarysearch(arr,l,mid-1,key);
		else
			return recursive_binarysearch(arr,mid+1,r,key);
	}
	return -1;
}

int iterative_binarysearch(int arr[],int l, int r, int key)
{
	while(l<=r)
	{
		int mid=(l+r)/2;
		if(arr[mid]==key) return mid;
		else if(arr[mid]>key) r=mid-1;
		else l=mid+1;
	}
	return -1;
}

