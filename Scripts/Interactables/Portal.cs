using Godot;
using System;

public partial class Portal : Area2D
{
    public void _on_body_entered(Node2D body)
    {
        if(body is Anise)
        {
            LevelManager.Instance.ChangeLevel();
        }
    }
}
