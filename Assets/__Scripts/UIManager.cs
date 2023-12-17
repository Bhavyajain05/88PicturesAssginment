using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject GameUI;
    public GameObject startScreen;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;
    public GameObject gameCompleteScreen;

    [SerializeField] TextMeshProUGUI PlayerHeartsText;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI NumberOfBulletsFired;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (GameManager.instance.currentLevel == 0)
        {
            ShowStartScreen();
        }
    }
    private void Update()
    {
        LevelText.text = "Level: " + GameManager.instance.currentLevel;
        PlayerHeartsText.text = "Hearts: " + GameManager.instance.playerLives;
    }

    public void SetBulletFiredText()
    {
        NumberOfBulletsFired.text = GameManager.instance.totalBulletsFired.ToString();
    }

    public void Restart()
    {
        GameManager.instance.Restart();
    }


    public void ShowStartScreen()
    {
        print("Show Screen Start");
        startScreen.SetActive(true);
        GameUI.SetActive(false);
        Time.timeScale = 0; 
    }

    public void HideStartScreen()
    {
        startScreen.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1; 
    }

    public void ShowPauseScreen()
    {
        pauseScreen.SetActive(true);
        GameUI.SetActive(false);
        Time.timeScale = 0; 
    }

    public void HidePauseScreen()
    {
        pauseScreen.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1; 
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        GameUI.SetActive(false);
        Time.timeScale = 0; 
    }

    public void HideGameOverScreen()
    {
        gameOverScreen.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1;
    }

    public void ShowLevelCompleteScreen()
    {
        levelCompleteScreen.SetActive(true);
        GameUI.SetActive(false);
        Time.timeScale = 0; 
    }

    public void HideLevelCompleteScreen()
    {
        levelCompleteScreen.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1; 
    }

    public void ShowGameCompleteScreen()
    {
        SetBulletFiredText();
        gameCompleteScreen.SetActive(true);
        GameUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void HideGameCompleteScreen()
    {
        gameCompleteScreen.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1;
    }
}
