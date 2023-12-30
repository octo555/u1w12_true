using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScript : MonoBehaviour
{
    [SerializeField] TextMeshPro click;
    [SerializeField] TextMeshPro bikkuri;
    [SerializeField] GameObject pleasewait;
    [SerializeField] GameObject fullscreensuisyou;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip pattinClip;
    bool hasClick = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && hasClick == false)
        
        {
            hasClick = true;
            audioSource.PlayOneShot(pattinClip);
            click.color = Color.yellow;
            bikkuri.color = Color.yellow;
            //click.transform.localRotation = 
            bikkuri.gameObject.transform.DOPunchPosition(new Vector2(0, 2f), 0.5f, 15, 0);
            fullscreensuisyou.SetActive(false);
            pleasewait.SetActive(true);
            Invoke("LoadSelect", 0.8f);
        }
    }

    private void LoadSelect()
    {
        SceneManager.LoadScene("Select");
    }
}
