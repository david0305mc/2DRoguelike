using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnTimer;
    [SerializeField] private Transform player;
    private float timer;


    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y),
            0f
            );
        var newEnemy = Instantiate(enemy).GetComponent<EnemyMove>();
        newEnemy.transform.position = position;
        newEnemy.targetDestination = player;
    }
}
 