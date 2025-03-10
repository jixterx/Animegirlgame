using UnityEngine;

public class Coin12 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ���������, ��� ������ � ����� "Player" ������� � ������
        if (other.CompareTag("Player"))
        {
            // ������� ��������� ��� ������
            Debug.Log("����� �������� ������ � ������� 12!");

            // ������� ������ �� ����� � ��������� ��������
            AbobaTrigg chestTrigger = FindObjectOfType<AbobaTrigg>();
            if (chestTrigger != null)
            {
                chestTrigger.StartChestAnimation(); // ������ �������� �������
            }

            // ���������� ������, ����� ��� ������� ����� �������
            Destroy(gameObject);
        }
    }
}
