using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsDamage : MonoBehaviour
{
    public int trapsDamage;
    public PlayerHealth playerHealth;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(trapsDamage);
        }
    }
}
