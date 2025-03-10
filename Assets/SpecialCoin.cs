using UnityEngine;

public class SpecialCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок подобрал SpecialCoin!");

            
            Wallet.Instance.AddCoins(1);

            
            if (AbobaTrigg.Instance != null)
            {
                AbobaTrigg.Instance.StartChestAnimation();
            }
            else
            {
                Debug.LogError("AbobaTrigg.Instance = null! Убедись, что скрипт есть на сундуке.");
            }

           
            Destroy(gameObject);
        }
    }
}
