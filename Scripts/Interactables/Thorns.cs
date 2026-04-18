using Godot;
using System;

public partial class Thorns : Area2D
{
    [Export] GameManager GameManager;
    [Export] Sprite2D Sprite;
    [Export] private AudioStreamPlayer2D SpikeSFX;

    public override void _Ready()
    {
        bool randomBool = GD.Randi() % 2 == 0;
        Sprite.FlipH = randomBool;        
    }

    public void _on_body_entered(Node2D body)
    {
        if(body is Anise)
        {
            SpikeSFX.Play();
            GameManager.TakeDamage();
        }
    }
}
