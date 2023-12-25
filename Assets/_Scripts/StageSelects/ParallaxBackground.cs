using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParallaxBackground : MonoBehaviour
{
    public Transform[] backgrounds; // �w�i���C���[��Transform���i�[����z��
    public float[] parallaxSpeeds; // �e�w�i���C���[�̈ړ����x
    public float resetPosition = -10f; // �w�i�����Z�b�g����ʒu

    public Transform player; // �v���C���[�I�u�W�F�N�g��Transform
    private float[] backgroundWidths; // �w�i�̕�

    void Start()
    {

        // �w�i�̕����擾
        backgroundWidths = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgroundWidths[i] = backgrounds[i].GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    void Update()
    {
        // �v���C���[��X���W�ɉ����Ĕw�i���X�N���[��������
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float moveAmount = parallaxSpeeds[i] * Time.deltaTime;
            backgrounds[i].position += new Vector3(moveAmount, 0, 0);

            // �w�i�����Z�b�g�ʒu�ɒB������A���̈ʒu�ɖ߂�
            if (backgrounds[i].position.x > resetPosition)
            {
                backgrounds[i].position -= new Vector3(backgroundWidths[i], 0, 0);
            }
        }
    }
}