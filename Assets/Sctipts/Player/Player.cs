using UnityEngine;

[RequireComponent(typeof(InputHandler), typeof(Mover), typeof(Jumper))]
[RequireComponent(typeof(Rigidbody2D), typeof(Fliper))]

public class Player : MonoBehaviour
{
    private InputHandler _inputHandler;
    private Mover _mover;
    private Fliper _fliper;
    private Jumper _jumper;
    private Rigidbody2D _rigidbody2D;
    private GrondChecker _grondChecker;

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        _mover = GetComponent<Mover>();
        _fliper = GetComponent<Fliper>();
        _jumper = GetComponent<Jumper>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _grondChecker = GetComponent<GrondChecker>();
    }

    private void Update()
    {
        if (_inputHandler.Direction != 0)
        {
            _mover.Move(_inputHandler.Direction);
            _fliper.Flip(_inputHandler.Direction);
        }

        if (_inputHandler.IsJump && _grondChecker.IsOnGround)
            _jumper.Jump(_rigidbody2D);
    }
}
