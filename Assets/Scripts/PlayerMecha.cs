using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMecha : MonoBehaviour
{
    public static PlayerMecha instance;
    Rigidbody2D playerRB;
    AnimaPlayer playerAnim;
    public float speed;
    public int life, bullets;

    private void Awake()
    {
        // creando una instancia compartida en caso de que se requiera
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();

        if(speed == 0)
        {
            speed = 5.5f;
        }

        if(life == 0)
        {
            life = 3;
        }

        if(bullets == 0)
        {
            bullets = 6;
        }

        playerAnim = AnimaPlayer.idle;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            Movement();
            Apunta();
            Dispara();

            // En caso de que la vida quede en cero, pasa lo que tiene que pasar x_x
            if (life <= 0)
            {
                life = 0;
                Dead();
            }
        }   
    }

    void Movement()
    {
        // Variables locales que solo funcionan dentro de este metodo, para administrar el movimiento
        float moveX, moveY;

        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        // Movimiento del jugador y sus animaciones
        playerRB.velocity = new Vector2(moveX, moveY) * speed;

        // Animaciones respecto al movimiento en X u Horizontalmente
        if (moveX > 0)
        {
            // Va hacia la derecha
            playerAnim = AnimaPlayer.run;
        }
        else if (moveX < 0)
        {
            // Va hacia la izquierda
            playerAnim = AnimaPlayer.run;
        }
        else if(moveX == 0)
        {
            // Se queda en el idle
            playerAnim = AnimaPlayer.idle;
        }

        // Animaciones respecto al movimiento en Y o Verticalmente
        if (moveY > 0)
        {
            // Se mueve hacia arriba
            playerAnim = AnimaPlayer.run;

        }
        else if (moveY < 0)
        {
            // Se mueve hacia abajo
            playerAnim = AnimaPlayer.run;

        }
        else if (moveY == 0)
        {
            // Se queda en idle
            playerAnim = AnimaPlayer.idle;

        }
    }

    void Apunta()
    {
        // Apunta hacia donde este el cursor del mouse

    }

    void Dispara()
    {
        // Dispara y crea la animacion

    }

    void Dead()
    {
        playerAnim = AnimaPlayer.dead;
        GameManager.sharedInstance.currentGameState = GameStates.gameOver;
    }
}

public enum AnimaPlayer
{
    idle,
    run,
    fire,
    dead
}
