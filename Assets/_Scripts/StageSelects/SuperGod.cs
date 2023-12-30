using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SuperGod : MonoBehaviour
{
    public static SuperGod instance;

    public int stageNumber = 0;
    [SerializeField] GameObject loading;
    [SerializeField] Image fillImage;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;
    [SerializeField] Image fadePanel;

    private Tween fillTween;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Select")
        {
            if (Input.GetMouseButtonDown(0))
            {
                loading.SetActive(true);

                // �O���Tween������΃L�����Z�����Ă���V����Tween���J�n
                if (fillTween != null && fillTween.IsActive() && !fillTween.IsComplete())
                {
                    fillTween.Kill();
                }

                fillImage.fillAmount = 0.15f; // �{�^���������Ƃ���fillAmount�����Z�b�g
                fillTween = fillImage.DOFillAmount(1, 2f)
                    .SetEase(Ease.Linear)
                    .OnComplete(() =>
                    {
                        LoadScene();
                        Debug.Log("oncomplete");
                    });
            }

            if (Input.GetMouseButtonUp(0))
            {
                killButton();
            }
        }
    }
    public void LoadScene()
    {
        killButton();
        audioSource.PlayOneShot(clips[0]);
        FadeOut();
        if (stageNumber == 0)
        {
            SceneManager.LoadScene("Stage01");
        }
        else if (stageNumber == 1)
        {
            SceneManager.LoadScene("Stage02");
        }
        else if (stageNumber == 2)
        {
            SceneManager.LoadScene("Stage03_A");
        }
    }

    public void LoadSelect()
    {
        Destroy(GameObject.FindGameObjectWithTag("DontDestroy"));
        SceneManager.LoadScene("Select");
    }

    public void killButton()
    {
        // �{�^���𗣂����Ƃ���Tween���L�����Z�����ēr���ŃA�j���[�V�������~
        if (fillTween != null && fillTween.IsActive() && !fillTween.IsComplete())
        {
            fillTween.Kill();
        }

        fillImage.fillAmount = 0;
        loading.SetActive(false);
    }

    public void PlaySE(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }

    public void FadeIn()
    {
       /* fadePanel.DOFade(1f, 0f);
        fadePanel.DOFade(0f, 0.3f);
       */
    }

    public void FadeOut()
    {
        /*fadePanel.DOFade(0f, 0f);
        fadePanel.DOFade(1f, 0.3f);
        */
    }
}
