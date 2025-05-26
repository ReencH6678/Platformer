using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler), typeof(Mover), typeof(Jumper))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private InputHandler _inputHandler;
    private Mover _mover;
    private Jumper _jumper;
    private Rigidbody2D _rigidbody2D;
    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_inputHandler.Direction != 0)
            _mover.Move(_inputHandler.Direction);

        if (_inputHandler.IsJump)
            _jumper.Jump(_rigidbody2D);

    }
}
