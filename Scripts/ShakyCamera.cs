using Godot;
using System;

public partial class ShakyCamera : Camera2D
{
    [Export] private float ShakeDecay = 12f;

    private float ShakeStrength = 0f;
    private Vector2 shakeOffset = Vector2.Zero;

    private RandomNumberGenerator rng = new RandomNumberGenerator();

    public override void _Ready()
    {
        rng.Randomize();
    }

    public override void _Process(double delta)
    {
        if (ShakeStrength > 0)
        {
            ShakeStrength = Mathf.Lerp(
                ShakeStrength,
                0,
                ShakeDecay * (float)delta
            );

            shakeOffset = new Vector2(
                rng.RandfRange(-ShakeStrength, ShakeStrength),
                rng.RandfRange(-ShakeStrength, ShakeStrength)
            );

            Offset = shakeOffset;
        }
        else
        {
            Offset = Vector2.Zero;
        }
    }

    public void Shake(float strength)
    {
        ShakeStrength = Mathf.Max(ShakeStrength, strength);
    }
}
