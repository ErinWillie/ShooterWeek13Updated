using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoBehavior : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 2);

        if (transform.position.x > 19f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBehavior player = other.GetComponent<PlayerBehavior>();
            if (player != null)
            {
                player.LoseLife();
            }
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Weapon"))
        {
            PlayerBehavior player = other.GetComponent<PlayerBehavior>();
            if (player != null)
            {
                player.EarnScore(2);
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            PlayerBehavior player = GameObject.FindWithTag("Player").GetComponent<PlayerBehavior>();
            if (player != null)
            {
                player.EarnScore(2);
            }
            Destroy(this.gameObject);
        }
    }
}