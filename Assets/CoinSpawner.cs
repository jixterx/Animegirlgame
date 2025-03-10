using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; 
    public int numberOfCoins = 10; 
    public Vector3 spawnArea = new Vector3(10f, 0f, 10f); 

    void Start()
    {
        SpawnCoins();
    }

    
    void SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x),  
                1f, 
                Random.Range(-spawnArea.z, spawnArea.z)   
            );

            
            Instantiate(coinPrefab, randomPosition, Quaternion.Euler(0, 90, 0)); 
        }
    }
}
