using UnityEngine;

public class SpecialCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("����� �������� SpecialCoin!");

            
            Wallet.Instance.AddCoins(1);

            
            if (AbobaTrigg.Instance != null)
            {
                AbobaTrigg.Instance.StartChestAnimation();
            }
            else
            {
                Debug.LogError("AbobaTrigg.Instance = null! �������, ��� ������ ���� �� �������.");
            }

           
            Destroy(gameObject);
        }
    }
}
