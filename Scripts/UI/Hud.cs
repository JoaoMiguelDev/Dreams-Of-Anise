using Godot;
using System;

public partial class Hud : Control
{
	[Export] private Label LevelInfo;
	[Export] private Label ActionInfo;

	public void SetLevelInfo(string info)
	{
		LevelInfo.Text = info;
	}

	public void SetActionInfo(string info)
	{
		if(info.ToInt() < 0)
			ActionInfo.Text = "X";
		else
			ActionInfo.Text = info;
	}
}
