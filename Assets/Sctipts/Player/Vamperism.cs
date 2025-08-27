using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health), typeof(EmemyFinder))]
public class Vamperism : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;
    [SerializeField] private float _cooldown;
    [SerializeField] private Vector3 _offset;

    private Health _health;
    private EmemyFinder _enemyFinder;

    private float _attackTime = 6;

    public bool IsOn { get; private set; }

    public event UnityAction<float> PullOutStarted;
    public event UnityAction<float> CooldownStarted;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _enemyFinder = GetComponent<EmemyFinder>(); 
        IsOn = false;
    }

    public IEnumerator PullOut()
    {
        Health health = _enemyFinder.GetNearestEnemy(_radius, _offset);

        float time = 0;
        var cooldown = new WaitForSeconds(_cooldown);
        IsOn = true;

        PullOutStarted?.Invoke(_attackTime);

        while (time < _attackTime)
        {
            time += Time.deltaTime;
            float tickDamage = _damage * (Time.deltaTime / _attackTime);

            if (health != null && IsInRadius(health) && health.Count > 0)
            {
                health.TakeDamage(tickDamage);
                _health.Heal(tickDamage);
            }
            
            yield return null;
        }

        CooldownStarted?.Invoke(_cooldown);

        yield return cooldown;

        IsOn = false;
    }

    public float GetRadius()
    {
        return _radius;
    }

    public Vector3 GetOffset()
    {
        return _offset;
    }

    private bool IsInRadius(Health health)
    {
        return Vector2.Distance(transform.position + _offset, health.transform.position) <= _radius;
    }
}
