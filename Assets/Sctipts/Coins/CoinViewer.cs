using TMPro;
using UnityEngine;

public class CoinViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.AmountChanged += ShowInfo;   
    }

    private void OnDisable()
    {
        _wallet.AmountChanged -= ShowInfo;
    }

    private void ShowInfo()
    {
        int amount = _wallet.CoinsCount;

        _text.text = amount.ToString();
    }
}
