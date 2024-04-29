using OpenTK;

public class Transformable
{
    public Matrix4 Transform { get; set; } = Matrix4.Identity;

    public void Translate(float x, float y, float z)
    {
        Transform = Transform * Matrix4.CreateTranslation(x, y, z);
    }

    public void Rotate(float angle, Vector3 axis)
    {
        Transform = Transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(angle)) * Matrix4.CreateTranslation(axis);
    }

    public void Scale(float x, float y, float z)
    {
        Transform = Transform * Matrix4.CreateScale(x, y, z);
    }
}

