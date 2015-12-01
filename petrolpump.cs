using System;

class PetrolDistance
{
	public int petrol;
	public int distance;
	public PetrolDistance(int a, int b)
	{
		petrol=a;
		distance=b;
	}
}


class Program
{
	static int  PetrolPumpNumber(PetrolDistance[] p,int n)
	{
		int start=0;
		int end=1;
		int current=p[start].petrol-p[start].distance;
		while(start !=end || current<0)
		{
			while(current<0 && start !=end)
			{
				current=current-(p[start].petrol-p[start].distance);
				start=(start+1)%n;
				if(start==0)
				return -1;
			}
			current=current+p[end].petrol-p[end].distance;
			end=(end+1)%n;
		}
		return start;
	}

	static void Main()
	{
		PetrolDistance[] p=new PetrolDistance[3];
		p[0]=new PetrolDistance(6,4);
		p[1]=new PetrolDistance(3,6);
		p[2]=new PetrolDistance(7,3);
		int start=PetrolPumpNumber(p,3);
		if(start==-1)
		{
			Console.WriteLine("No");
		}
		else
		{
			Console.WriteLine(start);
		}
		
	}
}