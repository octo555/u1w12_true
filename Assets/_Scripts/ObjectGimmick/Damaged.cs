using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damaged : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ButtonManager.instance.ResetCursor();
            collision.gameObject.SetActive(false);
            SuperGod.instance.PlaySE(2);
            Stage03.instance.Fall();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ButtonManager.instance.ResetCursor();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
