using System;

public class Coin : Item
{
    public event Action<Coin> Colected;

    public override void Collect()
    {
        Colected?.Invoke(this);
    }
}
