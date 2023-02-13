using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds Instance;

    public AudioClip GameStartSound;
    public AudioClip GameOverSound;
    public AudioClip LoseBallSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void PlayStart()
    {
        audioSource.PlayOneShot(GameStartSound);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(GameOverSound);
    }

    public void PlayLoseBall()
    {
        audioSource.PlayOneShot(LoseBallSound);
    }

}
