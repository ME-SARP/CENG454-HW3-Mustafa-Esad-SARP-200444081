using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private float spawnInterval = 30f;
    
    private float timer;
    private GameObject spawnableInstance;

    private void Start()
    {
        timer = spawnInterval;

        if (powerUpPrefab != null)
        {
            spawnableInstance = Instantiate(powerUpPrefab);
            spawnableInstance.SetActive(false);
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnPowerUp();
            timer = spawnInterval; 
        }
    }

    private void SpawnPowerUp()
    {
        if (spawnableInstance != null && !spawnableInstance.activeInHierarchy)
        {
            float randomX = Random.Range(-4f, 4f);
            float randomY = Random.Range(0f, 3f);

            spawnableInstance.transform.position = new Vector3(randomX, randomY, 0f);
            spawnableInstance.SetActive(true); 
            Debug.Log("ÖDÜL KUTUSU DÜŞTÜ: Çift mermi için bu kutuyu vur!");
        }
    }
}