using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class EmemyFinder : MonoBehaviour
{
    private Attacker _attacker;

    private void Awake()
    {
        _attacker = GetComponent<Attacker>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            _attacker.Attack(health);
        }
    }
}
