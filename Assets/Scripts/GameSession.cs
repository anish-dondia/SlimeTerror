using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public int lives = 3;

    public Text livesText; 
    void Awake()
    {
        int gameSessions = FindObjectsOfType<GameSession>().Length;
        if(gameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        livesText.text = lives.ToString();
    }
    
    public void PlayerDeath()
    {
        if(lives > 1)
        {
            ReduceLife();
        }
        else
        {
            ResetGame();
        }
    }

    public void ReduceLife()
    {
        lives--;
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        livesText.text = lives.ToString();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(1); //loads up level 1
        Destroy(gameObject);
    }
}
