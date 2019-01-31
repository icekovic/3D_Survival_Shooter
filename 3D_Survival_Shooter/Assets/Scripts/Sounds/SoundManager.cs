using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip gunshotSound;
    private AudioSource gunshotAudioSource { get { return GetComponent<AudioSource>(); } }

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

    public void PlayGunshotSound()
    {
        gunshotAudioSource.clip = gunshotSound;
        gunshotAudioSource.PlayOneShot(gunshotSound);
    }
}
