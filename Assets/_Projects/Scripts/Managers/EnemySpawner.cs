using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private SimpleObjectPool objectPool;
    
    [SerializeField] private float spawnInterval = 3f; 
    private float spawnTimer;

    private void Start()
    {
        objectPool = GetComponent<SimpleObjectPool>();
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemyFromPool();
            spawnTimer = spawnInterval; 
        }
    }

    private void SpawnEnemyFromPool()
    {
        if (objectPool != null)
        {
            GameObject enemy = objectPool.GetPooledObject();

            if (enemy != null)
            {
                float randomX = Random.Range(-5f, 5f);
                enemy.transform.position = new Vector3(randomX, 6f, 0f);
                
                enemy.SetActive(true);
            }
        }
    }
}