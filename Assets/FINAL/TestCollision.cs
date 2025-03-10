using UnityEngine;

public class TestCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($" {gameObject.name} столкнулся с {collision.gameObject.name}!");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($" {gameObject.name} задет триггером {other.gameObject.name}!");
    }
}