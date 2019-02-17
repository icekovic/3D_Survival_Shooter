using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip backgroundMusic;
    private AudioSource backgroundMusicAudioSource { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip levelCompleted;
    private AudioSource levelCompletedAudioSource { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip gameCompleted;
    private AudioSource gameCompletedAudioSource { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip gameOver;
    private AudioSource gameOverAudioSource { get { return GetComponent<AudioSource>(); } }

    [SerializeField]
    private AudioClip gunshotSound;
    private AudioSource gunshotAudioSource { get { return GetComponent<AudioSource>(); } }

    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
         gameObject.AddComponent<AudioSource>();

        PlayBackgroundMusic();
    }

    void Update()
    {

    }

    public void PlayGunshotSound()
    {
        gunshotAudioSource.clip = gunshotSound;
        gunshotAudioSource.PlayOneShot(gunshotSound);
    }

    public void PlayBackgroundMusic()
    {
        backgroundMusicAudioSource.clip = backgroundMusic;
        backgroundMusicAudioSource.PlayOneShot(backgroundMusic);
    }

    public void StopBackgroundMusic()
    {
        backgroundMusicAudioSource.Stop();
    }

    public void PlayLevelCompletedSound()
    {
        levelCompletedAudioSource.clip = levelCompleted;
        levelCompletedAudioSource.PlayOneShot(levelCompleted);
    }

    public void PlayGameCompletedSound()
    {
        gameCompletedAudioSource.clip = gameCompleted;
        gameCompletedAudioSource.PlayOneShot(gameCompleted);
    }

    public void PlayGameOverSound()
    {
        gameOverAudioSource.clip = gameOver;
        gameOverAudioSource.PlayOneShot(gameOver);
    }
}
