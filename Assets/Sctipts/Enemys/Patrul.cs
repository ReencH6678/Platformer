using UnityEngine;

public class Patrul : MonoBehaviour
{
    [SerializeField] private Transform[] _patrulPoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _offset;
    [SerializeField] private int _patrulIndex = 0;

    private void Update()
    {
        if ((transform.position - _patrulPoints[_patrulIndex].position).sqrMagnitude < _offset)
        {
            if (_patrulIndex + 1 > _patrulPoints.Length - 1)
                _patrulIndex = 0;
            else
                _patrulIndex++;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _patrulPoints[_patrulIndex].position, _speed * Time.deltaTime);
        }
    }
}
