using Godot;
using System;

public abstract partial class Level : Node2D
{
    protected abstract int LevelId { get; }
    protected abstract int NumberOfActions { get; }

    public int GetLevelId() => LevelId;
    public int GetNumOfActions() => NumberOfActions;
}
