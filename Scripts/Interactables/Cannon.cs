using Godot;
using System;

public partial class Cannon : StaticBody2D
{
	[Export] private LaserBeam Laser;
	[Export] public GameManager GameManager;
	[Export] private AudioStreamPlayer2D LaserSFX;
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
			LaserSFX.Play();
			// GameManager.RestartGame();
			GameManager.KillPlayer();
		}
	}
}
