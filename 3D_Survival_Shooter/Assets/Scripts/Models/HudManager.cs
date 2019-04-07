using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    //[SerializeField]
    //private Text enemiesKilledText;
    //private int enemiesKilled;

    //[SerializeField]
    //private Text livesText;
    //private int lives;

    //[SerializeField]
    //private Text scoreText;
    //private int score;

    //private Scene activeScene;

    private void Awake()
    {
        //Debug.Log(activeScene.name);
    }

    void Start()
    {
        //enemiesKilled = PlayerPrefs.GetInt("EnemiesKilled");
        //lives = PlayerPrefs.GetInt("Lives");
        //score = PlayerPrefs.GetInt("Score");
    }

    void Update()
    {
        //enemiesKilledText.text = enemiesKilled.ToString();
        //livesText.text = lives.ToString();
        //scoreText.text = score.ToString();
    }

    //public void IncreaseEnemiesKilledCounter()
    //{
    //    enemiesKilled++;
    //    PlayerPrefs.SetInt("EnemiesKilled", enemiesKilled);
    //}

    //public void IncreaseScoreCounter()
    //{

    //}

    //public void TakeOneLife()
    //{
    //    lives--;
    //    PlayerPrefs.SetInt("Lives", lives);
    //}
}
