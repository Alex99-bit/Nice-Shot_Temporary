using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMecha : MonoBehaviour
{
    public static PlayerMecha instance;
    Rigidbody2D playerRB;
    Animator animator;
    public float speed, auxSpeed; 
    public int life, bullets, auxLife, auxBullets;
    public float auxTime;
    const string IS_RUNNING = "isRunning", IS_FIRE = "isFire";

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

        //playerAnim = AnimaPlayer.idle;

        auxTime = 0;

        auxLife = life;
        auxBullets = bullets;
        auxSpeed = speed;
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

            // Aqui van las animaciones
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

        if(moveX != 0 || moveY != 0)
        {
            // Animacion de correr
            animator.SetBool(IS_RUNNING, true);
        }
        else
        {
            // Para la animacion de correr
            animator.SetBool(IS_RUNNING, false);
        }
    }

    void Apunta()
    {
        // Apunta hacia donde este el cursor del mouse

    }

    void Dispara()
    {
        // Dispara y crea la animacion
        if (Input.GetButtonDown("Fire1"))
        {
            //playerAnim = AnimaPlayer.fire;
        }
    }

    void Dead()
    {
        
        //playerAnim = AnimaPlayer.dead;

        auxTime = Time.deltaTime;
        if (auxTime >= 10)
        {
            GameManager.sharedInstance.currentGameState = GameStates.gameOver;
        }
    }
}
