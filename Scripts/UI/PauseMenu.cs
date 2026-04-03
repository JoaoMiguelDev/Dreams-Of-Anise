using Godot;
using System;

public partial class PauseMenu : Control
{
	[Export] private GameManager GameManager;
	public override void _Ready()
	{
		Unpause();
	}

    public override void _UnhandledInput(InputEvent @event)
    {
		if (Input.IsActionJustPressed("Pause"))
		{
			if (IsPaused())
				Unpause();
			else
				Pause();
		}        
    }


	private void Pause()
	{
		Visible = true;
		GetTree().Paused = true;
	}

	private void Unpause()
	{
		Visible = false;
		GetTree().Paused = false;		
	}

	private bool IsPaused()
	{
		return GetTree().Paused;
	}

	public void _on_resume_pressed()
	{
		Unpause();
	}
	public void _on_retry_pressed()
	{
		GameManager.RestartGame();
		Unpause();
	}
	public void _on_quit_pressed()
	{
		GetTree().CallDeferred("change_scene_to_file", "res://Scenes/UI/main_menu.tscn");
		Unpause();
	}
}
