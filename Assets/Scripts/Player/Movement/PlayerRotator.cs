using System;
using UnityEngine;

public abstract class PlayerRotator
{
    protected Transform _transform;

    public PlayerRotator(Transform transform)
    {
        _transform = transform;
    }

    public abstract void Rotate(Vector3 direction, float speed);
}
