using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxCtr1 : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Sfx1");
    }

    public static void SoundPlay()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
