using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyOneBehavior : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 3);
        if (transform.position.y < -8f)
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
