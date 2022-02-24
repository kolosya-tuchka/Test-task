using UnityEngine;

public class PlayerRun : PlayerMover
{
    public PlayerRun(Transform transform, Rigidbody rigidbody, IPlayerMovementAnimator playerMovementAnimator) : base(transform, rigidbody, playerMovementAnimator)
    {
        
    }

    public override void Move(Vector3 direction, float speed)
    {
        _rigidbody.velocity = new Vector3(direction.normalized.x * speed, _rigidbody.velocity.y, direction.normalized.z * speed);
        _playerMovementAnimator.SetMovingState(direction * speed != Vector3.zero);
    }
}
