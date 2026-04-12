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
		AudioManager.Instance.PlayUIClick();
		Unpause();
	}
	public void _on_retry_pressed()
	{
		AudioManager.Instance.PlayUIClick();
		GameManager.RestartGame();
		Unpause();
	}
	public void _on_quit_pressed()
	{
		AudioManager.Instance.StopAll();
		AudioManager.Instance.PlayUIReturn();
		// GetTree().CallDeferred("change_scene_to_file", "res://Scenes/UI/main_menu.tscn");
		LevelTransition.Instance.Transitioning("res://Scenes/UI/main_menu.tscn");
		Unpause();
	}

	public void _on_resume_mouse_entered()
	{
		AudioManager.Instance.PlayUIHover();
	}

	public void _on_retry_mouse_entered()
	{
		AudioManager.Instance.PlayUIHover();		
	}

	public void _on_quit_mouse_entered()
	{
		AudioManager.Instance.PlayUIHover();		
	}
}
