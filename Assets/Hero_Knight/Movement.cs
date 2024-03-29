using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpSpeed = 7;
    public Animator animator;
    public PlayerHealth playerHealth;

    private Rigidbody2D self;
    private bool canJump = true;
    private float direction = 0f;
    private bool running;
    private bool jumping;
	private bool attacking;
    private bool dead = false;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource attackSoundEffect;


    void Start() {
        self = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!dead) {
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
                jumpSoundEffect.Play();
                self.velocity = new Vector2(self.velocity.x, jumpSpeed);
                canJump = false;
                jumping = true;
            }
            
            if (Input.GetKey(KeyCode.M) && !attacking) {
                attackSoundEffect.Play();
                Debug.Log("attacking");
                attacking = true;
            }

            animator.SetBool("running", running);
            animator.SetBool("jumping", jumping);
            animator.SetBool("attacking", attacking);
        
            if (playerHealth.getHP() <= 0) {
                self.velocity = Vector2.zero;
                dead = true;
                running = false;
                jumping = false;
                attacking = false;
                animator.SetBool("running", running);
                animator.SetBool("jumping", jumping);
                animator.SetBool("attacking", attacking);
                animator.SetBool("dead", dead);
                StartCoroutine(Die());
            }
        }
    }

    private IEnumerator Die() {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
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
