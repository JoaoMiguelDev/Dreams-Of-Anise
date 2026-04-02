using Godot;
using System;

public partial class GameManager : Node
{
	[Export] private Level Lvl;
	[Export] private Anise Player;
	[Export] private Toy Toy;
	[Export] private Hud HUD;
	private int LvlId;
	private int NumOfActions;
	public bool HasToy = false;
	public override void _Ready()
	{
		if (Player != null)
			Player.ActionTaken += RecieveAction;

		LvlId = Lvl.GetLevelId();
		NumOfActions = Lvl.GetNumOfActions();

		HUD.SetLevelInfo(LvlId.ToString());
		HUD.SetActionInfo(NumOfActions.ToString());

		if(Toy != null)
			Toy.SetSprite(LvlId);
	}

    public override void _UnhandledInput(InputEvent @event)
    {
        if(@event.IsActionPressed("Reload"))
			RestartGame();
    }


	public void RestartGame()
	{
		// GetTree().ReloadCurrentScene();
		GetTree().CallDeferred("reload_current_scene"); //Better for avoiding collision and physics problems
	}

	public void ConsumeAction()
	{
		NumOfActions --;
	}

	public void TakeDamage()
	{
		ConsumeAction(); //It will do the same thing as Consume action for now, but will be updated to shake screen and do more stuff
		CheckCurrentState();
	}

	private void CheckCurrentState()
	{
		HUD.SetActionInfo(NumOfActions.ToString());
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
