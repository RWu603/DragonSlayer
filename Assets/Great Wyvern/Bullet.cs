using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 3f;
    Rigidbody2D self;
    public GameObject target1;
    public GameObject target2;
    public GameObject dragon;

    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Rigidbody2D>();
        int rand = Random.Range(0,2);
        Debug.Log(rand);
        if (rand == 0) {
            moveDirection = (target1.transform.position - dragon.transform.position).normalized * speed;
        } else {
            moveDirection = (target2.transform.position - dragon.transform.position).normalized * speed;

        }
        self.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            col.gameObject.GetComponent<PlayerHealth>().damage(10);
        }
    }
}
