using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public TypeOfCharacter character;
    float auxTimeEnemy;
    public GameObject bulletPlayer;
    public Transform spawnBala;
    public float force;
    

    // Start is called before the first frame update
    void Start()
    {
        auxTimeEnemy = 0;

        if (force == 0)
            force = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            if(character == TypeOfCharacter.player)
            {
                if (Input.GetButtonDown("Fire1") && PlayerMecha.instance.GetCanShoot())
                {
                    // El player dispara
                    PlayerShoot();
                }
            }

            if(character == TypeOfCharacter.enemy)
            {
                auxTimeEnemy += Time.deltaTime;

                if(auxTimeEnemy >= 3f)
                {
                    auxTimeEnemy = 0;
                    // Dispara el enemigo
                    EnemyShoot();
                }
            }
        }
    }

    void PlayerShoot()
    {
        // Logica de disparo del player

        // Crea un objeto basado en un prefab, añadiendo ciertos atributos
        GameObject bala = Instantiate(bulletPlayer, spawnBala.position, spawnBala.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(spawnBala.up * force, ForceMode2D.Impulse);

        // Se restan la cantidad de balas en el player
        PlayerMecha.instance.bullets--;
        //Destroy(bulletPlayer, 2.5f);
    }

    void EnemyShoot()
    {
        // Logica de disparo del enemigo

        GameObject bala = Instantiate(bulletPlayer, spawnBala.position, spawnBala.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(spawnBala.up * force, ForceMode2D.Impulse);
        //Destroy(bulletPlayer, 2.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (character == TypeOfCharacter.player)
        {
            if (collision.gameObject.CompareTag("BulletEnemy"))
            {
                // Lo que pasa si un enemigo le da al player
                PlayerMecha.instance.life--;
                Destroy(collision.gameObject);
            }
        }
        else
        {
            if(character == TypeOfCharacter.enemy)
            {
                if (collision.gameObject.CompareTag("BulletPlayer"))
                {
                    // Lo que pasa si el player le da a un enemigo
                    GameManager.sharedInstance.score += 5;
                    PlayerMecha.instance.bullets++;
                    GameManager.sharedInstance.tangos++;
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}

public enum TypeOfCharacter
{
    player,
    enemy
}
