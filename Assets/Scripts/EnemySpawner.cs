using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner main;

    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject levelManager;
    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float difficultyScalingFactor = 0.5f;
    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;
    private bool itemsSpawned = false;
    private GameObject newEnemy;
    public List<GameObject> spawnedEnemies;

    private void Awake()
    {
        main = this;
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Update()
    {
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }

        if (spawnedEnemies.Count > 0)
        {
            for (int i = 0; i < spawnedEnemies.Count; i++)
            {
                if (spawnedEnemies[i] == null)
                {
                    spawnedEnemies.Remove(spawnedEnemies[i]);
                }
            }
        }
        
    }

    private void EnemyDestroyed()
    {
        main.enemiesAlive--;
    }

    public void StartWave()
    {
        if (!isSpawning && !itemsSpawned)
        {
            main.isSpawning = true;
            main.enemiesLeftToSpawn = main.EnemiesPerWave();
        }
        
    }

    private void EndWave()
    {
        main.isSpawning = false;
        main.itemsSpawned = true;
        LevelManager.main.gameObject.GetComponent<ItemGrabber>().Trigger();
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            enemyPrefabs[i].gameObject.GetComponent<Health>().updateHealth();
        }
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = main.enemyPrefabs[0];
        newEnemy = Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
        spawnedEnemies.Add(newEnemy);
        if (currentWave % 2 == 0 && currentWave > 2)
        {
            newEnemy.GetComponent<Health>().calcHealth(1);
        }
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(main.baseEnemies * Mathf.Pow(main.currentWave, main.difficultyScalingFactor));
    }

    public void grabItem()
    {
        LevelManager.main.gameObject.GetComponent<ItemGrabber>().itemGrabbed();
        main.itemsSpawned = false;
        main.timeSinceLastSpawn = 0f;
        main.currentWave++;
    }

    public bool checkItemsSpawned()
    {
        return main.itemsSpawned;
    }

    public List<GameObject> GetEnemies()
    {
        return spawnedEnemies;
    }
}
