using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    private Animator chestAnimator;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            chestAnimator = GetComponent<Animator>();

            
            chestAnimator.SetTrigger("ActivateEffect");

            
            Wallet.Instance.AddCoins(10); 

           
            Debug.Log("������ ���������! ���������� �����: " + Wallet.Instance.GetCoins());

            
            Destroy(gameObject, 1f); 
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            chestAnimator.ResetTrigger("ActivateEffect");
        }
    }
}
