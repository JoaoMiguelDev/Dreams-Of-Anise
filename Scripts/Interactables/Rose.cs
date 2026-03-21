using Godot;
using System;

public partial class Rose : Area2D
{
    [Export] private Rose Destination;
    private bool IsEnabled = true;

    private void _on_body_entered(Node2D body)
    {
        if(!IsEnabled)
            return;

        if(body is Anise anise)
        {
            IsEnabled = false;
            Destination.IsEnabled = false;

            anise.TeleportTo(Destination.GlobalPosition);

            GetTree().CreateTimer(0.1f).Timeout += () =>
            {
                IsEnabled = true;
                Destination.IsEnabled = true;
            };
        }
    }
}
