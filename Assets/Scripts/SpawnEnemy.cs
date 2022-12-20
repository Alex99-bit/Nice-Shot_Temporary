using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    
    public GameObject enemy;
    public float seg;

    [SerializeField] private TypeOf spawnType;
    [SerializeField] private Side side;

    Rigidbody2D rigidSpawn;
    bool cambioLado;
    public float speed;

    [SerializeField]
    float holdDown;
    [SerializeField]
    bool roundActive;
    static int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        GameManager.sharedInstance.SetNumberOfRound(1);
        roundActive = true;
        rigidSpawn = GetComponent<Rigidbody2D>();
        cambioLado = false;
        StartCoroutine(spawnEnemys());

        if(spawnType == TypeOf.typeA)
        {
            seg = 4;
            speed = 5;
        }
        else if(spawnType == TypeOf.typeB)
        {
            seg = 4f;
            speed = 8;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            if (side == Side.right)
            {
                if (!cambioLado)
                {
                    rigidSpawn.velocity = new Vector2(1,0) * speed;
                }
                else
                {
                    rigidSpawn.velocity = new Vector2(-1, 0) * speed;
                }
            }

            if (side == Side.left)
            {
                if (!cambioLado)
                {
                    rigidSpawn.velocity = new Vector2(-1, 0) * speed;
                }
                else
                {
                    rigidSpawn.velocity = new Vector2(1, 0) * speed;
                }
            }

            SetNewRound();
        }
    }

    IEnumerator spawnEnemys()
    {
        while (true)
        {
            yield return new WaitForSeconds(seg);

            if (GameManager.sharedInstance.currentGameState == GameStates.inGame && roundActive)
            {
                Instantiate(enemy, this.transform);
                roundActive = false;
                i++;
            }
        }
    }

    void SetNewRound()
    {
        Debug.Log("Ronda: " + GameManager.sharedInstance.GetNumberOfRound());
        Debug.Log("Ronda activa: " + roundActive);
        Debug.Log("Cuantas veces " + i);
        if (!roundActive)
        {
            // Espera unos segundos antes de activar la siguiente ronda
            holdDown += Time.deltaTime;
            if (holdDown >= 3 && GameManager.sharedInstance.tangos >= 6)
            {
                holdDown = 0;
                GameManager.sharedInstance.SetNumberOfRound((GameManager.sharedInstance.GetNumberOfRound() + 1));
                roundActive = true;
                GameManager.sharedInstance.tangos = 0;
                Debug.Log("Todos abatidos, espera : " + holdDown + " seg");
            }
        }
        else
        {
            holdDown = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limit"))
        {
            if (!cambioLado)
            {
                cambioLado = true;
            }
            else
            {
                cambioLado = false;
            }
        }
    }
}

public enum TypeOf
{
    typeA,
    typeB
}

public enum Side
{
    left,
    right
}
