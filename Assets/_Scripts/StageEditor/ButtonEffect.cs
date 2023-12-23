using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using Unity.VectorGraphics;
using UnityEngine.Events;
using Unity.VisualScripting;

public class ButtonEffect : MonoBehaviour
{
    [SerializeField] bool isMainMenuButton;
    [SerializeField] bool isSubMenuButton;
    [SerializeField] bool orChangeItToText;
    [SerializeField] bool orChangeItToAltIcon;

    [SerializeField] Color nomalColor;
    [SerializeField] Color whiteColor;
    [SerializeField] Color pressedColor;
    [SerializeField] float presse0dTime;

    [SerializeField] RectTransform iconTransform;
    [SerializeField] GameObject altText;
    [SerializeField] RectTransform altIcon;
    public UnityEvent onButtonClick;

    private SVGImage svgImage;
    private Vector2 iconSize;
    private Vector2 altIconSize;
    private Color preColor;

    void Awake()
    {
        if (isMainMenuButton)
        {
            svgImage = GetComponent<SVGImage>();
            iconSize = iconTransform.localScale;
        }
    }

    void OnEnable()
    {
        if (isSubMenuButton)
        {
            svgImage = GetComponent<SVGImage>();
            iconSize = iconTransform.localScale;
            altIconSize = altIcon.localScale;
        }
    }


    // マウスが乗ったときに呼ばれるメソッド
    void OnMouseEnter()
    {
        if (orChangeItToText)
        {
            iconTransform.gameObject.SetActive(false);
            altText.SetActive(true);
        }
        if (orChangeItToAltIcon)
        {
            iconTransform.gameObject.SetActive(false);
            altIcon.gameObject.SetActive(true);
        }
        svgImage.color = whiteColor;
        SEManager.instance.PlaySE(0);
    }

    // マウスが離れたときに呼ばれるメソッド
    void OnMouseExit()
    {
        if (orChangeItToText)
        {
            iconTransform.gameObject.SetActive(true);
            altText.SetActive(false);
        }
        if (orChangeItToAltIcon)
        {
            iconTransform.gameObject.SetActive(true);
            altIcon.gameObject.SetActive(false);
        }
        svgImage.color = nomalColor;
    }

    //押された
    void OnMouseDown()
    {
        onButtonClick.Invoke();
        preColor = svgImage.color;
        svgImage.color = pressedColor;
        iconTransform.DOScale(new Vector2(iconSize.x * 0.9f, iconSize.y * 0.9f), 0);
        if(orChangeItToAltIcon)
            altIcon.transform.DOScale(new Vector2(iconSize.x * 0.9f, iconSize.y * 0.9f), 0);

        PlayButtonSE();

        StartCoroutine(BackPreColor());
    }

    IEnumerator BackPreColor() //押したあと戻す
    {
        yield return new WaitForSeconds(0.1f);
        svgImage.color = preColor;
        iconTransform.DOScale(new Vector2(iconSize.x, iconSize.y), 0);
        if (orChangeItToAltIcon)
            altIcon.transform.DOScale(new Vector2(altIconSize.x, altIconSize.y), 0);
    }

    private void PlayButtonSE()
    {
        SEManager.instance.PlaySE(1);
    }
}
