using System;
using System.Collections.Generic;

class Node
{
	public int data;
	public Node left;
	public Node right;
	public Node(int i)
	{
		data=i;
		left=null;
		right=null;
	}
}

class Program
{

	static int treeSize(Node n)
	{
		if(n==null) return 0;
		return treeSize(n.left) + 1+ treeSize(n.right);
	}

	static void printPaths(Node n)
	{
		int[] arr=new int[10];
		_printPaths(n,arr,0);
	}

	static void _printPaths(Node n, int[] arr,int pathLength)
	{
		if(n==null)return;
		arr[pathLength++]=n.data;
		if(n.left==null && n.right==null)
		{
			printArray(arr,pathLength);
		}
		else
		{
			_printPaths(n.left,arr,pathLength);
			_printPaths(n.right,arr,pathLength);
		}
	}

	static void printArray(int[] arr,int len)
	{
		for(int i=0;i<len;i++)
		{
			Console.WriteLine(arr[i]+" ");
		}
	}

	static int getLeafCount(Node n)
	{
		if(n==null)return int.MinValue;
		if(n.left==null && n.right==null)
		return 1;
		return getLeafCount(n.left)+getLeafCount(n.right);
	}

	static void printSpiral(Node n)
	{
		if(n==null)return;
		Stack<Node> s1=new Stack<Node>();
		Stack<Node> s2=new Stack<Node>();
		s1.Push(n);
		while(s1.Count>0 || s2.Count>0)
		{
			while(s1.Count>0)
			{
				Node t=s1.Peek();
				s1.Pop();
				Console.WriteLine(t.data);
				if(t.right !=null)
					s2.Push(t.right);
				if(t.left!=null)
					s2.Push(t.left);
			}
				
			
			while(s2.Count>0)
			{
				Node t=s2.Peek();
				s2.Pop();
				Console.WriteLine(t.data);
				if(t.left!=null)
					s1.Push(t.left);
				if(t.right!=null)
					s1.Push(t.right);
				
			}
		}
	}

	static void convertTOChildrenSumProperty(Node n)
	{
		int left_data=0,right_data=0,diff;
		if(n==null || (n.left==null && n.right==null))return;
		convertTOChildrenSumProperty(n.left);
		convertTOChildrenSumProperty(n.right);
		if(n.left!=null)left_data=n.left.data;
		if(n.right!=null)right_data=n.right.data;
		diff=left_data+right_data-n.data;
		if(diff>0)n.data+=diff;
		else if(diff<0)increment(n,diff);
	}

	static void increment(Node n,int diff)
	{
		if(n.left!=null)
		{
			n.left.data+=(-diff);
			increment(n.left,diff);
		}
		else if(n.right!=null)
		{
			n.right.data+=(-diff);
			increment(n.right,diff);
		}
	}

	static void printInorder(Node n)
	{
		if(n==null)return;
		printInorder(n.left);
		Console.WriteLine(n.data);
		printInorder(n.right);
	}
	static int diameter(Node n)
	{
		if(n==null)return int.MinValue;
		int lheight=height(n.left);
		int rheight=height(n.right);
		int ldiameter=diameter(n.left);
		int rdiameter=diameter(n.right);
		return max(lheight+rheight+1,max(ldiameter,rdiameter));
	}
	static int height(Node n)
	{
		if(n==null)return 0;
		return 1+ max(height(n.left),height(n.right));
	}

	static int max(int a, int b)
	{
		return (a>b)?a:b;
	}

	static void inorderUsingStack(Node n)
	{
		if(n==null)return;
		Stack<Node> s=new Stack<Node>();
		Node current=n;
		bool b=true;
		while(b)
		{
			if(current!=null)
			{
				s.Push(current);
				current=current.left;
			}
			else
			{
				if(s.Count>0)
				{
					current=s.Pop();
					Console.WriteLine(current.data);
					current=current.right;
				}
				else
				{
					b=false;
				}
					
			}

		}
	}

	static void MorrisTraversal(Node n)
	{
		if(n==null)return;
		Node current=n;
		Node prev;
		while(current!=null)
		{
			if(current.left==null)
			{
				Console.WriteLine(current.data);
				current=current.right;
			}
			else
			{
				prev=current.left;
				while(prev.right!=null && prev.right!=current)
				{
					prev=prev.right;
				}
				if(prev.right==null)
				{
					prev.right=current;
					current=current.left;
				}
				else
				{
					prev.right=null;
					Console.WriteLine(current.data);
					current=current.right;
				}
			}
		}
	}

	static bool hasPAthSum(Node n,int sum)
	{
		if(n==null)return sum==0;
		int subSum=sum-n.data;
		bool b=false;
		if(subSum==0 && n.left==null && n.right==null)
		return true;
		if(n.left!=null)
			b=b|| hasPAthSum(n.left,subSum);
		if(n.right!=null)
			b=b|| hasPAthSum(n.right,subSum);
		return b;
	}

	static void doubleTree(Node n)
	{
		if(n==null)return ;
		doubleTree(n.left);
		doubleTree(n.right);
		Node temp=n.left;
		Node a=new Node(n.data);
		n.left=a;
		n.left.left=temp;
		
	}

	static void Main()
	{
		Node root=new Node(6);
		root.left=new Node(3);
		root.right=new Node(8);
		// root.left.left=new Node(1);
		// root.right.left=new Node(7);
		// root.right.right=new Node(11);
		// root.right.right.left=new Node(9);
		//MorrisTraversal(root);
		//Console.WriteLine(hasPAthSum(root,9));
		doubleTree(root);
		printInorder(root);
		//inorder(root);
		//Console.WriteLine(treeSize(root));
		//printPaths(root);
		//Console.WriteLine(getLeafCount(root));
		//printSpiral(root);
		//convertTOChildrenSumProperty(root);
		//Console.WriteLine(diameter(root));
		//printInorder(root);
		//inorderUsingStack(root);

	}
}