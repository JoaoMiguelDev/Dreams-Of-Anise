using Godot;
using System;

public partial class Cannon : StaticBody2D
{
	[Export] private LaserBeam Laser;
	[Export] public GameManager GameManager;
	private bool Hit = false;
	public override void _Ready()
	{
		if(Laser != null)
			Laser.PlayerHit += DeathByLaser;
	}

	public void DeathByLaser()
	{
		if (!Hit)
		{
			Hit = true;
			GameManager.RestartGame();
		}
	}
}
