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
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            _attacker.Attack(health);
        }
    }

    public Health GetNearestEnemy(float radius, Vector3 offset)
    {
        float distance = 100;
        int maxColliderCount = 30;

        Health target = null;
        Collider2D[] hits = new Collider2D[maxColliderCount];

        Physics2D.OverlapCircleNonAlloc(transform.position + offset, radius, hits);

        foreach (Collider2D hit in hits)
        {
            if (hit != null && hit.gameObject.TryGetComponent<Health>(out Health health))
            {
                if (health.gameObject != this.gameObject)
                {
                    float currentDistance = (health.gameObject.transform.position - transform.position).sqrMagnitude;

                    if (currentDistance <= distance)
                    {
                        target = health;
                        distance = currentDistance;
                    }
                }
            }
        }

        return target;
    }
}
