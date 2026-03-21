using Godot;
using System;

public partial class Anise : CharacterBody2D
{
	[Export] private RayCast2D Up;
	[Export] private RayCast2D Down;
	[Export] private RayCast2D Left;
	[Export] private RayCast2D Right;
	private float MoveSpeed = 12f;
	private Vector2 TileSize = new Vector2(16,16);
	private bool IsMoving = false;
	private Vector2 TargetPosition;

    public override void _Ready()
    {
        TargetPosition = GlobalPosition;
    }
	public override void _PhysicsProcess(double delta)
	{
		if (IsMoving)
		{
			float step = MoveSpeed * TileSize.X * (float)delta;
            GlobalPosition = GlobalPosition.MoveToward(TargetPosition, step);
            if (GlobalPosition.IsEqualApprox(TargetPosition))
            {
                GlobalPosition = TargetPosition;
                IsMoving = false;
            }
		}
		else
		{
			HandleMovementInput();
		}
	}

	private void HandleMovementInput()
    {
        Vector2 direction = Vector2.Zero;
        RayCast2D ray = null;

        if (Input.IsActionJustPressed("MoveUp"))        { direction = Vector2.Up;    ray = Up;    }
        else if (Input.IsActionJustPressed("MoveDown")) { direction = Vector2.Down;  ray = Down;  }
        else if (Input.IsActionJustPressed("MoveLeft")) { direction = Vector2.Left;  ray = Left;  }
        else if (Input.IsActionJustPressed("MoveRight")){ direction = Vector2.Right; ray = Right; }

        // if (direction != Vector2.Zero && ray != null && !ray.IsColliding())
        // {
        //     IsMoving = true;
        //     TargetPosition = GlobalPosition + direction * TileSize;
        // }

		if (direction == Vector2.Zero || ray == null) return;

		if (ray.IsColliding())
    	{        
        	if (ray.GetCollider() is Statue statue)
        	{
            	statue.TryPush(direction);
            }
        	
        	return; 
        	
    	}

    	IsMoving = true;
    	TargetPosition = GlobalPosition + direction * TileSize;
    }

	public void TeleportTo(Vector2 worldPosition)
	{
	    GlobalPosition = worldPosition;
	    TargetPosition = worldPosition;
	    IsMoving = false;
	}	

}
