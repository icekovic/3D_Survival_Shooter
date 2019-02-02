using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject playerDied;
    public GameObject levelCompleted;
    public GameObject gameCompleted;
    public GameObject gameOver;
    public GameObject hudManagerGameObject;

    private HUDManager hudManager;
    private LevelTransition levelTransition;

    private static bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
        playerDied.SetActive(false);
        levelCompleted.SetActive(false);
        gameCompleted.SetActive(false);
        gameOver.SetActive(false);

        hudManager = FindObjectOfType<HUDManager>();
        levelTransition = FindObjectOfType<LevelTransition>();

        hudManager.ResetEnemiesKilledCounter();
        hudManager.ResetScoreCounter();
    }

    void Update()
    {
        ShowPauseMenu();
    }

    private void ShowPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ShowLevelCompletedMenu()
    {
        Time.timeScale = 0f;    //stops the game
        levelCompleted.SetActive(true);
        hudManagerGameObject.SetActive(false);
    }

    public void ShowPlayerDiedMenu()
    {
        Time.timeScale = 0f;    //stops the game
        playerDied.SetActive(true);
    }

    public void ShowGameCompletedMenu()
    {
        Time.timeScale = 0f;    //stops the game
        gameCompleted.SetActive(true);
        hudManagerGameObject.SetActive(false);
    }

    public void ShowGameOverMenu()
    {
        Time.timeScale = 0f;    //stops the game
        gameOver.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;    //default game state
        isPaused = false;
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;    //stops the game
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        hudManager.ResetEnemiesKilledCounter();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        hudManager.ResetEnemiesKilledCounter();
        hudManager.ResetScoreCounter();
        SceneManager.LoadScene(Scenes.FirstLevel);
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

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Scenes.MainMenu);
    }

    public void Quit()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
    }
}
