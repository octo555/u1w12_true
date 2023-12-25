using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSound : MonoBehaviour
{
    public static StageSound instance;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;

    public int stageNum;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        ChangeBGMClip(3);
    }

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
