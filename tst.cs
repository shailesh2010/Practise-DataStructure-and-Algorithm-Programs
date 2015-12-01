using System;

class TriNode
{
	public char data;
	public TriNode small;
	public TriNode equal;
	public TriNode large;
	public bool end;
	public TriNode(char data)
	{
		this.data=data;
		small=null;
		equal=null;
		large=null;
		end=false;
	}
}

class Program
{
	public static char[] c=new char[5];
	static TriNode Add(TriNode n,string s,int pos)
	{
		if(n==null)
		{
			n=new TriNode(s[pos]);
		}
		if(s[pos]<n.data)
		{
			n.small=Add(n.small,s,pos);
		}
		else if(s[pos]>n.data)
		{
			n.large=Add(n.large,s,pos);
		}
		else
		{
			if(pos<s.Length-1)
			{
				n.equal=Add(n.equal,s,++pos);
			}
			else
			{
				n.end=true;
			}
		}
		return n;
	}

	static bool Search(TriNode n, string s)
	{
		if(String.IsNullOrEmpty(s))return true;
		if(n==null)return false;
		int pos=0;
		TriNode current=n;
		while(current!=null)
		{
			if(s[pos]<current.data)
			{
				current=current.small;
			}
			else if(s[pos]>current.data)
			{
				current=current.large;
			}
			else
			{
				
				pos++;
				if(pos==s.Length && current.end==true)
				{
					return true;

				}
				current=current.equal;
				
			}
		}
		return false;
	}

	static void Traverse(TriNode n,int depth)
	{
		if(n!=null)
		{
			Traverse(n.small,depth);
			c[depth]=n.data;
			if(n.end)
			{
				c[depth+1]='\0';
				//Print(c);
				Console.WriteLine(new string(c));
			}
			Traverse(n.equal,depth+1);
			Traverse(n.large,depth);
		}
	}
	// static void Print(char[] c)
	// {
	// 	int i=0;
	// 	while(c[i]!='\0')
	// 	{
	// 		Console.Write(c[i]);
	// 		i++;
	// 	}
	// }
	

	static void Main()
	{
		TriNode root=null;
		root=Add(root,"cat",0);
		Add(root,"cab",0);
		Add(root,"bug",0);
		if(Search(root,"caddd"))
		{
			Console.WriteLine("found");
		}
		else
		{
			Console.WriteLine("not found");
		}
		Traverse(root,0);
		// Console.WriteLine(root.data);
		// Console.WriteLine(root.equal.data);
		// Console.WriteLine(root.equal.equal.data);
		// Console.WriteLine(root.equal.equal.small.data);
		// Console.WriteLine(root.small.data);
		// Console.WriteLine(root.small.equal.data);

	}
}