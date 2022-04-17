using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject lastGround;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            GroundSpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GroundSpawn()
    {
        Vector3 direction;
        if(Random.Range(0,2) == 0)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.forward;
        }
        lastGround = Instantiate(lastGround, lastGround.transform.position + direction, lastGround.transform.rotation);
    }
}
