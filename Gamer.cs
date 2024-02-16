using System;

public class Gamer
{
	string name;
	int capital;
	public string Name
	{
		get { return name; }
		set { name = value; }
	}
	public int Capital
	{
		get { return capital; }
		set { capital = value; }
	}
	public void UpgrateCapital(int value)
	{
		capital += value;
	}
}
