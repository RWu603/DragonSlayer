using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpSpeed = 7;
    public Animator animator;

    private Rigidbody2D self;
    private bool canJump = true;
    private float direction = 0f;
    private bool running;
    private bool jumping;
	private bool attacking;

    void Start() {
        self = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
		attacking = false;
        direction = Input.GetAxis("Horizontal");
        if (direction > 0f) {
            running = true;
            self.velocity = new Vector2(direction * movementSpeed, self.velocity.y);
            if (transform.localRotation.eulerAngles.y != 0)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 180, transform.eulerAngles.z);
        } else if (direction < 0f) {
            running = true;
            self.velocity = new Vector2(direction * movementSpeed, self.velocity.y);
            if (transform.localRotation.eulerAngles.y != 180)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        } else{
            self.velocity = new Vector2(0, self.velocity.y);
            running = false;
        }

        if (self.velocity.y == 0) {
            canJump = true;
            jumping = false;
        } else {
            running = false;
        }

        if (Input.GetKey(KeyCode.UpArrow) && canJump) {
            self.velocity = new Vector2(self.velocity.x, jumpSpeed);
            canJump = false;
            jumping = true;
        }
		
		if (Input.GetKey(KeyCode.M) && !attacking) {
			Debug.Log("attacking");
			attacking = true;
		}

        animator.SetBool("running", running);
        animator.SetBool("jumping", jumping);
		animator.SetBool("attacking", attacking);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Ground") {
            self.gravityScale = 0f;
            self.velocity = new Vector2(0f,0f);
        }

        if (col.gameObject.tag == "Wall") {
            movementSpeed = 0; 
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        
        if (col.gameObject.tag == "Ground") {
            self.gravityScale = 1f;
        }

        if (col.gameObject.tag == "Wall") {
            movementSpeed = 5; 
        }
    }
}
