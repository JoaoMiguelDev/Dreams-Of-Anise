using Godot;
using System;

public partial class Toy : Area2D
{
    [Export] private AnimatedSprite2D Sprite;
    [Export] private GameManager GameManager;
    [Export] private PackedScene CollectParticles;
    public void _on_body_entered(Node2D body)
    {
        if(body is Anise)
        {
            // GameData.Instance.AddToy();
            AudioManager.Instance.PlayCollectToy();
            GameManager.HasToy = true;
            EmitCollectParticle();
            QueueFree();
        }
    }

    public void SetSprite(int levelid)
    {
        // Sprite.Frame = levelid - 1;
        switch (levelid)
        {
            case 1:
                Sprite.Play("Boneca");
                break;
            case 2:
                Sprite.Play("Cavalo");
                break;
            case 3:
                Sprite.Play("Coelho");
                break;
            case 4:
                Sprite.Play("Espelho");
                break;
            case 5:
                Sprite.Play("Piao");
                break;
            case 6:
                Sprite.Play("Trem");
                break;
            default:
                Sprite.Play("Boneca");
                break;
        }
    }

    private void EmitCollectParticle()
    {
	    CpuParticles2D explosion = CollectParticles.Instantiate<CpuParticles2D>();
	    GetParent().AddChild(explosion);
	    explosion.GlobalPosition = GlobalPosition;
	    explosion.Emitting = true;
	   
	    explosion.Finished += explosion.QueueFree;        
    }
}
