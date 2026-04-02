using Godot;
using System;

public partial class CreditsMenu : Control
{
	private bool ButtonPressed = false;
	public void _on_return_button_pressed()
	{
		if(ButtonPressed)
			return;

		ButtonPressed = true;
		
		GetTree().ChangeSceneToFile("res://Scenes/UI/main_menu.tscn");
	}
}
