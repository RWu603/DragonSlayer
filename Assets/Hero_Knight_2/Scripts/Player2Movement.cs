using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpSpeed = 7;
    public Animator animator;

    public Player2Attack p2Attack;
    public PlayerHealth playerHealth;

    private Rigidbody2D player;
    private bool canJump = true;
    private float direction = 0f;
    private bool running = false;
    private bool jumping = false;
    private bool dead = false;

    [SerializeField] private AudioSource jumpSoundEffect;

    void Start() {
        player = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!dead)
        {

            direction = Input.GetAxis("Horizontal2");
            if (direction > 0f) {
                running = true;
                player.velocity = new Vector2(direction * movementSpeed, player.velocity.y);
                if (transform.localRotation.eulerAngles.y != 0)
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 180, transform.eulerAngles.z);
            } else if (direction < 0f) {
                running = true;
                player.velocity = new Vector2(direction * movementSpeed, player.velocity.y);
                if (transform.localRotation.eulerAngles.y != 180)
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
            } else{
                player.velocity = new Vector2(0, player.velocity.y);
                running = false;
            }

            if (player.velocity.y == 0) {
                canJump = true;
                jumping = false;
            }

            if (Input.GetKey("w") && canJump) {
                jumpSoundEffect.Play();
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
                canJump = false;
                running = false;
                jumping = true;
                
            }

            animator.SetBool("jumping", jumping);
            animator.SetBool("running", running);
            animator.SetBool("attacking", p2Attack.attackingAnim);

            if (playerHealth.getHP() == 0) {
                    player.velocity = Vector2.zero;
                    dead = true;
                    running = false;
                    jumping = false;
                    animator.SetBool("running", running);
                    animator.SetBool("jumping", jumping);
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
            player.gravityScale = 0f;
            player.velocity = new Vector2(0f,0f);
        }

        if (col.gameObject.tag == "Wall") {
            movementSpeed = 0; 
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        
        if (col.gameObject.tag == "Ground") {
            player.gravityScale = 1f;
        }

        if (col.gameObject.tag == "Wall") {
            movementSpeed = 5; 
        }
    }
}
