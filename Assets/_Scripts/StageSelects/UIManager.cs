using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public float scrollBairitu = 1f;
    public int currentStageNumber = 0;
    [SerializeField] Transform stages;
    [SerializeField] GameObject[] stageCanvases;
    [SerializeField] Color[] stageBGColors;
    [SerializeField] SpriteRenderer ColorBGSR;
    public float xPosOffset; 
    float stagePos;
    public bool canStageMove = true;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    private void Update()
    {

    }

    public void ChangeStageEffect()
    {
        Debug.Log("Change");
        ColorBGSR.color = stageBGColors[currentStageNumber];
        BGMManager.instance.ChangeStageSelectBGM(currentStageNumber);

        if (currentStageNumber == 0)
        {
            stagePos = 0 + xPosOffset;
            SuperGod.instance.stageNumber = 0;

        } else if (currentStageNumber == 1)
        {
            stagePos = -250 + xPosOffset;
            SuperGod.instance.stageNumber = 1;

        } else if (currentStageNumber == 2)
        {
            stagePos = -500 + xPosOffset;
            SuperGod.instance.stageNumber = 2;
        }

        //canStageMove = false;

        stages.DOMoveX(stagePos, 1f).SetEase(Ease.OutQuint)
            .OnComplete(() =>
            {
                //Invoke("SetMoveFlag", 1f);
            } );
    }

}
