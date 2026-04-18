using Godot;
using System;

public partial class GameManager : Node
{
	[Export] private Level Lvl;
	[Export] private Anise Player;
	[Export] private Toy Toy;
	[Export] private Hud HUD;
	[Export] private ShakyCamera Camera;
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
		Player.PauseAnise();
		// GetTree().ReloadCurrentScene();
		// GetTree().CallDeferred("reload_current_scene"); //Better for avoiding collision and physics problems
		LevelManager.Instance.ReloadCurrent();
	}

	public void ConsumeAction()
	{
		NumOfActions --;
	}

	public void TakeDamage()
	{
		if(Camera != null)
			Camera.Shake(8);
		
		Player.HitFlash();
		ConsumeAction();
		CheckCurrentState();
	}

	private void CheckCurrentState()
	{
		HUD.SetActionInfo(NumOfActions.ToString());
		if(NumOfActions < 0)
		{
			Player.Die();
		}
	}

	public void RecieveAction()
	{
		ConsumeAction();
		CheckCurrentState();
	}

	public void KillPlayer()
	{
		Camera.Shake(8);
		Player.HitFlash();
		Player.Die();
	}

}
