import java.util.*;
class Graph
{
	public void setEdge(HashMap<Integer,ArrayList<Integer>> map,int src,int dest)
	{
		map.get(src).add(dest);
		//map.get(dest).add(src);
	}

	public int find(int[] parent,int src)
	{
		if(parent[src]==-1)return src;
		else return find(parent,parent[src]);
	}

	public void union(int[] parent,int x,int y)
	{
		int xset=find(parent,x);
		int yset=find(parent,y);
		parent[xset]=yset;
	}

	public boolean iscyclic(HashMap<Integer,ArrayList<Integer>> map)
	{
		int[] parent =new int[map.size()];
		for (int i=0;i<map.size() ;i++ )
		{
			parent[i]=-1;	
		}
		for(Map.Entry<Integer,ArrayList<Integer>> entry: map.entrySet())
		{
			for(Integer i : entry.getValue())
			{
				int x=find(parent,i);
				int y=find(parent,entry.getKey());
				if(x==y)return true;
				union(parent,x,y);
			}
		}
		return false;
	}

	public boolean undirectedcyclic_util(HashMap<Integer,ArrayList<Integer>> map,boolean[] visited,int src,int parent)
	{
		visited[src]=true;
			for(Integer i: map.get(src))
			{
				if(visited[i]==false)
				{
					 if(undirectedcyclic_util(map,visited,i,src))
					 	return true;
				}
				else if(i!=parent)
				{
					return true;
				}
			}

		return false;
	}

	public boolean undirectedcyclic(HashMap<Integer,ArrayList<Integer>> map)
	{
		boolean[] visited=new boolean[map.size()];
		for(int i=0;i<map.size();i++)
		{
			visited[i]=false;
		}
		for(Map.Entry<Integer,ArrayList<Integer>> entry : map.entrySet())
		{
			if(visited[entry.getKey()]==false)
			{
				if(undirectedcyclic_util(map,visited,entry.getKey(),-1)==true)
					return true;
			}

		}
		return false;
	}
}

class ufcyclic
{
	public static void main(String[] args) 
	{
		HashMap<Integer,ArrayList<Integer>> map=new HashMap<Integer,ArrayList<Integer>>();
		for(int i=0;i<5;i++)
		{
			map.put(i,new ArrayList<Integer>());
		}
		Graph g=new Graph();
		g.setEdge(map,0,1);
		g.setEdge(map,0, 4);
		g.setEdge(map,1, 2);
    	g.setEdge(map,1, 3);
    	//g.setEdge(map,4, 1);
    	//g.setEdge(map,2, 3);
    	//g.setEdge(map,3, 4);
    	//System.out.println(map.get(1));
    	//g.ufCyclic(map);
		if(g.undirectedcyclic(map))
		{
			System.out.println("Cyclic");
		}	
		else
		{
			System.out.println("Acyclic");
		}
	}	
}