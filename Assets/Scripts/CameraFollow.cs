using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform target;

    Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerMovement.isDead == false)
        {
            Vector3 newPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, newPos, 0.25f);
        }

    }
}
