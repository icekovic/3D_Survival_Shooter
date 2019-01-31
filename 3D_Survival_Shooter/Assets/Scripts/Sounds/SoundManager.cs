using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip hellephantHurtSound;
    private AudioSource hellephantHurtAudioSource { get { return GetComponent<AudioSource>(); } }

    public AudioClip hellephantDeathSound;
    private AudioSource hellephantDeathAudioSource { get { return GetComponent<AudioSource>(); } }

    public AudioClip zombearHurtSound;
    private AudioSource zombearHurtAudioSource { get { return GetComponent<AudioSource>(); } }

    public AudioClip zombearDeathSound;
    private AudioSource zombearDeathAudioSource { get { return GetComponent<AudioSource>(); } }

    public AudioClip zombunnyHurtSound;
    private AudioSource zombunnyHurtAudioSource { get { return GetComponent<AudioSource>(); } }

    public AudioClip zombunnyDeathSound;
    private AudioSource zombunnyDeathAudioSource { get { return GetComponent<AudioSource>(); } }

    public AudioClip playerHurtSound;
    private AudioSource playerHurtAudioSource { get { return GetComponent<AudioSource>(); } }

    public AudioClip gunshotSound;
    private AudioSource gunshotAudioSource { get { return GetComponent<AudioSource>(); } }

    public AudioClip levelCompletedSound;
    private AudioSource levelCompletedAudioSource { get { return GetComponent<AudioSource>(); } }

    public AudioClip gameCompletedSound;
    private AudioSource gameCompletedAudioSource { get { return GetComponent<AudioSource>(); } }

    public AudioClip gameOverSound;
    private AudioSource gameOverAudioSource { get { return GetComponent<AudioSource>(); } }

    public static SoundManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayHellephantHurtSound()
    {
        hellephantHurtAudioSource.clip = hellephantHurtSound;
        hellephantHurtAudioSource.PlayOneShot(hellephantHurtSound);
    }

    public void PlayHellephantDeathSound()
    {
        hellephantDeathAudioSource.clip = hellephantDeathSound;
        hellephantDeathAudioSource.PlayOneShot(hellephantDeathSound);
    }

    public void PlayZombearHurtSound()
    {
        zombearHurtAudioSource.clip = zombearHurtSound;
        zombearHurtAudioSource.PlayOneShot(zombearHurtSound);
    }

    public void PlayZombearDeathSound()
    {
        zombearDeathAudioSource.clip = zombearDeathSound;
        zombearDeathAudioSource.PlayOneShot(zombearDeathSound);
    }

    public void PlayZombunnyHurtSound()
    {
        zombunnyHurtAudioSource.clip = zombunnyHurtSound;
        zombunnyHurtAudioSource.PlayOneShot(zombunnyHurtSound);
    }

    public void PlayZombunnyDeathSound()
    {
        zombunnyDeathAudioSource.clip = zombunnyDeathSound;
        zombunnyDeathAudioSource.PlayOneShot(zombunnyDeathSound);
    }

    public void PlayPlayerHurtSound()
    {
        playerHurtAudioSource.clip = playerHurtSound;
        playerHurtAudioSource.PlayOneShot(playerHurtSound);
    }

    public void PlayGunshotSound()
    {
        gunshotAudioSource.clip = gunshotSound;
        gunshotAudioSource.PlayOneShot(gunshotSound);
    }

    public void PlayLevelCompletedSound()
    {
        levelCompletedAudioSource.clip = levelCompletedSound;
        levelCompletedAudioSource.PlayOneShot(levelCompletedSound);
    }

    public void PlayGameCompletedSound()
    {
        gameCompletedAudioSource.clip = gameCompletedSound;
        gameCompletedAudioSource.PlayOneShot(gameCompletedSound);
    }

    public void PlayGameOverSound()
    {
        gameOverAudioSource.clip = gameOverSound;
        gameOverAudioSource.PlayOneShot(gameOverSound);
    }
}
