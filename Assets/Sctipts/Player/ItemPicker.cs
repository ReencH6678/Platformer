using System;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public event Action<Item> SomethingCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Item>(out Item item))
        {
            SomethingCollected?.Invoke(item);
            item.Collect();
        }
    }
}
