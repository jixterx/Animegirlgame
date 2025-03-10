using UnityEngine;

public class Cointy : MonoBehaviour
{
    public int coinValue = 1; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок подобрал Cointy!");

            
            Wallet.Instance.AddCoins(coinValue);

            
            AbobaTrigg.Instance.ReturnChestToIdle();

            
            Destroy(gameObject);
        }
    }
}
