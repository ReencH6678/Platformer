using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField]private string _speedBlendParameter;

    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Animator _animator;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Update()
    {
        _animator.SetBool(_speedBlendParameter, _inputHandler.Direction != 0);
        _spriteRenderer.flipX = _inputHandler.Direction < 0;
    }
}
