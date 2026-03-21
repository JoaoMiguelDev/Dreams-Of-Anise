using Godot;
using System;

public partial class Statue : CharacterBody2D
{
	[Export] private RayCast2D Up;
	[Export] private RayCast2D Down;
	[Export] private RayCast2D Left;
	[Export] private RayCast2D Right;
	private float MoveSpeed = 8f;
	private Vector2 TileSize = new Vector2(16,16);
	private bool IsMoving = false;
	private Vector2 TargetPosition;

	public override void _Ready()
    {
        TargetPosition = GlobalPosition;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!IsMoving) return;

        float step = MoveSpeed * TileSize.X * (float)delta;
        GlobalPosition = GlobalPosition.MoveToward(TargetPosition, step);

        if (GlobalPosition.IsEqualApprox(TargetPosition))
        {
            GlobalPosition = TargetPosition;
            IsMoving = false;
        }
    }

	public bool TryPush(Vector2 direction)
	{
    	if (IsMoving) return false;

    	RayCast2D ray = direction switch
    	{
        	var d when d == Vector2.Up    => Up,
        	var d when d == Vector2.Down  => Down,
        	var d when d == Vector2.Left  => Left,
        	var d when d == Vector2.Right => Right,
        	_ => null
    	};

    	if (ray == null || ray.IsColliding()) return false;

    	TargetPosition = GlobalPosition + direction * TileSize;
    	IsMoving = true;
    	return true;
	}

}
