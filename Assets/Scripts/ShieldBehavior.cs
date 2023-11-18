using System.Collections;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public float shieldDuration = 7f;

    void Start()
    {
        StartCoroutine(RespawnShield());
    }

    IEnumerator RespawnShield()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10f, 20f));

            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-5.5f, 0f), 0f);
            Instantiate(gameObject, spawnPosition, Quaternion.identity); // Use gameObject instead of shieldPrefab
            yield return new WaitForSeconds(shieldDuration);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming the PlayerBehavior script has a method to apply the shield effect.
            PlayerBehavior player = other.GetComponent<PlayerBehavior>();
            if (player != null)
            {
                player.ApplyShieldEffect();
            }
            Destroy(gameObject);
        }
    }
}
