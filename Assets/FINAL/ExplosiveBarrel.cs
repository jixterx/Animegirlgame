using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    public int explosionDamage = 50; //  урон в 50 HP
    public GameObject explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter вызван с объектом: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок задел триггер бочки!");

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(explosionDamage);
            }

            Explode();
        }
    }

    void Explode()
    {
        Debug.Log("💥 Бочка взорвалась!");

        
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("Player")) 
            {
                Debug.Log(" Игрок получил урон от взрыва!");
                PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(50); 
                }
            }
        }

        
        Destroy(gameObject);
    }
} 
