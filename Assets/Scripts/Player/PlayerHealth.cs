using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    private Animator anim;
    private Rigidbody2D rb;
    UIManager uIManager;
    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    private void Awake() {
        uIManager = Object.FindObjectOfType<UIManager>();
    }

    public void TakeDamage(int damage) {
        health -= damage;
        anim.SetTrigger("hurt");
        if (health <= 0)
        {
            PlayerDie();
        }
        uIManager.HealthState();
    }

    public void TakeHealth() {
        health++;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        uIManager.HealthState();
    }

    private void PlayerDie() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(0);
    }

}
