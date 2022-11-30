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
        // Pos de momento no podré usar el new input system, en una actualización lo implementaré

        if(currentGameState == GameStates.inGame)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                // pausa
                currentGameState = GameStates.pause;
            }
        }
        else if (currentGameState == GameStates.pause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Reanuda
                currentGameState = GameStates.inGame;
            }
        }
    }

    void SetNewGameState(GameStates newGameState)
    {
        switch (newGameState)
        {
            case GameStates.start:

                break;
            case GameStates.inGame:

                break;
            case GameStates.pause:
                
                break;
            case GameStates.gameOver:

                break;
            default:
                // Lanza un error pero la vdd no veo en que panorama podría lanzarlo
                Debug.Log(">> No se deberia estar mostrando este texto: Revisa el metodo SetNewGameState()");
                break;
        }

        currentGameState = newGameState;
    }
}

public enum GameStates
{
    start,
    inGame,
    pause,
    gameOver
}
