using Godot;
using System;

public partial class LaserBeam : RayCast2D
{
    [Export] public float MaxLength = 1000.0f;
    [Export] public float CastSpeed = 400.0f;
    [Export] public GameManager GameManager;
    [Signal] public delegate void PlayerHitEventHandler();
    private Line2D _line;
    private float _currentLength = 0f;

    public override void _Ready()
    {
        // Cria a Line2D dinamicamente — sem precisar configurar nada no editor
        _line = new Line2D();
        _line.Width = 4f;
        _line.DefaultColor = Colors.Red;
        AddChild(_line);

        _line.AddPoint(Vector2.Zero);
        _line.AddPoint(Vector2.Zero);

        // Garante que o RayCast começa pequeno e cresce via código
        TargetPosition = Vector2.Zero;
    }

    public override void _PhysicsProcess(double delta)
    {
        // Cresce o comprimento atual até o máximo
        _currentLength = Mathf.MoveToward(_currentLength, MaxLength, CastSpeed * (float)delta);

        // Aponta o RayCast na direção local do nó (rotacione o nó no editor)
        TargetPosition = Vector2.Right * _currentLength;
        ForceRaycastUpdate();

        Vector2 endPoint;

        if (IsColliding())
        {
			if (GetCollider() is Anise)
			{
				PlayerHitEmitSignal();
			}
            // Para no ponto de colisão
            endPoint = ToLocal(GetCollisionPoint());
            _currentLength = endPoint.Length(); // trava o crescimento
        }
        else
        {
            endPoint = TargetPosition;
        }

        _line.SetPointPosition(0, Vector2.Zero);
        _line.SetPointPosition(1, endPoint);
    }

    public void PlayerHitEmitSignal()
    {
        EmitSignal(SignalName.PlayerHit);
    }
}
