using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float movingSpeed;
    [SerializeField] private float rotationSpeed;
    
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerAnimations _playerAnimations;
    private PlayerMover _playerMover;
    private PlayerRotator _playerRotator;

    private void Start()
    {
        _playerRotator = new PlayerSmoothRotator(transform, _joystick.transform);
        _playerMover = new PlayerRun(transform, _rigidbody, _playerAnimations);
    }

    private void FixedUpdate()
    {
        var joystickDirection = new Vector3(_joystick.Direction.y, 0, -_joystick.Direction.x);
        _playerMover?.Move(joystickDirection, movingSpeed);
        _playerRotator?.Rotate(joystickDirection, rotationSpeed);
    }
}
