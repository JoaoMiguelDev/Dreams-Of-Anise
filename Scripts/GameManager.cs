using Godot;
using System;

public partial class GameManager : Node
{
	[Export] private Level Lvl;
	[Export] private Anise Player;
	private int LvlId;
	private int NumOfActions;
	public override void _Ready()
	{
		if (Player != null)
			Player.ActionTaken += RecieveAction;

		LvlId = Lvl.GetLevelId();
		NumOfActions = Lvl.GetNumOfActions();
	}

    public override void _UnhandledInput(InputEvent @event)
    {
        if(@event.IsActionPressed("Reload"))
			RestartGame();
    }


	public void RestartGame()
	{
		GetTree().ReloadCurrentScene();
	}

	public void ConsumeAction()
	{
		NumOfActions --;
	}

	private void CheckCurrentState()
	{
		GD.Print(NumOfActions);
		if(NumOfActions < 0)
		{
			RestartGame();
		}
	}

	public void RecieveAction()
	{
		ConsumeAction();
		CheckCurrentState();
	}

}
