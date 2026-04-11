using Godot;
using System;

public partial class GameData : Node
{
	public bool HasEntered = true;
	public static GameData Instance;
	public int ToyAmount { get ; private set; }  = 0;

    public override void _Ready()
    {
        Instance = this;
    }

	public bool FirstTimeEntering()
	{
		return HasEntered;
	}

	public void AddToy()
	{
		ToyAmount ++;
		GD.Print("Toy amount: "+ ToyAmount);
	}

	public void ResetToyAmount()
	{
		ToyAmount = 0;
	}
	
}
