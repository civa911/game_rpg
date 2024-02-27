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
	int Health { get; set; }     // Свойство для получения и установки здоровья юнита

	void TakeDamage(int damage);     // Метод для нанесения урона юниту

}

public class Soldier : IMilitary
{
    public int Health { get; set; } // Реализация свойства здоровья из интерфейса IMilitary

    public Soldier(int initialHealth)  // Конструктор для создания солдата с начальным здоровьем
    {
        Health = initialHealth;
    }

    public void TakeDamage(int damage) // Реализация метода получения урона. Уменьшает здоровье юнита на величину урона
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
    public List<IMilitary> ListOfMilitary { get; private set; } = new List<IMilitary>(); // Список для хранения всех юнитов в армии

    public void AddMilitary(IMilitary militaryUnit) // Добавление юнита в армию
    {
        ListOfMilitary.Add(militaryUnit);
    }

    public void DeleteMilitary(IMilitary militaryUnit)   // Удаление юнита из армии
    {
        ListOfMilitary.Remove(militaryUnit);
    }

    public void TakingDamage(IMilitary militaryUnit, int damage) // Метод для нанесения урона определенному юниту
    {
        militaryUnit.TakeDamage(damage);
        DeathCheck(); // Проверка на умерших юнитов после нанесения урона
    }

    private void DeathCheck() // Приватный метод для удаления мертвых юнитов из списка
    {
        ListOfMilitary = ListOfMilitary.Where(unit => unit.Health > 0).ToList();
    }
}


class Program
{
    static void Main(string[] args)
    {
        Army army = new Army();

        // Добавляем солдат в армию
        army.AddMilitary(new Soldier(100));
        army.AddMilitary(new Soldier(150));

        Console.WriteLine("Исходное состояние армии:");
        PrintArmyStatus(army);

        // Проверка и нанесение урона первому юниту в списке, если он существует
        if (army.ListOfMilitary.Count > 0)
        {
            army.TakingDamage(army.ListOfMilitary[0], 50);
        }

        Console.WriteLine("\nСостояние армии после атаки:");
        PrintArmyStatus(army);
    }

    static void PrintArmyStatus(Army army) // Вспомогательный метод для вывода информации о состоянии армии
    {
        foreach (var military in army.ListOfMilitary)
        {
            Console.WriteLine($"Здоровье юнита: {military.Health}");
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