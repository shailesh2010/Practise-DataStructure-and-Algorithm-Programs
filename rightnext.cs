using System;
using System.Collections.Generic;

class Node
{
	public int data;
	public Node left;
	public Node right;
	public Node rightNext;
	public Node(int i)
	{
		data=i;
		left=null;
		right=null;
		rightNext=null;
	}
}

class Program
{
	static int indexptr=0;
	static void connect(Node n)
	{	Node p=n;
		if(p==null)return;
		
		while(p!=null)
		{	
			Node a=p;
			while(a!=null)
			{
				if(a.left!=null)
				{
					if(a.right!=null)
					{
						a.left.rightNext=a.right;
					}
					else
					{
						a.left.rightNext=getNextRight(a);
					}
				}
				if(a.right!=null)
				{
					a.right.rightNext=getNextRight(a);
				}
				a=a.rightNext;
			}
			if(p.left!=null)p=p.left;
			else if(p.right!=null)p=p.right;
			else p=getNextRight(p);
		}
		// if(n.left!=null)
		// {
		// 	n.left.rightNext=n.right;
		// }
		// if(n.right!=null)
		// {
		// 	n.right.rightNext=(n.rightNext!=null)?n.rightNext.left:null;
		// }
		// connect(n.left);
		// connect(n.right);
	}

	static Node getNextRight(Node n)
	{
		if(n==null)return null;
		Node temp=n.rightNext;
		while(temp!=null)
		{
			if(temp.left!=null)
			return temp.left;
			else if(temp.right!=null)
			return temp.right;
			else temp=temp.rightNext;
		}
		return null;
	}

	static void InorderRight(Node n)
	{
		if(n==null)
		return;
		Node next=null;
		_InorderRight(n,next);
	}

	static void _InorderRight(Node n,Node next)
	{
		if(n!=null)
		{
			_InorderRight(n.right,next);
			n.rightNext=next;
			next=n;
			_InorderRight(n.left,next);	
		}
		
	}

	static void PrintInorder(Node n)
	{
		if(n==null)return;
		Node temp=getLeftMost(n);
		while(temp!=null)
		{
			Console.WriteLine(temp.data);
			temp=temp.rightNext;
		}
	}
	static Node getLeftMost(Node n)
	{
		Node temp=n;
		while(temp.left!=null)
		{
			temp=temp.left;
		}
		return temp;
	}
	static void printRightNext(Node n)
	{
		if(n==null)return;
		Console.WriteLine("node data={0} rightnext data={1} ",n.data,(n.rightNext!=null)? n.rightNext.data.ToString():"no rightnext data");
		printRightNext(n.left);
		printRightNext(n.right);
	}

	static int ConvertToSumTree(Node n)
	{
		if(n==null) return 0;
		int old_data=n.data;
		n.data=ConvertToSumTree(n.left) + ConvertToSumTree(n.right);
		return old_data;
	}

	static void Inorder(Node n)
	{
		if(n==null)return;
		Inorder(n.left);
		Console.WriteLine(n.data);
		Inorder(n.right);
	}

	static void VerticalSum(Node n)
	{
		if(n==null)return;
		Dictionary<int,int> d=new Dictionary<int,int>();
		_VerticalSum(n,0,d);
		foreach(var v in d)
		{
			Console.WriteLine("Length is: {0} and  Sum is {1} ",v.Key,v.Value);
		}
	}

	static void _VerticalSum(Node n,int i,Dictionary<int,int> d)
	{
		if(n==null)return;
		_VerticalSum(n.left,i-1,d);
		if(d.ContainsKey(i))
		{
			int prev=d[i];
			d[i]=prev+n.data;
		}
		else
		{
			d.Add(i,n.data);
		}
		_VerticalSum(n.right,i+1,d);
	}

	static void PreOrderSpecialTree(int[] a,char[] b)
	{
		int index=0;
		Node root= _PreOrderSpecialTree(a,b,index);
		Inorder(root);

	}

	static Node _PreOrderSpecialTree(int[] a,char[] b,int index)
	{
		if(index==a.Length)return null;
		Node n=new Node(a[index]);
		indexptr=index;
		indexptr++;
		if(b[index]=='N')
		{
			n.left=_PreOrderSpecialTree(a,b,indexptr);
			n.right=_PreOrderSpecialTree(a,b,indexptr);
		}
		return n;
	}

