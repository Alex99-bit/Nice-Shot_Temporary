using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMecha : MonoBehaviour
{
    Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {

        }   
    }
}
