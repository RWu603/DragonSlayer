using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudGuard : MonoBehaviour
{
    public int health = 3;
    [SerializeField] public float speed = 3f;
    public Animator animator;
    
    private Rigidbody2D self;
    private bool running;

    void Start() {
        self = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (self.velocity.y < 0f) {
            self.gravityScale = 1f;
        };
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Ground") {
            self.gravityScale = 0f;
            self.velocity = new Vector2(0f,0f);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        
        if (col.gameObject.tag == "Ground") {
            self.gravityScale = 1f;
        }
    }
}
