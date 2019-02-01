using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject levelCompleted;
    public GameObject gameCompleted;
    public GameObject gameOver;

    private LevelTransition levelTransition;
    private static bool isPaused = false;

    void Start()
    {
        levelTransition = FindObjectOfType<LevelTransition>();
    }

    void Update()
    {
        ShowPauseMenu();
    }

    public void ShowPauseMenu()
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

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;    //stops the game
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;    //default game state
        isPaused = false;
    }

    public void ShowLevelCompletedMenu()
    {
        
    }

    public void ShowGameCompletedMenu()
    {

    }

    public void ShowGameOverMenu()
    {

    }

    public void NextLevel()
    {

    }

    public void MainMenu()
    {

    }

    public void Restart()
    {

    }

    public void Quit()
    {

    }
}
