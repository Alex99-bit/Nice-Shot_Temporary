using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float seg;
    public TypeOf spawnType;
    public Side side;
    Rigidbody2D rigidSpawn;
    bool cambioLado;
    public float speed;
    //int i;

    // Start is called before the first frame update
    void Start()
    {
        //i = 0;
        rigidSpawn = GetComponent<Rigidbody2D>();
        cambioLado = false;
        StartCoroutine(spawnEnemys());

        if(spawnType == TypeOf.typeA)
        {
            seg = 4;
        }
        else if(spawnType == TypeOf.typeB)
        {
            seg = 6;
        }

        if (speed == 0)
        {
            speed = 5;
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
        }
    }

    IEnumerator spawnEnemys()
    {
        while (true)
        {
            yield return new WaitForSeconds(seg);

            if (GameManager.sharedInstance.currentGameState == GameStates.inGame)
            {
                Instantiate(enemy, this.transform);
            }
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
