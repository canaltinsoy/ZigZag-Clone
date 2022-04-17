using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 direction;
    [SerializeField] private float speed;

    private GroundSpawner groundSpawner;

    public static bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();
        direction = Vector3.left;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.y <= 0)
        {
            isDead = true;
        }

        if(isDead == true)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(direction.x == 0)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
            speed += Time.deltaTime;
        }
    }
    private void FixedUpdate() {
        Vector3 movement = direction * Time.fixedDeltaTime * speed;
        transform.position += movement;
        
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Ground")
        {
            Score.score++;
            other.gameObject.AddComponent<Rigidbody>();
            groundSpawner.GroundSpawn();
            StartCoroutine(GroundDestroy(other.gameObject));
            
        }
    }

    IEnumerator GroundDestroy(GameObject destroyedGround)
    {
        yield return new WaitForSeconds(3f);
        Destroy(destroyedGround);
    }

}
