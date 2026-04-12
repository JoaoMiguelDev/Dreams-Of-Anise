using Godot;
using System;

public partial class LevelTransition : CanvasLayer
{
	[Export] private ColorRect Rectangle;
	[Export] private AnimationPlayer Transition;
	public static LevelTransition Instance;
	private string NextLevel;

    public override void _Ready()
    {
        Instance = this;
    }

	public void Transitioning(string scenePath)
	{
		NextLevel = scenePath;
		Rectangle.Visible = true;
		Transition.Play("fadein");
	}

	public void _on_animation_player_animation_finished(StringName anim_name)
	{
		if(anim_name == "fadein")
		{
			GetTree().CallDeferred("change_scene_to_file", NextLevel);
			Transition.Play("fadeout");
		}
		else if (anim_name == "fadeout")
		{
			Rectangle.Visible = false;
		}		
	}
}
