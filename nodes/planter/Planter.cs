using System;
using Godot;

public partial class Planter : GameObject3D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready() { }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    public override bool CanPlace(GameObject3D Parent)
    {
        return true;
    }

    public override bool CanBePlacedOn(GameObject3D Child)
    {
        return Child is Plant;
    }
}
