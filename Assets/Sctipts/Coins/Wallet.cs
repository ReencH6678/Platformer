using System;
using UnityEngine;

[RequireComponent(typeof(ItemFinder))]
public class Wallet : MonoBehaviour
{
    public event Action AmountChanged;

    public int CoinsCount { get; private set; }

    public void CollectCoin()
    {
        CoinsCount++;
        AmountChanged?.Invoke();
    }
}
