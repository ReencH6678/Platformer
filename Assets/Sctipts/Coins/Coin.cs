using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Picked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CoinPicker>(out CoinPicker coinPicker))
        {
            Picked?.Invoke(this);
            coinPicker.PickCoin();
        }
    }
}
