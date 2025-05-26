using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    public float Direction { get; private set; }
    public bool IsJump {  get; private set; }

    private void FixedUpdate()
    {
        Direction = Input.GetAxis(Horizontal);
    }

    private void Update()
    {
        IsJump = Input.GetKey(KeyCode.Space);
    }
}
