using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{

    [SerializeField]  public GameObject fireball;

    public float fireRate = 1f;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        checkFireTime();
    }

    void checkFireTime() {
        if (Time.time > nextFire) {
            Instantiate(fireball, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
