using System;
using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    public event Action<Coin> Colected;

    public void Pick(IItemVisitor visitor)
    {
        Colected?.Invoke(this);
        visitor.VisitCoin(this);
    }
}
