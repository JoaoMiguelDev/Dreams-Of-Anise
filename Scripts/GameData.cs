using Godot;
using System;

public partial class GameData : Node
{
	public static GameData Instance;
	public int ToyAmount { get ; private set; }  = 0;

    public override void _Ready()
    {
        Instance = this;
    }

	public void AddToy()
	{
		ToyAmount ++;
		GD.Print("Toy amount: "+ ToyAmount);
	}
	
}
