using System;

public class Node
{
	public int data;
	public Node small;
	public Node large;
	public Node(int i)
	{
		data=i;
		small=null;
		large=null;
	}
}

public class TreeList
{
	public static void treeInsert(Node n,int i)
	{
		if(n==null)return;
		if(i<=n.data)
		{
			if(n.small!=null)treeInsert(n.small,i);
			else n.small=new Node(i);
		}
		else
		{
			if(n.large != null)treeInsert(n.large,i);
			else n.large=new Node(i);
		}
	}

	public static void printTree(Node n)
	{
		if(n==null)return;
		printTree(n.small);
		Console.Write(n.data+" ");
		printTree(n.large);
	}

	public static void join(Node a,Node b)
	{
		a.large=b;
		b.small=a;
	}

	public static Node append(Node a,Node b)
	{
		if(a==null)return b;
		if(b==null)return a;
		Node aLast=a.small;
		Node bLast=b.small;
		join(aLast,b);
		join(bLast,a);
		return a;
	}

	public static Node treeToList(Node n)
	{
		if(n==null)return null;
		Node aList=treeToList(n.small);
		Node bList=treeToList(n.large);
		n.small=n;
		n.large=n;
		aList=append(aList,n);
		aList=append(aList,bList);
		return aList;

	}

	public static void printList(Node n)
	{
		if(n==null)return;
		Node current=n;
		while(current.large!=n)
		{
			Console.WriteLine("");
			Console.Write(current.data+" ");
			current=current.large;
		}
		Console.Write(current.data);
		Console.WriteLine("");
	}

	static void Main()
	{
		Node root=new Node(4);
		treeInsert(root,1);
		treeInsert(root,2);
		treeInsert(root,3);
		treeInsert(root,5);
		printTree(root);
		Node head=treeToList(root);
		printList(head);
	}
}