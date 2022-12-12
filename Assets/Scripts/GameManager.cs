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
        startScreen.SetActive(true);
        gameOver.SetActive(false);
        inGame.SetActive(false);
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Pos de momento no podré usar el new input system, en una actualización lo implementaré

        if (currentGameState == GameStates.inGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // pausa
                currentGameState = GameStates.pause;
            }

            timer = (timer + Time.deltaTime);
            //print(timer);
        }
        else if (currentGameState == GameStates.pause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Reanuda
                currentGameState = GameStates.inGame;
            }
        }

        vida.text = "Life: " + PlayerMecha.instance.life;
        puntaje.text = "$" + score;
        balas.text = "Ammo: " + PlayerMecha.instance.bullets;
        timeWatch.text = "Timer: " + timer.ToString("F0");
    }

    public void SetMainMenu()
    {
        SetNewGameState(GameStates.start);
    }

    public void StartGame()
    {
        SetNewGameState(GameStates.inGame);
    }

    public void SetExitApp()
    {
        Application.Quit();
    }

    void SetNewGameState(GameStates newGameState)
    {
        switch (newGameState)
        {
            case GameStates.start:
                Time.timeScale = 0;
                startScreen.SetActive(true);
                inGame.SetActive(false);
                pause.SetActive(false);
                gameOver.SetActive(false);

                // Se establecen todas las variables que se tengan que establecer o restaurar
                PlayerMecha.instance.auxTime = 0;
                PlayerMecha.instance.life = PlayerMecha.instance.auxLife;
                PlayerMecha.instance.bullets = PlayerMecha.instance.auxBullets;
                PlayerMecha.instance.speed = PlayerMecha.instance.auxSpeed;
                break;

            case GameStates.inGame:
                Time.timeScale = 1;
                startScreen.SetActive(false);
                inGame.SetActive(true);
                pause.SetActive(false);
                gameOver.SetActive(false);
                break;

            case GameStates.pause:
                Time.timeScale = 0;
                startScreen.SetActive(false);
                inGame.SetActive(false);
                pause.SetActive(true);
                gameOver.SetActive(false);
                break;

            case GameStates.gameOver:
                Time.timeScale = 0;
                startScreen.SetActive(false);
                inGame.SetActive(false);
                pause.SetActive(false);
                gameOver.SetActive(true);
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