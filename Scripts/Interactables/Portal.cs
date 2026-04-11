using Godot;
using System;

public partial class Portal : Area2D
{
    [Export] private GameManager GameManager;
    public void _on_body_entered(Node2D body)
    {
        if(body is Anise)
        {
            if(GameManager != null && GameManager.HasToy)
                GameData.Instance.AddToy();

            
            AudioManager.Instance.PlayPortalSFX();
            LevelManager.Instance.ChangeLevel();
        }
    }
}
