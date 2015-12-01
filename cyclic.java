import java.util.*;

class Graph
{
	private int v;
	//public LinkedList myLinkList[];
	public LinkedList<Integer>[] myLinkList;
	public Graph(int size)
	{
		v=size;
		myLinkList= new LinkedList[size];
		//l=new LinkedList[size];
		 for(int i=0;i<size;i++)
		 {
		 	myLinkList[i]=new LinkedList<Integer>();
		 }
	}

	public void addEdge(int src,int dest)
	{
		myLinkList[src].add(dest);
	}

	public void print()
	{

	}
}

class cyclic
{
	public static void main(String[] args) {
		Graph g=new Graph(5);
		g.addEdge(0,1);
		System.out.println(g.myLinkList[0]);
	}
}