using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class HUDManager : MonoBehaviour
{
    [SerializeField]
    public Text enemiesKilledText;
    private int enemiesKilledCounter;

    [SerializeField]
    public Text scoreText;
    private int scoreCounter;

    void Start()
    {
        enemiesKilledCounter = PlayerPrefs.GetInt("EnemiesKilled");
        scoreCounter = PlayerPrefs.GetInt("Score");
    }

    void Update()
    {
        enemiesKilledText.text = "ENEMIES KILLED: " + enemiesKilledCounter.ToString();
        scoreText.text = "SCORE: " + scoreCounter.ToString();
    }

    public void IncrementEnemiesKilledCounter()
    {
        enemiesKilledCounter++;
        PlayerPrefs.SetInt("EnemiesKilled", enemiesKilledCounter);
    }

    public void IncreaseScoreCounter()
    {
        scoreCounter++;
        PlayerPrefs.SetInt("Score", scoreCounter);
    }

    public void ResetEnemiesKilledCounter()
    {
        enemiesKilledCounter = 0;
        PlayerPrefs.SetInt("EnemiesKilled", enemiesKilledCounter);
    }

    public void ResetScoreCounter()
    {
        scoreCounter = 0;
        PlayerPrefs.SetInt("Score", scoreCounter);
    }

    public int GetEnemiesKilledCounter()
    {
        return enemiesKilledCounter;
    }

    public int GetScoreCounter()
    {
        return scoreCounter;
    }
}
