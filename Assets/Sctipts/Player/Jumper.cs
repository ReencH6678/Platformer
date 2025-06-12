using UnityEngine;

[RequireComponent(typeof(GrondChecker))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _fumpForce;

    private GrondChecker _groundChecker;

    private void Awake()
    {
        _groundChecker = GetComponent<GrondChecker>();
    }

    public void Jump(Rigidbody2D rigidbody2D)
    {
        if (_groundChecker.IsOnGround())
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _fumpForce);
    }
}
