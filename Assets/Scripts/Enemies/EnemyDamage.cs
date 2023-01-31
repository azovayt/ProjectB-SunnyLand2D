using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int enemyDamage;
    public PlayerHealth playerHealth;
    [SerializeField] GameObject enemyEffect;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(enemyDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(transform.parent.gameObject);
            Instantiate(enemyEffect, transform.position, transform.rotation);
        }
    }
}
