using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float xLimit = 8f;
    private bool warnedMissingPrefab;

    void OnEnable()
    {
        GameManager.GameOverEvent += StopSpawning;
    }

    void OnDisable()
    {
        GameManager.GameOverEvent -= StopSpawning;
    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            if (!warnedMissingPrefab)
            {
                Debug.LogWarning("EnemySpawner has no enemyPrefab assigned. Spawning disabled.");
                warnedMissingPrefab = true;
            }
            return;
        }

        float randomX = Random.Range(-xLimit, xLimit);
        Vector2 spawnPos = new Vector2(randomX, transform.position.y);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnEnemy");
    }
}
