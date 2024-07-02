using System;
using Godot;

public partial class interaction_manager : Node
{
    public Vector3 MousePosition = Vector3.Zero;
    private GameObject3D CurrentNode;

    public void UpdateMousePosition(Vector3 position)
    {
        MousePosition = position;
    }

    public void SetNode(GameObject3D node)
    {
        CurrentNode = node;
    }

    public void RemoveNode(GameObject3D node)
    {
        if (node != CurrentNode)
        {
            return;
        }

        CurrentNode = null;
    }

    public Node GetCurrentNode()
    {
        return CurrentNode;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton && @event.IsPressed())
        {
            if (CurrentNode == null)
            {
                return;
            }

            CurrentNode._MouseClicked((@event as InputEventMouseButton).ButtonIndex);
        }
    }
}
