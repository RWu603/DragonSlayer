using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("hurt");

        if(currentHealth <= 0) 
        {
            Die();
        }
    }

    void Die() {
        // Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
