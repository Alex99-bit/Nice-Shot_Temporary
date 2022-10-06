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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetGameState(GameState state)
    {
        switch (state)
        {
            case GameState.start:

                break;
            case GameState.pause:
                
                break;
            case GameState.gameover:

                break;
            default:
                Debug.Log("There's no valid state or they are not working");
                break;
        }
    }
}

// in this enum are the many game states like start, pause and game over...
public enum GameState
{
    start,
    pause,
    gameover,
}
