using UnityEngine;

public class Item : MonoBehaviour
{
    public virtual void Collect()
    {
        Destroy(gameObject);
    }
}
