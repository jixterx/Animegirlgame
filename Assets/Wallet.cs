using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet Instance; // ��������
    private int currentCoins = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        Debug.Log("������ � ��������: " + currentCoins);
    }

    public int GetCoins()
    {
        return currentCoins;
    }
}
