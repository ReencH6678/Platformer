using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Colected;

    public void Colect()
    {
        Colected?.Invoke(this);
    }
}
