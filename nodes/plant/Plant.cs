using System;
using Godot;

public partial class Plant : GameObject3D
{
    public virtual float GrowTime
    {
        get { return 10; }
        set { }
    }

    Timer Timer;

    public override void _Ready()
    {
        base._Ready();

        Timer = new Timer();
        AddChild(Timer);
        Timer.OneShot = true;
        Timer.Start(GrowTime);
        Timer.Timeout += () => GD.Print(Name + " has grown");

        Scale *= 0.01f;
    }

    public override void _MouseClicked(MouseButton mouse)
    {
        GD.Print("Clicked on a plant");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        Scale = Vector3.One * (float)(1 - (Timer.WaitTime / 100 * Timer.TimeLeft));
    }

    public override bool CanPlace(GameObject3D Parent)
    {
        return Parent is Planter;
    }
}
