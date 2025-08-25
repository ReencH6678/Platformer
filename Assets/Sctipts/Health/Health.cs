using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxCount;
    public float Count { get; private set; }

    public event Action<float, float> Changed;

    private void Start()
    {
        Count = _maxCount;
        Changed?.Invoke(Count, _maxCount);
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0 && Count > 0)
        {
            if (Count - damage < 0)
                Count = 0;
            else
                Count -= damage;

            Changed?.Invoke(Count, _maxCount);
        }
    }

    public void Heal(float healCount)
    {
        if (healCount > 0 && healCount + Count <= _maxCount)
        {
            Count += healCount;
            Changed?.Invoke(Count, _maxCount);
        }
    }
}
