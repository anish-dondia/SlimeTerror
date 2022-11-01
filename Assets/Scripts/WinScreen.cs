using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        //FindObjectOfType<GameSession>().ResetGame(); //calling this from GameSession will fully reset the game with lives reset back to max
        FindObjectOfType<GameSession>().lives = 3;
        FindObjectOfType<GameSession>().livesText.text = 3.ToString();
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().lives = 3;
        FindObjectOfType<GameSession>().livesText.text = 3.ToString();
        //FindObjectOfType<GameSession>().ResetGame();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
}
