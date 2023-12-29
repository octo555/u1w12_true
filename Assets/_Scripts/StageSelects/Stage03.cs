using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using unityroom.Api;

public class Stage03 : MonoBehaviour
{
    [SerializeField] GameObject result;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] Transform player;
    [SerializeField] TextMeshProUGUI scoreText;
    private float scoreTime = 0;
    private bool isFalled = false;

    public static Stage03 instance;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if (isFalled == false && StopTime.instance.isPaused == false)
        {
            scoreTime += Time.deltaTime;
            int scoreTimeInt = (int)scoreTime;
            scoreText.text = scoreTimeInt + "•b";
        }

        if (player.transform.gameObject.activeSelf)
        {
            if (isFalled == false && player.transform.position.y < -7f)
            {
                isFalled = true;
                Fall();
            }
        }
    }

    public void Fall()
    {
        SuperGod.instance.PlaySE(1);
        result.SetActive(true);
        resultText.text = (Mathf.Round(scoreTime * 100) / 100f).ToString() + "sec";
        UnityroomApiClient.Instance.SendScore(2, (Mathf.Round(scoreTime * 100) / 100f), ScoreboardWriteMode.HighScoreDesc);
    }
}
