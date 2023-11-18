using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public int points = 1;

    void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    IEnumerator SpawnCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));

            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-5.5f, 0f), 0f);
            Instantiate(gameObject, spawnPosition, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBehavior player = other.GetComponent<PlayerBehavior>();
            if (player != null)
            {
                player.EarnScore(points);
            }
            Destroy(gameObject);
        }
    }
}
