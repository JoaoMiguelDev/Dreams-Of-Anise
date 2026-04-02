using Godot;
using System;

public partial class MainMenu : Control
{
	private bool ButtonPressed = false;
	public void _on_play_button_pressed()
	{
		if(ButtonPressed)
			return;

		ButtonPressed = true;
		GameData.Instance.ResetToyAmount();
		LevelManager.Instance.ChangeLevel();
	}

	public void _on_credits_button_pressed()
	{
		if(ButtonPressed)
			return;

		ButtonPressed = true;
		GetTree().ChangeSceneToFile("res://Scenes/UI/credits_menu.tscn");
	}

	public void _on_quit_button_pressed()
	{
		if(ButtonPressed)
			return;

		ButtonPressed = true;
		GetTree().Quit();
	}
}
