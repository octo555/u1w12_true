using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager instance;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void PlaySE(int index)
    {
        audioSource.PlayOneShot(audioClips[index]);
    }
}
