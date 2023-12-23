using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;

    public void ChangeBGMClip(int index)
    {
        

        if (index == -1)
        {
            audioSource.clip = null;
        }
        else
            audioSource.clip = audioClips[index];

        audioSource.Stop();
        audioSource.Play();
    }
}
