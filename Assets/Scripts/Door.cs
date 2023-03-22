using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{
    private int nextSceneToLoad;
    private bool canPass = false;

    public Player1Attack player1Attack;
    public Attack player2Attack;
    public GameObject dragon;

    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    
    void Update() {
        if (!dragon) {
            canPass = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            if (canPass) {
                if (nextSceneToLoad == 3) {
                    player1Attack.canAttackOtherPlayer = true;
                    player2Attack.canAttackOtherPlayer = true;
                }
                SceneManager.LoadScene(nextSceneToLoad);
            }
        }
    }
}
