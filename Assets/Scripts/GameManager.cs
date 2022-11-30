using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // In here we can manage every state in game
    public GameStates currentGameState;
    public static GameManager sharedInstance;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Pos de momento no podr� usar el new input system, en una actualizaci�n lo implementar�
    }
}

public enum GameStates
{
    start,
    inGame,
    pause,
    gameOver,
}
