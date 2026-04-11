using Godot;
using System;

public partial class Thorns : Area2D
{
    [Export] GameManager GameManager;
    [Export] private AudioStreamPlayer2D SpikeSFX;
    public void _on_body_entered(Node2D body)
    {
        if(body is Anise)
        {
            SpikeSFX.Play();
            GameManager.TakeDamage();
        }
    }
}
