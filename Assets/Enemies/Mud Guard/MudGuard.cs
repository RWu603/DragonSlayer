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

    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    public float waitTime = 1f;
    public float currentTime = 0f;

    public GameObject targetPlayer;
    public GameObject player1;
    public GameObject player2;
    private PlayerHealth player1Health;
    private PlayerHealth player2Health;
    private PlayerHealth targetPlayerHealth;


    void Start() {
        self = GetComponent<Rigidbody2D>();
        player1Health = player1.GetComponent<PlayerHealth>();
        player2Health = player2.GetComponent<PlayerHealth>();
    }

    void Update() {
        // if (self.velocity.y < 0f) {
        //     self.gravityScale = 1f;
        // };

        // Debug.Log(Vector2.Distance(transform.position, patrolPoints[0].position));

        float distToPlayer1 = Vector2.Distance(transform.position, player1.transform.position);
        float distToPlayer2 = Vector2.Distance(transform.position, player2.transform.position);
        if (distToPlayer1 < distToPlayer2 && player1Health.getHP() > 0)
        {
            targetPlayer = player1;
            targetPlayerHealth = player1Health;

        } else if (distToPlayer2 < distToPlayer1 && player2Health.getHP() > 0) {
            targetPlayer = player2;
            targetPlayerHealth = player2Health;
        }




        float distToTargetPlayer = Vector2.Distance(transform.position, targetPlayer.transform.position);

        if (distToTargetPlayer <= 9 && targetPlayer.transform.position.x < patrolPoints[0].position.x && targetPlayer.transform.position.x > patrolPoints[1].position.x && targetPlayerHealth.getHP() > 0)
        {
            if ((animator.transform.localScale.x > 0 && targetPlayer.transform.position.x < transform.position.x) || (animator.transform.localScale.x < 0 && targetPlayer.transform.position.x > transform.position.x))
            {
                flip();
            }
            Vector3 targetLoc = new Vector3(targetPlayer.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector2.MoveTowards(transform.position, targetLoc, moveSpeed * Time.deltaTime);
        }



        else
        {
        
            if(currentTime > 0)
            {
                currentTime -= 1 * Time.deltaTime;
                self.velocity = new Vector2(0, 0);
                animator.SetBool("running", false);
            }
            else
            {
                animator.SetBool("running", true);

                if(patrolDestination == 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                    // self.velocity = new Vector2(moveSpeed, 0);
                    if(Vector2.Distance(transform.position, patrolPoints[0].position) < .5f)
                    {
                        currentTime = waitTime;
                        flip();
                        patrolDestination = 1;
                    }
                }

                if(patrolDestination == 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                    // self.velocity = new Vector2(-moveSpeed, 0);
                    if(Vector2.Distance(transform.position, patrolPoints[1].position) < .5f)
                    {
                        currentTime = waitTime;
                        flip();
                        patrolDestination = 0;
                    }
                }
            }
        }
    }

    private void flip()
    {
        Vector3 localScale = animator.transform.localScale;
        localScale.x *= -1;
        animator.transform.localScale = localScale;
    }

    // void OnTriggerEnter2D(Collider2D col) {
    //     if (col.gameObject.tag == "Ground") {
    //         self.gravityScale = 0f;
    //         self.velocity = new Vector2(0f,0f);
    //     }
    // }

    // void OnTriggerExit2D(Collider2D col) {
        
    //     if (col.gameObject.tag == "Ground") {
    //         self.gravityScale = 1f;
    //     }
    // }
}
