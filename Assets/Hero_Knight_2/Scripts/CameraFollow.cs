using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetObject;
    private float initialPositionRelativeToTarget;
    // Start is called before the first frame update
    void Start()
    {
        if (targetObject == null)
        {
            targetObject = this.gameObject;
            Debug.Log ("defaultTarget target not specified. Defaulting to parent GameObject");
        }
        initialPositionRelativeToTarget = transform.position.x - targetObject.transform.position.x;

        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(initialPositionRelativeToTarget + targetObject.transform.position.x, transform.position.y, transform.position.z);
        // transform.LookAt(targetObject.transform);
        
    }

}
