using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField]
    private Text livesText;
    private int livesCounter;

    [SerializeField]
    private Text enemiesKilledText;
    private int enemiesKilledCounter;

    [SerializeField]
    private Text scoreText;
    private int scoreCounter;

    private string activeScene;

    private void Awake()
    {
        activeScene = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        livesCounter = PlayerPrefs.GetInt("Lives");
        enemiesKilledCounter = PlayerPrefs.GetInt("EnemiesKilled");
        scoreCounter = PlayerPrefs.GetInt("Score");
    }

    void Update()
    {
        livesText.text = livesCounter.ToString();
        enemiesKilledText.text = enemiesKilledCounter.ToString();
        scoreText.text = scoreCounter.ToString();
    }

    public void TakeOneLife()
    {
        livesCounter--;
        PlayerPrefs.SetInt("Lives", livesCounter);
    }

    public int GetLivesCounter()
    {
        return livesCounter;
    }

    public void ResetLivesCounter()
    {
        livesCounter = 3;
        PlayerPrefs.SetInt("Lives", livesCounter);
    }
    
    public int GetEnemiesKilledCounter()
    {
        return enemiesKilledCounter;
    }

    public void IncrementEnemiesKilledCounter()
    {
        enemiesKilledCounter++;
        PlayerPrefs.SetInt("EnemiesKilled", enemiesKilledCounter);
    }

    public int GetScoreCounter()
    {
        return scoreCounter;
    }

    public void IncreaseScoreCounter()
    {
        if(activeScene.Equals(Scenes.FirstLevel))
        {
            scoreCounter += EnemyPoints.zombunny;
            PlayerPrefs.SetInt("Score", scoreCounter);
        }

        else if(activeScene.Equals(Scenes.SecondLevel))
        {
            scoreCounter += EnemyPoints.zombear;
            PlayerPrefs.SetInt("Score", scoreCounter);
        }

        else if(activeScene.Equals(Scenes.ThirdLevel))
        {
            scoreCounter += EnemyPoints.hellephant;
            PlayerPrefs.SetInt("Score", scoreCounter);
        }
    }
}
