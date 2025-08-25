using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Vamperism : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;
    [SerializeField] private float _cooldown;
    [SerializeField] private Vector3 _offset;

    private Health _health;
    private float _attackTime = 6;

    public bool IsOn { get; private set; }

    public event UnityAction<float> PullOutStarted;
    public event UnityAction<float> CooldownStarted;

    private void Awake()
    {
        _health = GetComponent<Health>();
        IsOn = false;
    }

    public IEnumerator PullOut()
    {
        Health health = GetEnemyHealth();

        float time = 0;
        var cooldown = new WaitForSeconds(_cooldown);

        PullOutStarted?.Invoke(_attackTime);

        while (time < _attackTime && health != null)
        {
            time += Time.deltaTime;
            float tickDamage = _damage * (Time.deltaTime / _attackTime);

            if (IsInRadius(health) && health.Count > 0)
            {
                health.TakeDamage(tickDamage);
                _health.Heal(tickDamage);
            }
            else
            {
                break;
            }
            
            IsOn = true;

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

    private Health GetEnemyHealth()
    {
        float distance = 100;

        Health target = null;
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position +_offset, _radius);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.TryGetComponent<Health>(out Health health) && health != _health)
            {
                float currentDistance = Vector2.Distance(transform.position, hit.transform.position);

                if (currentDistance <= distance)
                {
                    target = health;
                    distance = currentDistance;
                }
            }
        }

        return target;
    }
}
