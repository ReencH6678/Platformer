using UnityEngine;

public class GrondChecker : MonoBehaviour
{
    [SerializeField] private Vector2 _offset;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _groundLayer;

    private Vector2 _checkPosition;

    public bool IsOnGround => CheckGround();

    public bool CheckGround()
    {
        _checkPosition = new Vector2(transform.position.x + _offset.x, transform.position.y + _offset.y);

        return Physics2D.OverlapCircle(_checkPosition, _checkRadius, _groundLayer);
    }
}
