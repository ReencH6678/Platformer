using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField]private string _speedBlendParameter;

    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Animator _animator;

    public void PlayMoveAnimation()
    {
        _animator.SetBool(_speedBlendParameter, _inputHandler.Direction != 0);
    }
}
