using UnityEngine;

public class PlayerSmoothRotator : PlayerRotator
{
    private Transform _target;
    
    public PlayerSmoothRotator(Transform transform, Transform target) : base(transform)
    {
        _transform = transform;
        _target = target;
    }

    public override void Rotate(Vector3 direction, float speed)
    {
        if (direction == Vector3.zero) return;       
        
        Quaternion rotTarget = Quaternion.Euler(0, Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg, 0);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, rotTarget, speed);
    }
}