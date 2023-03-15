using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackArea;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attacking();
        }
    }

    void Attacking() {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackArea.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected() 
    {
        if (attackArea == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackArea.position, attackRange);
    }
}
