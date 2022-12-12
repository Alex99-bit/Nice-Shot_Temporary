using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMecha : MonoBehaviour
{
    Rigidbody2D enemyRB;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
