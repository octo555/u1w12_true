using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LoadManager : MonoBehaviour
{
    [SerializeField] Image fadeImage;

    private void Awake()
    {
        fadeImage.DOFade(1f, 0f).OnComplete(() =>
        {
            fadeImage.DOFade(0f, 5f);
        });
    }
}
