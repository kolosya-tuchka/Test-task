using System;
using UnityEngine;

public abstract class PlayerMover
{
    protected Transform _transform;
    protected Rigidbody _rigidbody;
    protected IPlayerMovementAnimator _playerMovementAnimator;

    public PlayerMover(Transform transform, Rigidbody rigidbody, IPlayerMovementAnimator playerMovementAnimator)
    {
        _transform = transform;
        _rigidbody = rigidbody;
        _playerMovementAnimator = playerMovementAnimator;
    }

    public abstract void Move(Vector3 direction, float speed);
}
