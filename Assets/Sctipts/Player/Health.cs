using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealthCount;
    public float HealthCount { get; private set; }

    private void Start()
    {
        HealthCount = _maxHealthCount;
    }

    public void TakeDamage(float damage)
    {
        HealthCount -= damage;
    }

    public void Heal(float healCount)
    {
        HealthCount += healCount;
    }
}
