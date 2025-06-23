using UnityEngine;

[RequireComponent(typeof(Wallet), typeof(Health))]
public class ItemPicker : MonoBehaviour, IItemVisitor
{
    private Wallet _wallet;
    private Health _health;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _health = GetComponent<Health>();
    }

    public void VisitCoin(Coin coin)
    {
        _wallet.CollectCoin();
    }

    public void VisitAidBox(AidBox aidBox, float healCount)
    {
        _health.Heal(healCount);
    }
}
