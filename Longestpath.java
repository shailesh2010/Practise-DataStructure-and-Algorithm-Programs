import java.util.*;

class ListNode
{
	private int dest;
	private int weight;
	public ListNode(int dest,int weight)
	{
		this.dest=dest;
		this.weight=weight;
	}

	public int getdest()
	{
		return dest;
	}

	public int getweight()
	{
		return weight;
	}

}

class Graph
{
	int v;
	List<ListNode>[] l;
	public Graph(int v)
	{
		this.v=v;
		l=new ArrayList[v];
		for(int i=0;i<v;i++)
		{
			l[i]=new ArrayList<ListNode>();
		}
	}

	public void addEdge(int src,int dest,int weight)
	{
		l[src].add(new ListNode(dest,weight));
	}

	public void topologicalsortmethodutil(int i,boolean[] visited,Stack<Integer> stack)
	{
		visited[i]=true;
		for(ListNode li: l[i])
		{
			if(visited[li.getdest()]==false)
			{
				topologicalsortmethodutil(li.getdest(),visited,stack);
			}
		}
		stack.push(i);
	}

	public void topologicalsortmethod()
	{
		boolean[] visited=new boolean[v];
		Integer[] distance=new Integer[v];
		for(int i=0;i<v;i++)
		{
			visited[i]=false;
		}

		for(int i=0;i<v;i++)
		{
			distance[i]=Integer.MIN_VALUE;
		}
		distance[1]=0;
		Stack<Integer> stack=new Stack<Integer>();
		for(int i=0;i<v;i++)
		{
			if(visited[i]==false)
				topologicalsortmethodutil(i,visited,stack);
		}
		while(!stack.empty())
		{
			int popped=stack.pop();
			if(distance[popped] != Integer.MIN_VALUE)
			{
				for(ListNode li : l[popped])
				{
					if(distance[li.getdest()]<distance[popped]+li.getweight())
						distance[li.getdest()]=distance[popped]+li.getweight();

				}
			}
		}

		for(int i=0;i<v;i++)
		{
			System.out.println((distance[i]==Integer.MIN_VALUE)?"INF": distance[i]);
		}

	}
}

class Longestpath
{
	public static void main(String[] args) 
	{
		Graph g=new Graph(6);
		g.addEdge(0, 1, 5);
		g.addEdge(0, 2, 3);
		g.addEdge(1, 3, 6);
		g.addEdge(1, 2, 2);
		g.addEdge(2, 4, 4);
		g.addEdge(2, 5, 2);
		g.addEdge(2, 3, 7);
		g.addEdge(3, 5, 1);
		g.addEdge(3, 4, -1);
		g.addEdge(4, 5, -2);
		g.topologicalsortmethod();	
	}
}