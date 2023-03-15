using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public GameObject healthBar;

    private int health;
    private float hpBarDiv;

    void Start() {
        health = maxHealth;
        hpBarDiv = healthBar.transform.localScale.x / maxHealth;
    }

    public int getHP() {
        return health;
    }

    public void damage() {
        if (health > 0) {
            health--;
            Debug.Log(hpBarDiv);
            healthBar.transform.localScale -= new Vector3(hpBarDiv, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            damage();
        }
    }
}
