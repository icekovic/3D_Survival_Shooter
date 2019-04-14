using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int livesCounter;

    [SerializeField]
    private int enemiesKilledCounter;

    [SerializeField]
    private int scoreCounter;

    public void PlayGame()
    {
        PlayerPrefs.SetInt("Lives", livesCounter);
        PlayerPrefs.SetInt("EnemiesKilled", enemiesKilledCounter);
        PlayerPrefs.SetInt("Score", scoreCounter);

        Time.timeScale = 1f;
        SceneManager.LoadScene(Scenes.FirstLevel);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game...");
        Application.Quit();
    }
}
