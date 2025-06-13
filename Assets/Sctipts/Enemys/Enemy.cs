using UnityEngine;

[RequireComponent(typeof(Patrul), typeof(Mover), typeof(Fliper))]
public class Enemy : MonoBehaviour
{
    private Patrul _patrul;
    private Mover _mover;
    private Fliper _fliper;

    private bool _isPatrolling = true;
 
    private void Awake()
    {
        _patrul = GetComponent<Patrul>();
        _mover = GetComponent<Mover>();
        _fliper = GetComponent<Fliper>();
    }

    private void Update()
    {
        float direction = _patrul.GetPatrulDirection().x;

        if (_isPatrolling)
            _mover.Move(direction);

        _fliper.Flip(direction);
    }
}
