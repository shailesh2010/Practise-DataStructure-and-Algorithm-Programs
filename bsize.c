#include <stdio.h>
#include <stdlib.h>

struct node
{
	int data;
	struct node *left;
	struct node *right;
};

struct node* createNode(int n)
{
	struct node *newNode=(struct node*)malloc(sizeof(struct node));
	newNode->data=n;
	newNode->left=NULL;
	newNode->right=NULL;
	return (newNode);
}

int size(struct node *node)
{
	if(node==NULL)
		return 0;
	else
		return (size(node->left) +1 +size(node->right));
}

int identicalTrees(struct node *root1,struct node *root2)
{
	if(root1==NULL && root2==NULL)
		return 1;
	if(root1 !=NULL && root2!=NULL)
	return root1->data==root2->data && identicalTrees(root1->left,root2->left) && identicalTrees(root1->right,root2->right);
 	return 0;
}

int height(struct node *root)
{
	if( root==NULL) return 0;
	int maxLeft=height(root->left);
	int maxRight=height(root->right);
	if(maxLeft>maxRight) 
		return 1+ maxLeft;
	else
		return 1+maxRight;
}

void deleteTree(struct node *root)
{
	if(root==NULL)return;
	deleteTree(root->left);
	deleteTree(root->right);
	printf("Deleted node = %d\n",root->data );
	free(root);
}

int main()
{
	struct node *root=createNode(1);
	root->left=createNode(2);
	root->right=createNode(3);
	root->left->left=createNode(4);
	root->left->right=createNode(5);
	/*
	struct node *root2=createNode(1);
	root2->left=createNode(2);
	root2->right=createNode(3);
	root2->left->left=createNode(4);
	root2->left->right=createNode(5);
	printf("%d\n", size(root));
	if(identicalTrees(root,root2))
		printf("Identicla trees\n");
	else
		printf("Not Identical\n");
		
	printf("Heightis %d\n", height(root));
	*/
	deleteTree(root);
	root=NULL;
	getchar();
	return 0;
}