using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField]
    private Text enemiesKilledText;
    private int enemiesKilled;

    [SerializeField]
    private Text livesText;
    private int lives;

    [SerializeField]
    private Text scoreText;
    private int score;

    private Scene activeScene;

    void Start()
    {
        enemiesKilled = PlayerPrefs.GetInt("EnemiesKilled");
        lives = PlayerPrefs.GetInt("Lives");
        score = PlayerPrefs.GetInt("Score");

        activeScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        enemiesKilledText.text = enemiesKilled.ToString();
        livesText.text = lives.ToString();
        scoreText.text = score.ToString();
    }

    public void IncreaseEnemiesKilledCounter()
    {
        enemiesKilled++;
        PlayerPrefs.SetInt("EnemiesKilled", enemiesKilled);
    }

    public void IncreaseScoreCounter()
    {
        if(activeScene.name.Equals(Scenes.FirstLevel))
        {
            score = score + EnemyPoints.zombunny;
            PlayerPrefs.SetInt("Score", score);
        }
        
        else if(activeScene.name.Equals(Scenes.SecondLevel))
        {
            score = score + EnemyPoints.zombear;
            PlayerPrefs.SetInt("Score", score);
        }

        else if (activeScene.name.Equals(Scenes.ThirdLevel))
        {
            score = score + EnemyPoints.hellephant;
            PlayerPrefs.SetInt("Score", score);
        }
    }

    public void TakeOneLife()
    {
        lives--;
        PlayerPrefs.SetInt("Lives", lives);
    }

    public void ResetEnemiesKilledCounter()
    {
        enemiesKilled = 0;
        PlayerPrefs.SetInt("EnemiesKilled", enemiesKilled);
    }

    public void ResetScoreCounter()
    {
        score = 0;
        PlayerPrefs.SetInt("Score", score);
    }

    public void ResetLivesCounter()
    {
        lives = 3;
        PlayerPrefs.SetInt("Lives", lives);
    }
}
