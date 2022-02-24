using UnityEngine;

public class PlayerAnimations : MonoBehaviour, IPlayerMovementAnimator
{
    [SerializeField] private Animator _animator;

    public void SetMovingState(bool isMoving)
    {
        _animator.SetBool("isMoving", isMoving);
    }
    
}
