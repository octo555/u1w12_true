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
        // 親オブジェクトからすべての子オブジェクトを取得
        foreach (Transform child in parent)
        {
            // 子オブジェクトがRigidbody2Dを持っていれば影響を与える
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

            // 子オブジェクトに対して再帰的に呼び出す
            ModifyChildRigidbodiesRecursive(child);
        }
    }
}
