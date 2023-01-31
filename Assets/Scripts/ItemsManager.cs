using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsManager : MonoBehaviour
{
    private int cherryPoints = 0;
    [SerializeField] private Text cherriesText;
    PlayerHealth playerHealth;

    private void Awake() {
        playerHealth = Object.FindObjectOfType<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cherry"))
        {
            
            Destroy(other.gameObject);
            cherryPoints++;
            cherriesText.text = "" + cherryPoints;
        }

        else if (other.gameObject.CompareTag("Diamond"))
        {
            if (playerHealth.health != playerHealth.maxHealth)
            {
                playerHealth.TakeHealth();
                Destroy(other.gameObject);
            }
        }
    }
}
