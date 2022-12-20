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
    public float auxTime, holdDown;
    const string IS_RUNNING = "isRunning"/*, IS_FIRE = "isFire"*/;

    [SerializeField]
    private bool canShoot;

    public Transform target;

    private void Awake()
    {
        // creando una instancia compartida en caso de que se requiera
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();

        canShoot = true;

        if(target == null)
        {
            target = this.transform;
        }

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
        holdDown = 0;

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

            if(bullets > 0)
            {
                if(bullets >= 6)
                {
                    bullets = 6;
                }
                canShoot = true;
            }

            if (bullets <= 0)
            {
                bullets = 0;
                canShoot = false;
            }

            // Hold down para recargar las balas
            holdDown += Time.deltaTime;
            if(holdDown >= 3.5f)
            {
                holdDown = 0;
                bullets++;
            }

            // En caso de que la vida quede en cero, pasa lo que tiene que pasar x_x
            if (life <= 0)
            {
                life = 0;
                Dead();
            }

            Vector3 mouseWP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWP.z = 0;

            Vector3 lookAtDir = mouseWP - target.position;
            target.right = lookAtDir;
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

    void Dead()
    {
        
        //playerAnim = AnimaPlayer.dead;

        auxTime += Time.deltaTime;
        if (auxTime >= 10)
        {
            GameManager.sharedInstance.currentGameState = GameStates.gameOver;
        }
    }

    public bool GetCanShoot()
    {
        return canShoot;
    }
}
