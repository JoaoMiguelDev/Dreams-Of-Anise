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
			AudioManager.Instance.StopAll();
			AudioManager.Instance.PlayBadEndingSong();
			FinalMessage.Position = new Vector2(166,158);
			FinalMessage.Text = "Anise did't come back...";
		}
		else if(ToyQuantity == 6)
		{
			AudioManager.Instance.StopAll();
			AudioManager.Instance.PlayGoodEndingSong();
			FinalMessage.Position = new Vector2(199,158);
			FinalMessage.Text = "Anise came back...";
		}
		else
		{
			FinalMessage.Position = new Vector2(199,158);
			FinalMessage.Text = "Anise came back?";
		}
	}
}
