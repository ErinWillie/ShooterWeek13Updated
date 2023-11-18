using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject coinPrefab;
    public GameObject shieldPrefab;

    void Start()
    {
        // Spawn EnemyOne with a repeating pattern.
        InvokeRepeating("CreateEnemyOne", 1.0f, 3.0f);

        // Spawn EnemyTwo with a different repeating pattern.
        InvokeRepeating("CreateEnemyTwo", 2.0f, 4.0f);

        // Spawn Coin with a repeating pattern.
        InvokeRepeating("CreateCoin", 5.0f, 15.0f); // Spawns a coin every 15 seconds

        // Spawn Shield with a repeating pattern.
        InvokeRepeating("CreateShield", 10.0f, 20.0f); // Spawns a shield every 20 seconds
    }

    void Update()
    {

    }

    void CreateEnemyOne()
    {
        // Spawn EnemyOne at a random position.
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        // Spawn EnemyTwo at a random position on the left edge of the screen.
        float yPos = Random.Range(-5.5f, 5.5f);
        Instantiate(enemyTwoPrefab, new Vector3(-19, yPos, 0), Quaternion.identity);
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-5.5f, 0f), 0f), Quaternion.identity);
    }

    void CreateShield()
    {
        GameObject shield = Instantiate(shieldPrefab, new Vector3(Random.Range(-8f, 8f), Random.Range(-5.5f, 0f), 0f), Quaternion.identity);
        StartCoroutine(RespawnShield(shield));
    }

    IEnumerator RespawnShield(GameObject shield)
    {
        yield return new WaitForSeconds(7.0f);
        Destroy(shield);
        CreateShield(); // Respawn shield after it's destroyed
    }
}
