using Godot;
using System;

public partial class Cannon : StaticBody2D
{
	public enum LaserDirection
	{
	    Up,
	    Down,
	    Left,
	    Right
	}

	[Export] public LaserDirection RayDirection;

	[Export] private LaserBeam Laser;
	[Export] public GameManager GameManager;
	[Export] private AudioStreamPlayer2D LaserSFX;
	private bool Hit = false;
	public override void _Ready()
	{
		SetLaserDirection();
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

	private void SetLaserDirection()
	{
		Laser.Rotation = RayDirection switch
		{
        LaserDirection.Up    => Mathf.DegToRad(-90),
        LaserDirection.Down  => Mathf.DegToRad(90),
        LaserDirection.Left  => Mathf.DegToRad(180),
        LaserDirection.Right => 0,
        _ => 0			
		};
	}
}
