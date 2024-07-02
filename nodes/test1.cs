using System;
using Godot;

public partial class test1 : StaticBody3D
{
    interaction_manager InteractionManager;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        InteractionManager = GetNode<interaction_manager>("/root/InteractionManager");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }
}
