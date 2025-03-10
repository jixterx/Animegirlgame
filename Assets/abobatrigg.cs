using UnityEngine;

public class AbobaTrigg : MonoBehaviour
{
    public static AbobaTrigg Instance;
    private Animator chestAnimator;
    private bool hasGivenBonus = false; // Чтобы монеты выдавались только один раз

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        chestAnimator = GetComponent<Animator>();
    }

    public void StartChestAnimation()
    {
        Debug.Log("Сундук начал трястись!");
        chestAnimator.SetTrigger("ActivateEffect");
    }

    public void ReturnChestToIdle()
    {
        Debug.Log("Сундук вернулся в состояние покоя!");
        chestAnimator.SetTrigger("ReturnToIdle");
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasGivenBonus)
        {
            Debug.Log("Игрок прошел через сундук! +40 монет!");
            Wallet.Instance.AddCoins(40);
            hasGivenBonus = true; // Чтобы не выдавалось больше одного раза
        }
    }
}
