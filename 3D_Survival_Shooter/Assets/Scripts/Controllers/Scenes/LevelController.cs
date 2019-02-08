using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int enemiesKilledCounter;
    public int scoreCounter;

    private LevelTransition levelTransition;

    void Start()
    {
        levelTransition = FindObjectOfType<LevelTransition>();
    }

    void Update()
    {
        
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("EnemiesKilled", enemiesKilledCounter);
        PlayerPrefs.SetInt("Score", scoreCounter);

        SceneManager.LoadScene(Scenes.FirstLevel);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game...");
        Application.Quit();
    }
}
