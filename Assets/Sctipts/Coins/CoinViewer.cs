using TMPro;
using UnityEngine;

public class CoinViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CoinPicker _coinPicker;

    private void OnEnable()
    {
        _coinPicker.AmountChanged += ShowInfo;   
    }

    private void OnDisable()
    {
        _coinPicker.AmountChanged -= ShowInfo;
    }

    private void ShowInfo()
    {
        int amount = _coinPicker.CoinsCount;
        _text.text = amount.ToString();
    }
}