	// static bool isCompleteBinaryTree(Node n)
	// {
	// 	if(n==null)return true;
	// 	Queue<Node> q=new Queue<Node>();
	// 	q.Enqueue(n);
	// 	bool status=false;
	// 	while(q.Count>0)
	// 	{
	// 		if(q.left!=null)
	// 		{
	// 			if(status=true)
	// 				return false;
	// 			q.Enqueue(n.left);
	// 		}
	// 		else
	// 			status=true;

	// 		if(q.right!=null)
	// 		{
	// 			if(status=true)
	// 				return false;
	// 			q.Enqueue(q.right);
	// 		}
	// 		else
	// 			status=true;
	// 	}
	// 	return true;

	// }

	static void PrintBoundary(Node n)
	{
		if(n==null)return;
		Console.WriteLine(n.data);
		LeftBoundary(n.left);
		PrintLeaves(n.left);
		PrintLeaves(n.right);
		RightBoundary(n.right);
		
	}

	static void LeftBoundary(Node n)
	{
		if(n==null)return;
		if(n.left!=null)
		{
			Console.WriteLine(n.data);
			LeftBoundary(n.left);
		}
		else if(n.right !=null)
		{
			Console.WriteLine(n.data);
			LeftBoundary(n.right);
		}

		
	}
	static void RightBoundary(Node n)
	{
		if(n==null)return;
		if(n.right!=null)
		{
			Console.WriteLine(n.data);
			RightBoundary(n.right);
		}
		else if(n.left!=null)
		{
			Console.WriteLine(n.data);
			RightBoundary(n.left);
		}
	}
	static void PrintLeaves(Node n)
	{
		if(n==null)return;
		if(n.left==null && n.right==null)
		{
			Console.WriteLine(n.data);
			return;
		}
		PrintLeaves(n.left);
		PrintLeaves(n.right);
	}

	static void IterativePreOrderTraversal(Node n)
	{
		if(n==null)return;
		Stack<Node> s=new Stack<Node>();
		s.Push(n);
		while(s.Count>0)
		{
			Node temp= s.Pop();
			Console.WriteLine(temp.data);
			if(temp.right!=null)
			s.Push(temp.right);
			if(temp.left!=null)
			s.Push(temp.left);
		}
	}

	static void MorrisInOrderTraversal(Node n)
	{
		if(n==null)return;
		Node current=n;
		Node prev=null;
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

	static void MorrisPreOrderTraversal(Node n)
	{
		if(n==null)return;
		Node current=n;
		Node prev=null;
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
					Console.WriteLine(current.data);
					prev.right=current;
					current=current.left;
				}
				else
				{
					prev.right=null;
					current=current.right;
				}
			}
		}
	}

	static void Main()
	{
		// int[] a={10, 30, 20, 5, 15};
		// char[] b={'N', 'N', 'L', 'L', 'L'};
		// PreOrderSpecialTree(a,b);
		// Node root=new Node(1);
		// root.left=new Node(2);
		// root.right=new Node(3);
		// root.left.left=new Node(4);
		// root.left.right=new Node(5);
		// root.right.left=new Node(6);
		// root.right.right=new Node(7);
		Node root=new Node(20);
		root.left=new Node(8);
		root.right=new Node(22);
		root.right.right=new Node(25);
		root.left.left=new Node(4);
		root.left.right=new Node(12);
		root.left.right.left=new Node(10);
		root.left.right.right=new Node(14);
		//MorrisInOrderTraversal(root);
		MorrisPreOrderTraversal(root);
		//IterativePreOrderTraversal(root);
		//PrintBoundary(root);
		// VerticalSum(root);
		// root.left.left.left=new Node(8);
		// root.left.left.right=new Node(9);
		// root.right.right.left=new Node(10);
		// root.right.right.right=new Node(11);
		// ConvertToSumTree(root);
		// Inorder(root);
		//connect(root);
		//InorderRight(root);
		//PrintInorder(root);
		//printRightNext(root);
	}
}