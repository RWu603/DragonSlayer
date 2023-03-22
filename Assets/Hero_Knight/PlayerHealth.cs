using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public GameObject healthBar;
    public Player1Attack player1Attack;
    public Attack player2Attack;

    private int health;
    private float hpBarDiv;

    void Start() {
        resetHP();
        hpBarDiv = healthBar.transform.localScale.x / maxHealth;
    }

    public int getHP() {
        return health;
    }

    public void resetHP() {
        health = maxHealth;
    }

    public void damage(int damageToTake) {
        if (health > 0) {
            health -= damageToTake;
            healthBar.transform.localScale -= new Vector3(hpBarDiv * damageToTake, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            damage(10);
        }
    }
}
