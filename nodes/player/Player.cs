using System;
using Godot;

public partial class Player : Node3D
{
    MainCamera MainCamera;
    Cursor Cursor;

    GameObject3D InHand;

    public override void _Ready()
    {
        MainCamera = GetNode<MainCamera>("Camera3D");
        Cursor = GetNode<Cursor>("Cursor");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Position += MainCamera.MoveVector;
    }

    public override void _UnhandledKeyInput(InputEvent @event)
    {
        base._UnhandledKeyInput(@event);

        if (Input.IsActionJustPressed("1"))
        {
            InHand = GD.Load<PackedScene>("res://nodes/plant/Plant.tscn")
                .Instantiate<GameObject3D>();
        }
        if (Input.IsActionJustPressed("2"))
        {
            InHand = GD.Load<PackedScene>("res://nodes/planter/Planter.tscn")
                .Instantiate<GameObject3D>();
        }
    }
}
