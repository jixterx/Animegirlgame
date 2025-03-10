using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using System.Collections; 

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    public GameObject deathScreen; // Экран смерти
    public TextMeshProUGUI deathText; // Текст "Ты умер"
    public TextMeshProUGUI damageText; // Текст урона
    public TextMeshProUGUI hpText; // Текст текущего HP
    public TextMeshProUGUI damageLog; // Оповещение об уроне

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log($"Здоровье установлено: {currentHealth}");

        
        if (deathScreen != null)
        {
            deathScreen.SetActive(false);
            Debug.Log("DeathScreen отключён при старте.");
        }

        
        if (damageText != null)
        {
            damageText.gameObject.SetActive(false);
        }

       
        if (hpText != null)
        {
            hpText.text = $"{currentHealth}/{maxHealth}";
        }

        
        if (damageLog != null)
        {
            damageLog.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        Debug.Log($"Игрок получил {damage} урона! Осталось здоровья: {currentHealth}");

        
        if (hpText != null)
        {
            hpText.text = $"{currentHealth}/{maxHealth}";
        }

        
        if (damageText != null)
        {
            damageText.text = $"-{damage} HP";
            damageText.gameObject.SetActive(true);
            StartCoroutine(HideDamageText()); 
        }

        
        if (damageLog != null)
        {
            damageLog.text = "Игрок получил урон!";
            damageLog.gameObject.SetActive(true);
            StartCoroutine(HideDamageLog());
        }

        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Игрок умер!");

        
        if (GetComponent<PlayerController>() != null)
        {
            GetComponent<PlayerController>().enabled = false;
        }

        
        if (GetComponent<Rigidbody>() != null)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().isKinematic = true;
        }

        
        if (GetComponent<MeshRenderer>() != null)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }

        
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
            Debug.Log("DeathScreen активирован.");
        }

        if (deathText != null)
        {
            deathText.text = "Ты умер";
        }

        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    
    IEnumerator HideDamageText()
    {
        yield return new WaitForSeconds(1.5f);
        if (damageText != null)
        {
            damageText.gameObject.SetActive(false);
        }
    }

    
    IEnumerator HideDamageLog()
    {
        yield return new WaitForSeconds(2f);
        if (damageLog != null)
        {
            damageLog.gameObject.SetActive(false);
        }
    }
}
