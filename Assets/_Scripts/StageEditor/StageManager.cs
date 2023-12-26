using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public Transform stage;
    public Transform strage;
    public GameObject[] stages;
    public static StageManager instance;
    private string lastSceneName;
    [SerializeField] GameObject clearEffect;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        foreach (var stage in stages) { stage.SetActive(false); }
        stages[StageSound.instance.stageNum].SetActive(true);
    }

    public void GoNextStage()
    {
        DestoryObjects();

        if (StageSound.instance.stageNum == 3)
        {
            Invoke("GoSelect", 5f);
            clearEffect.SetActive(true);
            SuperGod.instance.PlaySE(1);
        }
        else
        {
            StageSound.instance.stageNum++;
            StopTime.instance.isPaused = true;
            StopTime.instance.TogglePause();
            foreach (var stage in stages) { stage.SetActive(false); }
            stages[StageSound.instance.stageNum].SetActive(true);
        }
    }

    public void GoSelect()
    {
        SuperGod.instance.LoadSelect();
    }

    void DestoryObjects()
    {
        // DrawingParent�̎q�I�u�W�F�N�g������
        foreach (Transform child in stage)
        {
            if (child.name == "DrawingTemplate(Clone)")
            {
                Destroy(child.gameObject);
            }
        }

        Transform[] children = strage.GetComponentsInChildren<Transform>();

        // �ŏ��̗v�f�͐e���̂Ȃ̂ŃX�L�b�v���Ďq���폜
        for (int i = 1; i < children.Length; i++)
        {
            Destroy(children[i].gameObject);
        }

    }
}
