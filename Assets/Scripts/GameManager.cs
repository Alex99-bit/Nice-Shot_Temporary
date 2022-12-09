using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    // In here we can manage every state in game
    public GameStates currentGameState;
    public static GameManager sharedInstance;
    public int score;
    // El timer puede usarse como temporizador o cronometro, falta definir
    public float timer;

    // Estos elementos son los que se mostraran en la interfaz
    public TextMeshProUGUI vida, puntaje, balas, timeWatch;
    public GameObject startScreen, gameOver, inGame, pause;

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

    public void SetMainMenu()
    {
        SetNewGameState(GameStates.start);
    }

    void SetNewGameState(GameStates newGameState)
    {
        switch (newGameState)
        {
            case GameStates.start:
                Time.timeScale = 0;
                // Se establecen todas las variables que se tengan que establecer o restaurar
                PlayerMecha.instance.auxTime = 0;
                break;
            case GameStates.inGame:
                Time.timeScale = 1;
                break;
            case GameStates.pause:
                Time.timeScale = 0;              
                break;
            case GameStates.gameOver:
                Time.timeScale = 0;
                break;
            default:
                // Lanza un error pero la vdd no veo en que panorama podr�a lanzarlo
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