using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistance : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;


    // Update is called once per frame
    void Update()
    {
        Vector3 center =((player1.transform.position + player2.transform.position)*0.5f);
        if(center.x < -18){
            center = new Vector3(-18, center.y, center.z);
        } else {
            transform.position = center;
        }
    }
}
