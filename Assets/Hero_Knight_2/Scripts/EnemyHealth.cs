using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public Animator animator;
    public GameObject healthBar;

    private int currentHealth;
    private float hpBarDiv;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hpBarDiv = healthBar.transform.localScale.x / maxHealth;
    }

    
    public void TakeDamage(int damage)
    {
        if (currentHealth > 0) {
            currentHealth -= damage;
            healthBar.transform.localScale -= new Vector3(hpBarDiv * damage, 0, 0);
            animator.SetTrigger("hurt");

            if(currentHealth <= 0) 
            {
                Die();
            }
        }
    }

    void Die() {
        // Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
