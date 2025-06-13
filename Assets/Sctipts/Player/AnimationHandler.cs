using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private string _speedBlendParameter;
    [SerializeField] private Animator _animator;

    public void PlayMoveAnimation(float direction)
    {
        _animator.SetBool(_speedBlendParameter, direction != 0);
    }
}
