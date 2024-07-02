using System;
using Godot;

public partial class MainCamera : Camera3D
{
    public float Speed = 0.5f;
    public float RotationSpeed = 0.1f;

    // Distance to point in front of camera
    public float RotationPointDistance = 10f;

    public Vector3 MoveVector = Vector3.Zero;

    public override void _Ready() { }

    public override void _Process(double delta)
    {
        base._Process(delta);

        Basis ProjectionBasis = Transform.Basis;

        ProjectionBasis.Z *= new Vector3(1, 0, 1);
        ProjectionBasis.X *= new Vector3(1, 0, 1);

        ProjectionBasis.Z = ProjectionBasis.Z.Normalized();
        ProjectionBasis.X = ProjectionBasis.X.Normalized();

        Vector3 Forward =
            ProjectionBasis.Z
            * (Input.GetActionRawStrength("back") - Input.GetActionRawStrength("forward"));
        Vector3 Side =
            ProjectionBasis.X
            * (Input.GetActionRawStrength("right") - Input.GetActionRawStrength("left"));

        Vector3 Direction = (Forward + Side).Normalized();

        if (Input.IsActionPressed("rotate"))
        {
            Vector3 RotationPoint = ProjectionBasis.Z * RotationPointDistance;
            float RotationAngle = RotationSpeed / RotationPointDistance;

            // TODO Finish later
        }

        MoveVector = Direction * Speed;
    }
}
