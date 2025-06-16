using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpawner : MonoBehaviour
{
    [SerializeField] GameObject score;

    [SerializeField] Vector2 spawnArea;
    [SerializeField] int spawnChance;
    [SerializeField] int amountOfAllowedScore;

    Camera mainCamera;

    Vector2 spawn;

    int chance;
    int amountOfScore;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (amountOfScore < amountOfAllowedScore)
        {
            SpawnScore();
        }
    }

    void SpawnScore()
    {
        spawn.x = Random.Range(-spawnArea.x, spawnArea.x);
        spawn.y = Random.Range(-spawnArea.y, spawnArea.y);

        chance = Random.Range(1, 1000);

        if (chance <= spawnChance)
        {
            Instantiate(score, new Vector2(mainCamera.transform.position.x + spawn.x, mainCamera.transform.position.y + spawn.y), Quaternion.identity);
            amountOfScore++;
        }
    }

    public void RemovedScore()
    {
        amountOfScore--;
    }
}
