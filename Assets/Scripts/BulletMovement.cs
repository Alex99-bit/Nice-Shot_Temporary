using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    Rigidbody2D bulletRb;
    public float speed;
    int pos;
    public Transform playerT;

    // Start is called before the first frame update
    void Start()
    {
        if(speed == 0)
        {
            speed = 10;
        }

        Dispara();
    }

    void Dispara()
    {
        bulletRb = GetComponent<Rigidbody2D>();

        bulletRb.velocity = new Vector2() * speed;

        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
