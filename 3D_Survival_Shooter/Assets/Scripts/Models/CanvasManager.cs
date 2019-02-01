using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject levelCompleted;
    public GameObject gameCompleted;
    public GameObject gameOver;
    public Text enemiesToKill;
    public Text score;

    private static bool isPaused = false;

    private void Awake()
    {

    }

    void Start()
    {
        
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
