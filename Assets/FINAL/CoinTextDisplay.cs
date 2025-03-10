using UnityEngine;
using TMPro;

public class CoinTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    void Update()
    {
        if (coinText != null && Wallet.Instance != null)
        {
            coinText.text = "Coins: " + Wallet.Instance.GetCoins().ToString();
        }
    }
}
