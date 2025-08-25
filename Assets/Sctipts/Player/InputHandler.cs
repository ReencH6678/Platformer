using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const int LeftMouseButtonIndex = 0;
    public float Direction { get; private set; }
    public bool IsJump {  get; private set; }
    public bool IsRightMousePressed {  get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);
        IsJump = Input.GetKey(KeyCode.Space);
        IsRightMousePressed = Input.GetMouseButtonDown(LeftMouseButtonIndex);
    }
}
