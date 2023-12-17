using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentLevel = 0;
    public int totalBulletsFired = 0;
    public bool isGamePaused = false;
    public int playerLives = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (UIManager.instance.startScreen.activeInHierarchy)
            {
                StartGame();
            }
            else if (UIManager.instance.levelCompleteScreen.activeInHierarchy)
            {
                CompleteLevel();
            }
            // Add more conditions as needed
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void StartGame()
    {
        currentLevel++;
        UIManager.instance.HideStartScreen();
        //Restart();
    }

    public void CompleteLevel()
    {
        Time.timeScale = 1.0f;
        currentLevel++;
        if (currentLevel > 3)
        {
            UIManager.instance.HideLevelCompleteScreen();
            UIManager.instance.ShowGameCompleteScreen();
            Debug.Log("Congratulations! Total bullets fired: " + totalBulletsFired);
            currentLevel = 1;
            totalBulletsFired = 0;
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void GameOver()
    {
        UIManager.instance.ShowGameOverScreen();
        Debug.Log("Game Over");
        //currentLevel = 1;
        //totalBulletsFired = 0;
    }

    public void PlayerHit()
    {
        playerLives--;
        if (playerLives <= 0)
        {
            GameOver();
        }
    }

    public void PauseGame()
    {
        if (isGamePaused)
        {
            Time.timeScale = 1;
            isGamePaused = false;
            UIManager.instance.HidePauseScreen();
        }
        else
        {
            Time.timeScale = 0;
            isGamePaused = true;
            UIManager.instance.ShowPauseScreen();
        }
    }

    public void Restart()
    {
        currentLevel = 0;
        totalBulletsFired = 0;
        isGamePaused = false;
        playerLives = 3;
        SceneManager.LoadScene("GameScene");
    }
}
