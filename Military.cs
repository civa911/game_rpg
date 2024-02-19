using System;

public class Military
{
	protected int HP = 100;
	protected int Attack = 15;
	protected int Defence = 5;
	protected int Dodge = 3;

	public void RenewalHP(int damage)
	{
		HP -= damage;
		
	}
}

public class LightInfantry : Military
{
	public LightInfantry()
	{
		Attack = 30;
		Defence = 10;
		Random random = new Random();
		Dodge = random.Next(4, Attack);
	}

	
}

public class HeavyInfantry : Military
{
	public HeavyInfantry()
	{
		Attack = 40;
		Defence = 15;
		Dodge = 5;
		Random random = new Random();
		Dodge = random.Next(6, Attack);
	}

	
}
/*/ class Program
{
	static void Main(string[] args)
	{
		Military militaryUnit = new Military();
		LightInfantry lightUnit = new LightInfantry();
		HeavyInfantry heavyUnit = new HeavyInfantry();

		militaryUnit.RenewalHP(10);
		lightUnit.RenewalHP(20);
		heavyUnit.RenewalHP(30);
	}
} /*/