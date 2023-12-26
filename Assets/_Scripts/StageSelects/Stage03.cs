using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stage03 : MonoBehaviour
{
    [SerializeField] GameObject result;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] Transform player;
    private float scoreTime = 0;
    private bool isFalled = false;

    public static Stage03 instance;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if(isFalled == false)
            scoreTime += Time.deltaTime;

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
    }
}
