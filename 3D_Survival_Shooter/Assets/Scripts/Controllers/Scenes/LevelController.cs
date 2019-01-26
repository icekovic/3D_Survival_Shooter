using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(Scenes.FirstLevel);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game...");
        Application.Quit();
    }

    public void Nextlevel(string level)
    {

    }

    public void Restartlevel()
    {
        Time.timeScale = 1f;
        //collectiblesManager.ResetCoinsCount();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
