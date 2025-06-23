using UnityEngine;

public class Investigator : MonoBehaviour
{
    [SerializeField] private float _seeDistance;
    [SerializeField] private Vector3 _rayOffset;

    Ray _ray;
    RaycastHit2D _hit;

    public Vector2 GetInvestigDirection(float direction)
    {
        _ray = new Ray(transform.position + _rayOffset * direction, Vector2.right * _seeDistance);
        _hit = Physics2D.Raycast(_ray.origin, _ray.direction * direction, _seeDistance);

        if (_hit.collider != null && _hit.collider.gameObject.TryGetComponent<Player>(out _)) 
            return _hit.collider.transform.position - transform.position;
        
        return Vector2.zero;
    }
}
