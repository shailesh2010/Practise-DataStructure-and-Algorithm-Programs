import java.util.*;
import java.io.*;
import java.lang.*;

class Graph
{
	public void setEdge(HashMap<Integer,ArrayList<Integer>> map,int src,int dest)
	{
		map.get(src).add(dest);
		//map.get(dest).add(src);
	}

	public void bfs(HashMap<Integer,ArrayList<Integer>> map,Queue<Integer> q)
	{
		boolean[] visited=new boolean[map.size()];
		for(int i=0;i<map.size();i++)
		{
			visited[i]=false;
		}
		while(!q.isEmpty())
		{	int src=q.remove();
			while(visited[src]==true)
			{
				if(!q.isEmpty())
				{
					src=q.remove();
				}
				else
				{
					return;
				}
			}
			
			visited[src]=true;
			ArrayList<Integer> temp=map.get(src);
			for(int j: temp)
			{
				if(visited[j]==false)
				{
					q.add(j);
				}
			}
			System.out.println(src);
		}
	}

	public void dfs_rec(HashMap<Integer,ArrayList<Integer>> map,boolean[] visited,int src)
	{
		visited[src]=true;
		System.out.println(src);
		for(int i: map.get(src))
		{
			if(visited[i]==false)
				dfs_rec(map,visited,i);
		}
	}

	public void dfs(HashMap<Integer,ArrayList<Integer>> map,int src)
	{
		boolean[] visited=new boolean[map.size()];
		for(int i=0;i<map.size();i++)
		{
			if(visited[src]==false)
				dfs_rec(map,visited,src);
		}
	}

	public boolean isCyclicUtil(HashMap<Integer,ArrayList<Integer>> map,int src,boolean[] visited,boolean[] recstack)
	{
		if(visited[src]==false)
		{
			visited[src]=true;
			recstack[src]=true;
			ArrayList<Integer> a=map.get(src);
			for(int i: a)
			{
				if(visited[i]==false)
				{
					if(isCyclicUtil(map,i,visited,recstack))return true;
				}
				else if(recstack[i])
					return true;

			}
		}
		recstack[src]=false;
		return false;
	}

	public boolean isCyclic(HashMap<Integer,ArrayList<Integer>> map,int src)
	{
		boolean[] visited=new boolean[map.size()];
		boolean[] recstack=new boolean[map.size()];
		// for(int i=0;i<map.size();i++)
		// {
		// 	visited[i]=false;
		// 	recstack[i]=false;
		// }
		for(int i=0;i<map.size();i++)
		{
			if(isCyclicUtil(map,i,visited,recstack))
				return true;
		}
		return false;
	}

	public void ufCyclic(HashMap<Integer,ArrayList<Integer>> map)
	{
		HashMap<Integer,Integer> ve=new HashMap<Integer,Integer>();
		for(Map.Entry<Integer,ArrayList<Integer>> entry: map.entrySet())
		{
			int key=entry.getKey();
			List<Integer> value=entry.getValue();
			for(Integer i: value)
			{
				ve.put(key,i);
			}
		}
		for(Map.Entry<Integer,Integer> j: ve.entrySet())
		{
			int key=j.getKey();
			int value=j.getValue();
			System.out.println(key+""+value);
		}

	}

	public boolean method3cyclic(HashMap<Integer,ArrayList<Integer>> map)
	{
		
	}

	public static void main(String[] args) 
	{
		HashMap<Integer,ArrayList<Integer>> map=new HashMap<Integer,ArrayList<Integer>>();
		Queue<Integer> q=new LinkedList<Integer>();
		for(int i=0;i<5;i++)
		{
			map.put(i,new ArrayList<Integer>());
		}
		q.add(0);
		Graph g=new Graph();
		g.setEdge(map,0,1);
		g.setEdge(map,0, 4);
		g.setEdge(map,1, 2);
    	g.setEdge(map,1, 3);
    	//g.setEdge(map,4, 1);
    	g.setEdge(map,2, 3);
    	g.setEdge(map,3, 4);
    	//System.out.println(map.get(1));
    	//g.ufCyclic(map);
		if(g.isCyclic(map,0))
			System.out.println("Cyclic ");
		else
			System.out.println("Acyclic");
    	
    	// g.dfs(map,0);
    	//System.out.println(map.get(3));
	}
}

