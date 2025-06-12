using System;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    public int CoinsCount { get; private set; }
    public event Action AmountChanged;

    public void PickCoin()
    {
        CoinsCount++;
        AmountChanged?.Invoke();
    }
}
