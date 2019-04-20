using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private bool isPaused;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject playerDiedMenu;

    [SerializeField]
    private GameObject levelCompletedMenu;

    [SerializeField]
    private GameObject gameCompletedMenu;

    [SerializeField]
    private GameObject gameOverMenu;

    [SerializeField]
    private GameObject hud;

    private LevelTransition levelTransition;
    private HudManager hudManager;

    private void Awake()
    {
        isPaused = false;
        levelTransition = FindObjectOfType<LevelTransition>();
        hudManager = FindObjectOfType<HudManager>();

        pauseMenu.SetActive(false);
        playerDiedMenu.SetActive(false);
        levelCompletedMenu.SetActive(false);
        gameCompletedMenu.SetActive(false);
        gameOverMenu.SetActive(false);

    }

    void Start()
    {
        
    }

    void Update()
    {
        ShowPauseMenu();
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;    //default game state
        pauseMenu.SetActive(false);             
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;

        hudManager.ResetEnemiesKilledCounter();
        hudManager.ResetScoreCounter();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        //ako je prvi level prijeđen, loadaj drugi level/scenu
        if (levelTransition.GetFirstLevelPassed())
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(Scenes.SecondLevel);
        }

        //ako je drugi level prijeđen, loadaj treći level/scenu
        else if (levelTransition.GetSecondLevelPassed())
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(Scenes.ThirdLevel);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        hudManager.ResetEnemiesKilledCounter();
        hudManager.ResetLivesCounter();
        hudManager.ResetScoreCounter();

        SceneManager.LoadScene(Scenes.FirstLevel);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Scenes.MainMenu);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game...");
        Application.Quit();
    }

    private void ShowPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ShowLevelCompletedMenu()
    {
        Time.timeScale = 0f;    //stops the game
        levelCompletedMenu.SetActive(true);
    }

    public void ShowPlayerDiedMenu()
    {
        Time.timeScale = 0f;    //stops the game
        playerDiedMenu.SetActive(true);
    }

    public void ShowGameCompletedMenu()
    {
        Time.timeScale = 0f;    //stops the game
        gameCompletedMenu.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        Time.timeScale = 0f;    //stops the game
        gameOverMenu.SetActive(true);
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;    //paused game state
        pauseMenu.SetActive(true);
        CloseHud();
    }

    public void CloseHud()
    {
        hud.SetActive(false);
    }
}
