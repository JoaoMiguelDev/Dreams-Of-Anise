using Godot;
using System;

public partial class Rose : Area2D
{
    [Export] private Rose Destination;
    [Export] private AudioStreamPlayer2D RoseSFX;
    [Export] private AnimatedSprite2D Sprite;
    private bool IsEnabled = true;

    public override void _Ready()
    {
        float speed = GD.RandRange(5, 15) / 10.0f;
        Sprite.SpeedScale = speed;
    }

    private void _on_body_entered(Node2D body)
    {
        if(!IsEnabled)
            return;

        if(body is Anise anise)
        {
            IsEnabled = false;
            Destination.IsEnabled = false;

            RoseSFX.Play();
            anise.TeleportTo(Destination.GlobalPosition);
            anise.Teleport();

            GetTree().CreateTimer(0.1f).Timeout += () =>
            {
                IsEnabled = true;
                Destination.IsEnabled = true;
            };
        }
    }
}
