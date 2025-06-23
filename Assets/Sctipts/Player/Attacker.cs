using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;

    public void Attack(Health health)
    {
        health.TakeDamage(_damage);
    }
}
