using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] selectBGMs;

    private void Awake()
    {
        if(instance == null)
            instance = this;

        audioSource.time = 13.65f;
    }

    public void ChangeStageSelectBGM(int index)
    {
        audioSource.Stop();
        audioSource.clip = selectBGMs[index];
        audioSource.Play();

        if (index == 0)
            audioSource.time = 13.65f;
        if (index == 2)
            audioSource.time = 36.5f;
        if(index == 1) 
            audioSource.time = 0.5f;
    }
}
