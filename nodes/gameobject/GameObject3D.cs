using System;
using Godot;

public partial class GameObject3D : StaticBody3D
{
    interaction_manager InteractionManager;

    public static void Place(GameObject3D Parent, GameObject3D Child)
    {
        if (Child.CanPlace(Parent) == false)
        {
            return;
        }

        if (Parent.CanBePlacedOn(Child) == false)
        {
            return;
        }

        //TODO Impliment placement
    }

    public override void _Ready()
    {
        base._Ready();

        InteractionManager = GetNode<interaction_manager>("/root/InteractionManager");
    }

    public override void _MouseEnter()
    {
        InteractionManager.SetNode(this);
    }

    public override void _MouseExit()
    {
        InteractionManager.RemoveNode(this);
    }

    public override void _InputEvent(
        Camera3D camera,
        InputEvent @event,
        Vector3 position,
        Vector3 normal,
        int shapeIdx
    )
    {
        if (@event is InputEventMouseMotion)
        {
            InteractionManager.UpdateMousePosition(position);
        }
    }

    public virtual void _MouseClicked(MouseButton button) { }

    public virtual bool CanPlace(GameObject3D Parent)
    {
        return false;
    }

    public virtual bool CanBePlacedOn(GameObject3D Child)
    {
        return false;
    }
}
