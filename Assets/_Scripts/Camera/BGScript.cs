using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BGScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float fadeIntime;

    private void OnEnable()
    {
        sr.color = Color.black;
    }

    public void FadeIn()
    {
        sr.DOColor(new Color(0.85f, 0.85f, 0.85f, 1f), fadeIntime)  // �F�A�ύX�ɂ����鎞��
           .SetEase(Ease.OutQuad);  // �C�[�W���O�̐ݒ�
    }
}
