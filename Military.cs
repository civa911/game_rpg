using System;
using System.Collections.Generic;
using System.Linq;

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

public interface IMilitary
{
	int Health { get; set; }     // �������� ��� ��������� � ��������� �������� �����

	void TakeDamage(int damage);     // ����� ��� ��������� ����� �����

}

public class Soldier : IMilitary
{
    public int Health { get; set; } // ���������� �������� �������� �� ���������� IMilitary

    public Soldier(int initialHealth)  // ����������� ��� �������� ������� � ��������� ���������
    {
        Health = initialHealth;
    }

    public void TakeDamage(int damage) // ���������� ������ ��������� �����. ��������� �������� ����� �� �������� �����
    {
        Health -= damage;
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


public class Army
{
    public List<IMilitary> ListOfMilitary { get; private set; } = new List<IMilitary>(); // ������ ��� �������� ���� ������ � �����

    public void AddMilitary(IMilitary militaryUnit) // ���������� ����� � �����
    {
        ListOfMilitary.Add(militaryUnit);
    }

    public void DeleteMilitary(IMilitary militaryUnit)   // �������� ����� �� �����
    {
        ListOfMilitary.Remove(militaryUnit);
    }

    public void TakingDamage(IMilitary militaryUnit, int damage) // ����� ��� ��������� ����� ������������� �����
    {
        militaryUnit.TakeDamage(damage);
        DeathCheck(); // �������� �� ������� ������ ����� ��������� �����
    }

    private void DeathCheck() // ��������� ����� ��� �������� ������� ������ �� ������
    {
        ListOfMilitary = ListOfMilitary.Where(unit => unit.Health > 0).ToList();
    }
}


class Program
{
    static void Main(string[] args)
    {
        Army army = new Army();

        // ��������� ������ � �����
        army.AddMilitary(new Soldier(100));
        army.AddMilitary(new Soldier(150));

        Console.WriteLine("�������� ��������� �����:");
        PrintArmyStatus(army);

        // �������� � ��������� ����� ������� ����� � ������, ���� �� ����������
        if (army.ListOfMilitary.Count > 0)
        {
            army.TakingDamage(army.ListOfMilitary[0], 50);
        }

        Console.WriteLine("\n��������� ����� ����� �����:");
        PrintArmyStatus(army);
    }

    static void PrintArmyStatus(Army army) // ��������������� ����� ��� ������ ���������� � ��������� �����
    {
        foreach (var military in army.ListOfMilitary)
        {
            Console.WriteLine($"�������� �����: {military.Health}");
        }
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