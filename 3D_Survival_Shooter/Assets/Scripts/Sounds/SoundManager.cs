using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip backgroundMusicFirstLevel;
    public AudioSource backgroundMusicAudioSourceFirstLevel { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip backgroundMusicSecondLevel;
    public AudioSource backgroundMusicAudioSourceSecondLevel { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip backgroundMusicThirdLevel;
    public AudioSource backgroundMusicAudioSourceThirdLevel { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip levelCompleted;
    public AudioSource levelCompletedAudioSource { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip gameCompleted;
    public AudioSource gameCompletedAudioSource { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip gameOver;
    public AudioSource gameOverAudioSource { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip gunshotSound;
    public AudioSource gunshotAudioSource { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip playerDiedSound;
    public AudioSource playerDiedAudioSource { get { return GetComponent<AudioSource>(); } }

    private LevelTransition levelTransition;

    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        levelTransition = FindObjectOfType<LevelTransition>();
    }

    void Start()
    {
        gameObject.AddComponent<AudioSource>();

        PlayBackgroundMusicFirstLevel();

        if (levelTransition.GetFirstLevelPassed())
        {
            StopBackgroundMusicFirstLevel();
            PlayBackgroundMusicSecondLevel();
        }

        else if (levelTransition.GetSecondLevelPassed())
        {
            StopBackgroundMusicSecondLevel();
            PlayBackgroundMusicThirdLevel();
        }
    }

    void Update()
    {

    }

    public void PlayPlayerDiedSound()
    {
        playerDiedAudioSource.clip = playerDiedSound;
        playerDiedAudioSource.volume = PlayerPrefs.GetFloat("Volume");     
        playerDiedAudioSource.PlayOneShot(playerDiedSound);
    }

    public void PlayGunshotSound()
    {
        gunshotAudioSource.clip = gunshotSound;
        gunshotAudioSource.volume = PlayerPrefs.GetFloat("Volume");
        gunshotAudioSource.PlayOneShot(gunshotSound);
    }

    public void PlayBackgroundMusicFirstLevel()
    {
        backgroundMusicAudioSourceFirstLevel.clip = backgroundMusicFirstLevel;
        backgroundMusicAudioSourceFirstLevel.volume = PlayerPrefs.GetFloat("Volume");
        backgroundMusicAudioSourceFirstLevel.PlayOneShot(backgroundMusicFirstLevel);
    }

    public void StopBackgroundMusicFirstLevel()
    {
        backgroundMusicAudioSourceFirstLevel.Stop();
    }

    public void PlayBackgroundMusicSecondLevel()
    {
        backgroundMusicAudioSourceSecondLevel.clip = backgroundMusicSecondLevel;
        backgroundMusicAudioSourceSecondLevel.volume = PlayerPrefs.GetFloat("Volume");
        backgroundMusicAudioSourceSecondLevel.PlayOneShot(backgroundMusicSecondLevel);
    }

    public void StopBackgroundMusicSecondLevel()
    {
        backgroundMusicAudioSourceSecondLevel.Stop();
    }

    public void PlayBackgroundMusicThirdLevel()
    {
        backgroundMusicAudioSourceThirdLevel.clip = backgroundMusicThirdLevel;
        backgroundMusicAudioSourceThirdLevel.volume = PlayerPrefs.GetFloat("Volume");
        backgroundMusicAudioSourceThirdLevel.PlayOneShot(backgroundMusicThirdLevel);
    }

    public void StopBackgroundMusicThirdLevel()
    {
        backgroundMusicAudioSourceThirdLevel.Stop();
    }

    public void PlayLevelCompletedSound()
    {
        levelCompletedAudioSource.clip = levelCompleted;
        levelCompletedAudioSource.volume = PlayerPrefs.GetFloat("Volume");
        levelCompletedAudioSource.PlayOneShot(levelCompleted);
    }

    public void PlayGameCompletedSound()
    {
        gameCompletedAudioSource.clip = gameCompleted;
        gameCompletedAudioSource.volume = PlayerPrefs.GetFloat("Volume");
        gameCompletedAudioSource.PlayOneShot(gameCompleted);
    }

    public void PlayGameOverSound()
    {
        gameOverAudioSource.clip = gameOver;
        gameOverAudioSource.volume = PlayerPrefs.GetFloat("Volume");
        gameOverAudioSource.PlayOneShot(gameOver);
    }
}
