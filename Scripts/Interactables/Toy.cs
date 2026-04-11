using Godot;
using System;

public partial class Toy : Area2D
{
    [Export] private Sprite2D Sprite;
    [Export] private GameManager GameManager;
    public void _on_body_entered(Node2D body)
    {
        if(body is Anise)
        {
            // GameData.Instance.AddToy();
            AudioManager.Instance.PlayCollectToy();
            GameManager.HasToy = true;
            QueueFree();
        }
    }

    public void SetSprite(int levelid)
    {
        Sprite.Frame = levelid - 1;
    }
}
