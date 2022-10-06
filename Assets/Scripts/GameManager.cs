using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState currentGameState;

    private void Awake()
    {
        // A shared instance is for control in every class the state of game in this case
        if (sharedInstance == null)
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
        // Some controllers to the game manager, like when the player press pause or some like that
        /* if player press (pause button) then game pauses and call SetGameState(GameState.pause) : is how it works */

    }

    void SetGameState(GameState newState)
    {
        // It switch between the states
        switch (newState)
        {
            case GameState.menu:
                Time.timeScale = 0;
                break;

            case GameState.inGame:
                Time.timeScale = 1;
                break;

            case GameState.pause:
                Time.timeScale = 0;
                break;

            case GameState.gameover:
                Time.timeScale = 0.3f;
                break;

            default:
                Debug.Log("There's no valid state or they are not working");
                break;
        }

        // here update the current game state to the new state... easy...
        currentGameState = newState;
    }
}

// in this enum are the many game states like start, pause and game over...
public enum GameState
{
    menu,
    inGame,
    pause,
    gameover
}
