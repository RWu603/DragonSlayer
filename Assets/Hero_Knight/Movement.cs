using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpSpeed = 7;
    public Animator animator;

    private Rigidbody2D player;
    private bool canJump = true;
    private float direction = 0f;
    private bool running;
    private bool jumping;

    void Start() {
        player = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
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
        } else {
            running = false;
        }

        if (Input.GetKey(KeyCode.UpArrow) && canJump) {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            canJump = false;
            jumping = true;
        }

        animator.SetBool("running", running);
        animator.SetBool("jumping", jumping);
    }
}
