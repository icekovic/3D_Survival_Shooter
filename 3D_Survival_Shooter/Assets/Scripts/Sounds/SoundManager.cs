using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip backgroundMusic1;
    private AudioSource audioSourceBackgroundMusic1 { get { return GetComponent<AudioSource>(); } }

    public AudioClip backgroundMusic2;
    private AudioSource audioSourceBackgroundMusic2 { get { return GetComponent<AudioSource>(); } }

    public AudioClip backgroundMusic3;
    private AudioSource audioSourceBackgroundMusic3 { get { return GetComponent<AudioSource>(); } }

    public AudioClip hellephantDeath;
    private AudioSource audioSourceHellephantDeath { get { return GetComponent<AudioSource>(); } }

    public AudioClip hellephantHurt;
    private AudioSource audioSourceHellephantHurt { get { return GetComponent<AudioSource>(); } }

    public AudioClip zombearHurt;
    private AudioSource audioSourceZombearHurt { get { return GetComponent<AudioSource>(); } }

    public AudioClip zombearDeath;
    private AudioSource audioSourceZombearDeath { get { return GetComponent<AudioSource>(); } }

    public AudioClip zombunnyHurt;
    private AudioSource audioSourceZombunnyHurt { get { return GetComponent<AudioSource>(); } }

    public AudioClip zombunnyDeath;
    private AudioSource audioSourceZombunnyDeath { get { return GetComponent<AudioSource>(); } }

    public AudioClip playerDeath;
    private AudioSource audioSourcePlayerDeath { get { return GetComponent<AudioSource>(); } }

    public AudioClip playerHurt;
    private AudioSource audioSourcePlayerHurt { get { return GetComponent<AudioSource>(); } }

    public AudioClip gunShooting;
    private AudioSource audioSourceGunShooting { get { return GetComponent<AudioSource>(); } }

    public AudioClip levelCompleted;
    private AudioSource audioSourceLevelCompleted { get { return GetComponent<AudioSource>(); } }

    public AudioClip gameCompleted;
    private AudioSource audioSourceGameCompleted { get { return GetComponent<AudioSource>(); } }

    public AudioClip gameOver;
    private AudioSource audioSourceGameOver { get { return GetComponent<AudioSource>(); } }

    private void Awake()
    {
        SetAudioClip(audioSourceBackgroundMusic1, backgroundMusic1);
        SetAudioClip(audioSourceBackgroundMusic2, backgroundMusic2);
        SetAudioClip(audioSourceBackgroundMusic3, backgroundMusic3);

        SetAudioClip(audioSourceHellephantDeath, hellephantDeath);
        SetAudioClip(audioSourceHellephantHurt, hellephantHurt);

        SetAudioClip(audioSourceZombearDeath, zombearDeath);
        SetAudioClip(audioSourceZombearHurt, zombearHurt);


        SetAudioClip(audioSourcePlayerDeath, playerDeath);
        SetAudioClip(audioSourcePlayerHurt, playerHurt);

        SetAudioClip(audioSourceGunShooting, gunShooting);

        SetAudioClip(audioSourceLevelCompleted, levelCompleted);
        SetAudioClip(audioSourceGameCompleted, gameCompleted);
        SetAudioClip(audioSourceGameOver, gameOver);
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void SetAudioClip(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
    }

    //to be edited
    public void PlayBackgroundMusic()
    {

    }

    //to be edited
    public void StopBackgroundMusic()
    {

    }

    public void PlayHellephantDeathSound()
    {
        audioSourceHellephantDeath.PlayOneShot(hellephantDeath);
    }

    public void PlayHellephantHurtSound()
    {
        audioSourceHellephantHurt.PlayOneShot(hellephantHurt);
    }

    public void PlayZombearDeathSound()
    {
        audioSourceZombearDeath.PlayOneShot(zombearDeath);
    }

    public void PlayZombearHurtSound()
    {
        audioSourceZombearHurt.PlayOneShot(zombearHurt);
    }

    public void PlayZombunnyDeathSound()
    {
        audioSourceZombunnyDeath.PlayOneShot(zombunnyDeath);
    }

    public void PlayZombunnyHurtSound()
    {
        audioSourceZombunnyHurt.PlayOneShot(zombunnyHurt);
    }

    public void PlayPlayerDeathSound()
    {
        audioSourcePlayerDeath.PlayOneShot(playerDeath);
    }

    public void PlayPlayerHurtSound()
    {
        audioSourcePlayerHurt.PlayOneShot(playerHurt);
    }

    public void PlayGunShootingSound()
    {
        audioSourceGunShooting.PlayOneShot(gunShooting);
    }

    public void PlayLevelCompletedSound()
    {
        audioSourceLevelCompleted.PlayOneShot(levelCompleted);
    }

    public void PlayGameCompletedSound()
    {
        audioSourceGameCompleted.PlayOneShot(gameCompleted);
    }

    public void PlayGameOverSound()
    {
        audioSourceGameOver.PlayOneShot(gameOver);
    }
}
