using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    [SerializeField] Vector2 spawnArea;
    [SerializeField] int spawnChance;
    [SerializeField] int amountOfAllowedEnemys;

    Camera mainCamera;

    Vector2 spawn;

    int chance;
    int amountOfEnemys;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (amountOfEnemys < amountOfAllowedEnemys)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        spawn.x = Random.Range(-spawnArea.x, spawnArea.x);
        spawn.y = Random.Range(-spawnArea.y, spawnArea.y);

        if (spawn.x > -12 && spawn.x < 12 && spawn.y > -7 && spawn.y < 7)
        {
            return;
        }
        else
        {
            chance = Random.Range(1, 1000);

            if (chance <= spawnChance)
            {
                Instantiate(enemy, new Vector2(mainCamera.transform.position.x + spawn.x, mainCamera.transform.position.y + spawn.y), Quaternion.identity);
                amountOfEnemys++;
            }
        }
    }

    public void IfDestroyed()
    {
        amountOfEnemys--;
    }
}
