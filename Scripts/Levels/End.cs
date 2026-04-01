using Godot;
using System;

public partial class End : Node2D
{
	[Export] private Label FinalMessage;
	private int ToyQuantity; //= GameData.Instance.ToyAmount;
	public override void _Ready()
	{
		ToyQuantity = GameData.Instance.ToyAmount;
		HandleEnding();
	}

	private void HandleEnding()
	{
		if(ToyQuantity == 0)
		{
			FinalMessage.Text = "Anise did't come back...";
		}
		else if(ToyQuantity == 6)
		{
			FinalMessage.Text = "Anise did come back...";
		}
		else
		{
			FinalMessage.Text = "did Anise come back?";
		}
	}
}
