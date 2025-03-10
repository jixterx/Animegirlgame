using UnityEngine;

public class Coin12 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что объект с тегом "Player" подошел к монете
        if (other.CompareTag("Player"))
        {
            // Выводим сообщение для дебага
            Debug.Log("Игрок подобрал монету с номером 12!");

            // Находим сундук по сцене и запускаем анимацию
            AbobaTrigg chestTrigger = FindObjectOfType<AbobaTrigg>();
            if (chestTrigger != null)
            {
                chestTrigger.StartChestAnimation(); // Запуск анимации сундука
            }

            // Уничтожаем монету, чтобы она исчезла после подбора
            Destroy(gameObject);
        }
    }
}
