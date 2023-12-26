using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using unityroom.Api;

public class Stage02 : MonoBehaviour
{
    [SerializeField] GameObject result;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] Transform player;
    private bool isFalled = false;
    private int xxx = 0;

    private void Update()
    {
        if(isFalled == false && player.transform.position.y < -7f)
        {
            isFalled = true;
            xxx = (int)player.transform.position.x;
            Fall();
        } 
    }

    private void Fall()
    {
        SuperGod.instance.PlaySE(1);
        result.SetActive(true);
        resultText.text = xxx + "m";
        UnityroomApiClient.Instance.SendScore(1, xxx, ScoreboardWriteMode.HighScoreDesc);
    }
}
