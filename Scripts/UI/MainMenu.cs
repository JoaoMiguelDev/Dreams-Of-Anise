using Godot;
using System;

public partial class MainMenu : Control
{
	[Export] private AudioStreamPlayer StartMenu;
	private bool ButtonPressed = false;

    public override void _Ready()
    {
		if (GameData.Instance.FirstTimeEntering())
		{
			StartMenu.Play();
			GameData.Instance.HasEntered = false;
		}
		
        AudioManager.Instance.PlayMenuSong();
    }


	public void _on_play_button_pressed()
	{
		if(ButtonPressed)
			return;

		ButtonPressed = true;
		AudioManager.Instance.PlayUIClick();
		GameData.Instance.ResetToyAmount();
		LevelManager.Instance.ResetLevelIndex();
		LevelManager.Instance.ChangeLevel();
	}

	public void _on_play_button_mouse_entered()
	{
		AudioManager.Instance.PlayUIHover();
	}

	public void _on_credits_button_mouse_entered()
	{
		AudioManager.Instance.PlayUIHover();
	}

	public void _on_quit_button_mouse_entered()
	{
		AudioManager.Instance.PlayUIHover();
	}

	public void _on_credits_button_pressed()
	{
		if(ButtonPressed)
			return;

		ButtonPressed = true;
		AudioManager.Instance.PlayUIClick();
		GetTree().ChangeSceneToFile("res://Scenes/UI/credits_menu.tscn");
	}

	public void _on_quit_button_pressed()
	{
		if(ButtonPressed)
			return;

		AudioManager.Instance.PlayUIClick();
		ButtonPressed = true;
		GetTree().Quit();
	}
}
