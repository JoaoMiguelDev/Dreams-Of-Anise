using Godot;
using System;

public partial class Anise : CharacterBody2D
{
	[Export] private RayCast2D Up;
	[Export] private RayCast2D Down;
	[Export] private RayCast2D Left;
	[Export] private RayCast2D Right;
	[Export] private AnimatedSprite2D Sprite;
	[Export] private AudioStreamPlayer2D WalkSFX;
	[Export] private AudioStreamPlayer2D DeathSFX;
	[Export] private AnimationPlayer HitFlashAnim;
	[Export] private PackedScene DustParticles;
	[Signal] public delegate void ActionTakenEventHandler();
	private float MoveSpeed = 12f;
	private Vector2 LastDirection = Vector2.Down;
	private Vector2 TileSize = new Vector2(16,16);
	private bool IsMoving = false;
	private bool IsDead = false;
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
				Sprite.Play("Idle");
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

		if (direction != Vector2.Zero)
        	UpdateSprite(direction);

		if (direction == Vector2.Zero || ray == null) return;

		if (ray.IsColliding())
    	{        
        	if (ray.GetCollider() is Statue statue)
        	{
            	statue.TryPush(direction);
            }
        	Sprite.Play("Idle");
        	return; 
        }

    	IsMoving = true;
		EmitDust();
		WalkSFX.Play();
		ActionTakenEmitSignal();
    	TargetPosition = GlobalPosition + direction * TileSize;
    }

	private void UpdateSprite(Vector2 direction)
	{
    	LastDirection = direction;

		if (direction == Vector2.Right)
        	Sprite.FlipH = false;
    	else if (direction == Vector2.Left)
        	Sprite.FlipH = true;

    	Sprite.Play("Walk");
	}

	public void TeleportTo(Vector2 worldPosition)
	{
		GlobalPosition = worldPosition;
	    TargetPosition = worldPosition;
	    IsMoving = false;
	}	

	public void ActionTakenEmitSignal()
	{
		EmitSignal(SignalName.ActionTaken);
	}

	public async void Die()
	{
		if(IsDead)
			return;

		IsMoving = false;
		SetPhysicsProcess(false);
		
		DeathSFX.Play();
		Sprite.Play("Death");

		await ToSignal(GetTree().CreateTimer(1.0f), "timeout");

		LevelManager.Instance.ReloadCurrent();
	}

	public void PauseAnise()
	{
		IsMoving = false;
		SetPhysicsProcess(false);
		Sprite.Animation = "Idle";
	}

	public void HitFlash()
	{
		HitFlashAnim.Play("Hit");
	}

	public void Teleport()
	{
		HitFlashAnim.Play("Teleport");
	}

	public void Portal()
	{
		HitFlashAnim.Play("Portal");
	}

	private void EmitDust()
	{
	    CpuParticles2D dust = DustParticles.Instantiate<CpuParticles2D>();
	    GetParent().AddChild(dust);
	    dust.GlobalPosition = GlobalPosition;
	    dust.Emitting = true;
	   
	    dust.Finished += dust.QueueFree;
	}

}
