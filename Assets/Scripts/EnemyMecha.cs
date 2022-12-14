using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMecha : MonoBehaviour
{
    // Los enemigos deberían moverse de forma aleatoria

    Rigidbody2D enemyRB;
    Animator animator;
    int rand;
    float auxTime;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        auxTime = 0;
        rand = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            auxTime += Time.deltaTime;
            if(auxTime >= 2.7f)
            {
                auxTime = 0;

            }
        }
    }
}
