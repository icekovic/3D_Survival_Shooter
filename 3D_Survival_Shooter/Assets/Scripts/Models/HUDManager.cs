using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text enemiesKilledText;
    private int enemiesKilledCounter;

    public Text scoreText;
    private int scoreCounter;

    void Start()
    {
        
    }

    void Update()
    {
        enemiesKilledText.text = "ENEMIES KILLED: " + enemiesKilledCounter.ToString();
        scoreText.text = "SCORE: " + scoreCounter.ToString();
    }

    public void IncrementEnemiesKilledCounter()
    {
        enemiesKilledCounter++;
    }

    public void IncreaseScoreCounter()
    {
        scoreCounter++;
    }

    public void ResetEnemiesKilledCounter()
    {
        enemiesKilledCounter = 0;
    }

    public void ResetScoreCounter()
    {
        scoreCounter = 0;
    }

    public int GetEnemieKilledCounter()
    {
        return enemiesKilledCounter;
    }

    public int GetScoreCounter()
    {
        return scoreCounter;
    }
}
