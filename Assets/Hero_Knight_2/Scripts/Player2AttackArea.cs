using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2AttackArea : MonoBehaviour
{

    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.GetComponent<Player2Health>() != null)
        {
            Player2Health health = collider.GetComponent<Player2Health>();
            health.Damage(damage);
        }
    }
}
