using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Esta clase es para los prefabs de balas
    Rigidbody2D bulletRb;
    public TypeOfBullet bulletType;
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



        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(bulletType == TypeOfBullet.bulletPlayer)
        {
            // Checa si la bala la disparo el player
            // para tomar la trayectoria de este
            if (collision.gameObject.CompareTag("enemy"))
            {
                // En caso de que la bala que disparo el player choque con un enemigo
                
            }
        }
        else if(bulletType == TypeOfBullet.bulletEnemy)
        {
            // Checa si la bala la disparo el enemigo
            // para tomar la trayectoria de este
            if (collision.gameObject.CompareTag("Player"))
            {
                // En caso de que la bala colisione con el enemigo

            }
        }
    }
}

public enum TypeOfBullet
{
    bulletEnemy,
    bulletPlayer
}