using UnityEngine;

public class Patrul : MonoBehaviour
{
    [SerializeField] private Transform[] _patrulPoints;
    [SerializeField] private float _offset;
    [SerializeField] private int _patrulIndex = 0;

    public Vector2 GetPatrulDirection()
    {
        if ((transform.position - _patrulPoints[_patrulIndex].position).sqrMagnitude < _offset)
            _patrulIndex = ++_patrulIndex % _patrulPoints.Length;

        Vector2 patrulDierction = _patrulPoints[_patrulIndex].position - transform.position;

        return patrulDierction;
    }
}
