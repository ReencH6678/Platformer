using System;
using UnityEngine;

[RequireComponent(typeof(ItemPicker))]
public class Wallet : MonoBehaviour
{
    private ItemPicker _itemPicker;

    public event Action AmountChanged;

    public int CoinsCount { get; private set; }

    private void Awake()
    {
        _itemPicker = GetComponent<ItemPicker>();
    }

    private void OnEnable()
    {
        _itemPicker.SomethingCollected += CollectCoin;
    }

    private void OnDisable()
    {
        _itemPicker.SomethingCollected -= CollectCoin;
    }

    private void CollectCoin(Item item)
    {
        if (item.gameObject.TryGetComponent<Coin>(out _))
        {
            CoinsCount++;
            AmountChanged?.Invoke();
        }
    }
}
