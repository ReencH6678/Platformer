using UnityEngine;

public class GrondChecker : MonoBehaviour
{
    [SerializeField] private Vector2 _offset;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsOnGround => CheckGround();

    public bool CheckGround()
    {
        Vector2 checkPosition = new Vector2(transform.position.x + _offset.x, transform.position.y + _offset.y);

        return Physics2D.OverlapCircle(checkPosition, _checkRadius, _groundLayer);
    }
}
