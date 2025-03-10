using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; 

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"✅ Монета задета объектом: {other.gameObject.name} (тег {other.tag})");

        if (other.CompareTag("Player"))
        {
            if (Wallet.Instance != null)
            {
                Wallet.Instance.AddCoins(coinValue);
                Debug.Log("✅ Монеты успешно добавлены! Текущее количество: " + Wallet.Instance.GetCoins());
            }
            else
            {
                Debug.LogWarning("⚠️ Wallet.Instance равен null! Кошелек не найден.");
            }

            Destroy(gameObject);
        }
    }
}
