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
        
    }
}

public enum GameStates
{
    start,
    inGame,
    pause,
    gameOver,

    // Now some states for the mini games
    carsRC,
    snowShot,
    boatRace
}
