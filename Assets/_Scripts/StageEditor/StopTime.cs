using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    public static StopTime instance;
    public bool isPaused = false;
    [SerializeField] Transform objects;
    [SerializeField] GameObject pausePanel;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SEManager.instance.PlaySE(1);
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if(isPaused ) pausePanel.SetActive(true);
        else pausePanel.SetActive(false);

        ModifyChildRigidbodiesRecursive(objects);
    }

    private void ModifyChildRigidbodiesRecursive(Transform parent)
    {
        // �e�I�u�W�F�N�g���炷�ׂĂ̎q�I�u�W�F�N�g���擾
        foreach (Transform child in parent)
        {
            // �q�I�u�W�F�N�g��Rigidbody2D�������Ă���Ήe����^����
            Rigidbody2D childRb2d = child.GetComponent<Rigidbody2D>();
            if (childRb2d != null)
            {
                if (isPaused)
                {  
                    child.GetComponent<ObjectGravity>().preVelocity = childRb2d.velocity;
                    childRb2d.velocity = Vector2.zero;
                    child.GetComponent<ObjectGravity>().preAngular = childRb2d.angularVelocity;
                    childRb2d.angularVelocity = 0;
                    childRb2d.isKinematic = true;
                }
                else
                {
                    
                    childRb2d.velocity = child.GetComponent<ObjectGravity>().preVelocity;
                    childRb2d.angularVelocity = child.GetComponent<ObjectGravity>().preAngular;
                    childRb2d.isKinematic = false;
                }
            }

            // �q�I�u�W�F�N�g�ɑ΂��čċA�I�ɌĂяo��
            ModifyChildRigidbodiesRecursive(child);
        }
    }
}
