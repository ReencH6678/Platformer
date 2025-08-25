using UnityEngine;

[RequireComponent(typeof(Patrul), typeof(Mover), typeof(Fliper))]
[RequireComponent(typeof(Investigator))]
public class Enemy : MonoBehaviour
{
    private Patrul _patrul;
    private Investigator _investigator;
    private Mover _mover;
    private Fliper _fliper;

    private float _direction = Vector2.right.x;

    private enum State
    {
        Patrul,
        Investinen
    }

    private State _state;

    private void Awake()
    {
        _patrul = GetComponent<Patrul>();
        _mover = GetComponent<Mover>();
        _investigator = GetComponent<Investigator>();
        _fliper = GetComponent<Fliper>();
        _state = State.Patrul;
    }

    private void Update()
    {
        if(_investigator.GetInvestigDirection(_direction) == Vector2.zero)
            _state = State.Patrul;
        else
            _state = State.Investinen;

        switch (_state)
        {
            case State.Patrul:
                _direction = _patrul.GetPatrulDirection().normalized.x;
                break;
            case State.Investinen:
                _direction = _investigator.GetInvestigDirection(_direction).normalized.x;
                break;
        }

        _mover.Move(_direction);
        _fliper.Flip(_direction);
    }
}
