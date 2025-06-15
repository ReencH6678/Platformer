using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class ItemPicker : MonoBehaviour, IItemVisitor
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    public void VisitCoin(Coin coin)
    {
        _wallet.CollectCoin();
    }
}
