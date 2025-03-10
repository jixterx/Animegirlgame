using UnityEngine;

public class SwingingObstacle : MonoBehaviour
{
    public int damage = 25; // Урон маятника
    public float initialForce = 20f; 
    public float swingForce = 5f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false; 
            rb.AddTorque(transform.forward * initialForce, ForceMode.Impulse);
            Debug.Log("Маятник запущен!");
        }
        else
        {
            Debug.LogError("Rigidbody НЕ найден на маятнике! Добавь его в Inspector.");
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.AddTorque(transform.forward * swingForce, ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Маятник задел игрока!");

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
