using System;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    public int CoinsCount { get; private set; }
    public event Action AmountChanged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            PickCoin();
            coin.Colect();
        }
    }

    public void PickCoin()
    {
        CoinsCount++;
        AmountChanged?.Invoke();
    }

}
